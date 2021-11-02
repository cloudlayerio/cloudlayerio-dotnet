using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.responses;

namespace cloudlayerio_dotnet.requests
{
    public class RequestBuilder<T> where T : class, IEndpointPath
    {
        private const string ApiEndpoint = "https://api.cloudlayer.io/v1/";
        private readonly HttpClient _httpClient;
        private readonly IStorage _storage;

        public RequestBuilder(HttpClient httpClient, string apiKey)
            : this(httpClient, apiKey, new FilesystemStorage())
        {
        }

        public RequestBuilder(HttpClient httpClient, string apiKey, IStorage storage)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _storage = storage;

            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<ReturnResponse> SendRequest(T obj)
        {
            CheckArguments(obj);

            var json = ClSerializer.Serialize(obj);
            var content = new StringContent(json, null, "application/json");

            var url = new Uri(new Uri(ApiEndpoint), obj.Path).ToString();

            try
            {
                var response = await _httpClient.PostAsync(url, content);

                var returnResponse = MapRateLimits(response);

                if ((int) response.StatusCode >= 200 && (int) response.StatusCode <= 299)
                    return await CreateReturnResponseSuccess(returnResponse, response);
                
                return await CreateReturnResponseFailure(returnResponse, response);
            }
            catch (Exception e)
            {
                return CreateReturnResponse(e);
            }
        }

        private static void CheckArguments(T obj)
        {
            if (obj is IUrlOptions urlOpts && !IsValidUrl(urlOpts.Url))
                throw new ArgumentException("Url is invalid");
        }

        private async Task<ReturnResponse> CreateReturnResponseFailure(ReturnResponse returnResponse,
            HttpResponseMessage response)
        {
            returnResponse.IsOk = false;

            try
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                returnResponse.FailureResponse =
                    ClSerializer.Deserialize<FailureResponse>(errorJson);

                return returnResponse;
            }
            catch (Exception e)
            {
                return CreateReturnResponse(e);
            }
        }

        private ReturnResponse CreateReturnResponse(Exception e)
        {
            return new ReturnResponse(_storage)
            {
                IsOk = false,
                FailureResponse = new FailureResponse
                {
                    Allowed = false,
                    Error = e.Message,
                    Reason = "Unknown error occurred. Please check Error property for details."
                }
            };
        }

        private static async Task<ReturnResponse> CreateReturnResponseSuccess(ReturnResponse returnResponse,
            HttpResponseMessage response)
        {
            returnResponse.Stream = await response.Content.ReadAsStreamAsync();
            returnResponse.IsOk = true;
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

        private static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}