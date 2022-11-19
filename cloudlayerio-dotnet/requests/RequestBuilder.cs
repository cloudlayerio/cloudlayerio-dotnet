using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.responses;

namespace cloudlayerio_dotnet.requests
{
    public class RequestBuilder<T> where T : class, IEndpointPath
    {
        private readonly ApiEndpointVersion _apiEndpointVersion;
        private const string ApiEndpoint = $"https://api.cloudlayer.io";
        private readonly HttpClient _httpClient;
        private readonly IStorage _storage;

        public RequestBuilder(HttpClient httpClient, string apiKey)
            : this(httpClient, apiKey, new FilesystemStorage(), ApiEndpointVersion.v2)
        {
        }

        public RequestBuilder(HttpClient httpClient, string apiKey, IStorage storage,
            ApiEndpointVersion apiEndpointVersion)
        {
            _apiEndpointVersion = apiEndpointVersion;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _storage = storage;

            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "cloudlayerio-dotnet SDK");
        }

        public async Task<ReturnResponse> SendRequest(T obj)
        {
            CheckArguments(obj);

            // var apiUrl = new Uri(ApiEndpoint);
            // var versionUrl = new Uri(apiUrl, _apiEndpointVersion.ToString());
            // var fullUrl = 

            var fullUrl = $"{ApiEndpoint}/{_apiEndpointVersion.ToString()}/{obj.Path}";
            try
            {
                using var content = CreateHttpContent(obj);
                var response = await _httpClient.PostAsync(fullUrl, content);

                var returnResponse = MapRateLimits(response);

                if ((int)response.StatusCode >= 200 && (int)response.StatusCode <= 299)
                    return await CreateReturnResponseSuccess(returnResponse, response);

                return await CreateReturnResponseFailure(returnResponse, response);
            }
            catch (Exception e)
            {
                return CreateReturnResponse(e.Message);
            }
        }

        private HttpContent CreateHttpContent(T obj)
        {
            var json = ClSerializer.Serialize(obj);

            // If the type contains a file we have to use a MultipartFormDataContent type and 
            // build the content type differently.
            if (obj is IFileOptions fileOptions && !string.IsNullOrWhiteSpace(fileOptions.FilePath))
            {
                var content = new MultipartFormDataContent();
                var stringContent = new StringContent(json);
                stringContent.Headers.Add("Content-Disposition", "form-data; name=\"json\"");
                content.Add(stringContent);

                var fileName = Path.GetFileName(fileOptions.FilePath);
                var streamContent = new StreamContent(_storage.GetFileStream(fileOptions.FilePath));
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                streamContent.Headers.Add("Content-Disposition",
                    $"form-data; name=\"file\"; filename=\"{fileName}\"");
                content.Add(streamContent, "file", fileName!);

                return content;
            }

            return new StringContent(json, null, "application/json");
        }

        private static void CheckArguments(T obj)
        {
            if (obj is IUrlOptions urlFileOpts and IFileOptions fileOpts)
            {
                if (string.IsNullOrWhiteSpace(urlFileOpts.Url) && string.IsNullOrWhiteSpace(fileOpts.FilePath))
                    throw new ArgumentException("A Url or FilePath must be specified, one or the other, but not both.");

                if (!string.IsNullOrWhiteSpace(urlFileOpts.Url) && !string.IsNullOrWhiteSpace(fileOpts.FilePath))
                    throw new ArgumentException("You must specify only one, either Url or Filepath but not both.");
            }

            if (obj is not IFileOptions && obj is IUrlOptions urlOpts && !urlOpts.Url.IsValidUrl())
                throw new ArgumentException("Url is invalid");

            if (obj is IHtmlOptions htmlOpts && !htmlOpts.Html.IsValidBase64String())
                throw new ArgumentException(
                    "Html is not a valid base64 encoded string. Html must be encoded as a base64 string." +
                    " Use the SetHtml helper method for convenience.");
        }

        private async Task<ReturnResponse> CreateReturnResponseFailure(ReturnResponse returnResponse,
            HttpResponseMessage response)
        {
            returnResponse.IsOk = false;
            var errorJson = await response.Content.ReadAsStringAsync();

            try
            {
                returnResponse.FailureResponse =
                    ClSerializer.Deserialize<FailureResponse>(errorJson);

                return returnResponse;
            }
            catch (Exception)
            {
                return CreateReturnResponse(errorJson);
            }
        }

        private ReturnResponse CreateReturnResponse(string errorMessage)
        {
            return new ReturnResponse(_storage)
            {
                IsOk = false,
                FailureResponse = new FailureResponse
                {
                    Allowed = false,
                    Error = errorMessage,
                    Reason = "Unknown error occurred. Please check Error property for details."
                }
            };
        }

        private static async Task<ReturnResponse> CreateReturnResponseSuccess(ReturnResponse returnResponse,
            HttpResponseMessage response)
        {
            returnResponse.Stream = await response.Content.ReadAsStreamAsync();
            returnResponse.IsOk = true;
            returnResponse.ContentType = response.Content.Headers.ContentType?.MediaType;
            return returnResponse;
        }

        private ReturnResponse MapRateLimits(HttpResponseMessage response)
        {
            response.Headers.TryGetValues("X-RateLimit-Limit", out var limitHeader);
            response.Headers.TryGetValues("X-RateLimit-Remaining", out var remainingHeader);
            response.Headers.TryGetValues("X-RateLimit-Reset", out var resetHeader);

            var returnResponse = new ReturnResponse(_storage)
            {
                RateLimits = new RateLimits
                {
                    Limit = Convert.ToInt32(limitHeader?.FirstOrDefault()),
                    Remaining = Convert.ToInt32(remainingHeader?.FirstOrDefault()),
                    Reset = Convert.ToInt64(resetHeader?.FirstOrDefault())
                }
            };
            return returnResponse;
        }
    }
}