using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using cloudlayerio_dotnet.core;

namespace cloudlayerio_dotnet.responses
{
    public class ReturnResponse<T>
    {
        private readonly IStorage _storage;
        private static readonly ConcurrentQueue<Tuple<string, string>> Logs = new();


        private readonly CancellationTokenSource _source = new();
        private readonly CancellationToken _token;
        private FailureResponse _failureResponse;

        public ReturnResponse(IStorage storage)
        {
            _storage = storage;

            _token = _source.Token;
            Task.Run(WriteToFile, _token);
        }

        /// <summary>
        ///     If the response IsOk true, will contain the binary data of the result.
        /// </summary>
        public Stream Stream { get; internal set; }

        /// <summary>
        ///     Indicates if the response was successful (true), or failed (false).
        ///     Check FailureResponse if there was a failure for more information about the failure.
        /// </summary>
        public bool IsOk { get; internal set; }

        public string ContentType { get; internal set; }

        /// <summary>
        ///     Contains information about the current RateLimits for your request.
        /// </summary>
        public RateLimits RateLimits { get; set; }

        public Response<T> Response { get; private set; }

        /// <summary>
        ///     Contains information about the failure if there was one.
        ///     Check IsOk to check for failure.
        /// </summary>
        public FailureResponse FailureResponse
        {
            get => _failureResponse;
            set => _failureResponse = value;
        }

        /// <summary>
        ///     Convenience method to make it easy to save the Document to the filesystem. Will skip saving for failures.
        /// </summary>
        /// <param name="filePath">The filepath to save the document (will overwrite existing)</param>
        public async Task SaveToFilesystem(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(dir!);

            if (IsOk)
            {
                if (ContentType == "application/json" && !string.IsNullOrEmpty(Response.AssetUrl))
                {
                    await DownloadAsset(Response.AssetUrl, filePath);
                }
                else if (Stream?.Length > 0)
                {
                    await using var fileStream = _storage.GetFileStream(filePath);
                    await Stream.CopyToAsync(fileStream, _token);
                }
            }
            else
            {
                Logs.Enqueue(new Tuple<string, string>(Path.Combine(dir, "error.log"),
                    $"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}\t{filePath}\t{FailureResponse.Reason}\t{FailureResponse.Error}"));
            }
        }

        internal void SetResponse()
        {
            if (!IsOk || ContentType != "application/json")
            {
                Response = null;
                return;
            }

            var reader = new StreamReader(Stream);
            var json = reader.ReadToEnd();
            Response = ClSerializer.Deserialize<Response<T>>(json);
        }

        private async Task DownloadAsset(string assetUrl, string outputFilePath)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(assetUrl, _token);
            await using var stream = await response.Content.ReadAsStreamAsync(_token);
            await using var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fileStream, _token);
        }

        private async void WriteToFile()
        {
            try
            {
                while (true)
                {
                    if (_token.IsCancellationRequested)
                    {
                        return;
                    }

                    while (Logs.TryDequeue(out var log))
                    {
                        await using var fs = new FileStream(log.Item1, FileMode.Append, FileAccess.Write,
                            FileShare.Read);
                        await using var sw = new StreamWriter(fs);
                        await sw.WriteLineAsync(log.Item2);
                    }

                    Thread.Sleep(100);
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}