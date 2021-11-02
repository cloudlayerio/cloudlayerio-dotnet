using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using cloudlayerio_dotnet.core;

namespace cloudlayerio_dotnet.responses
{
    public class ReturnResponse
    {
        private readonly IStorage _storage;

        public ReturnResponse(IStorage storage)
        {
            _storage = storage;
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

        /// <summary>
        ///     Contains information about the current RateLimits for your request.
        /// </summary>
        public RateLimits RateLimits { get; set; }

        /// <summary>
        ///     Contains information about the failure if there was one.
        ///     Check IsOk to check for failure.
        /// </summary>
        public FailureResponse FailureResponse { get; set; }

        /// <summary>
        ///     Convenience method to make it easy to save the Document to the filesystem. Will skip saving for failures.
        /// </summary>
        /// <param name="filePath">The filepath to save the document (will overwrite existing)</param>
        public async Task SaveToFilesystem(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(dir!);

            if (Stream?.Length > 0 && IsOk)
            {
                await using var fileStream = _storage.GetFileStream(filePath);
                await Stream.CopyToAsync(fileStream);
            }
            else
            {
                await using var writer = File.AppendText(Path.Combine(dir, "error.log"));
                await writer.WriteLineAsync($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}\t{filePath}\t{FailureResponse.Reason}\t{FailureResponse.Error}");
            }
        }
    }
}