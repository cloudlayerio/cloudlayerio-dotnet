using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public RequestBuilder(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            if (apiKey == null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<ReturnResponse> SendRequest(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var content = new StringContent(json);

            var url = new Uri(new Uri(ApiEndpoint), obj.Path).ToString();
            var response = await _httpClient.PostAsync(url, content);

            var returnResponse = MapRateLimits(response);

            if (response.StatusCode == HttpStatusCode.OK)
                return await CreateReturnResponseSuccess(returnResponse, response);

            return await CreateReturnResponseFailure(returnResponse, response);
        }

        private static async Task<ReturnResponse> CreateReturnResponseFailure(ReturnResponse returnResponse,
            HttpResponseMessage response)
        {
            returnResponse.IsOk = false;

            var errorJson = await response.Content.ReadAsStringAsync();
            returnResponse.FailureResponse =
                ClSerializer.Deserialize<FailureResponse>(errorJson);

            return returnResponse;
        }

        private static async Task<ReturnResponse> CreateReturnResponseSuccess(ReturnResponse returnResponse,
            HttpResponseMessage response)
        {
            returnResponse.Stream = await response.Content.ReadAsStreamAsync();
            returnResponse.IsOk = true;
            return returnResponse;
        }

        private static ReturnResponse MapRateLimits(HttpResponseMessage response)
        {
            var returnResponse = new ReturnResponse
            {
                RateLimits = new RateLimits
                {
                    Limit = Convert.ToInt32(response.Headers
                        .GetValues("X-RateLimit-Limit").First()),
                    Remaining = Convert.ToInt32(response.Headers
                        .GetValues("X-RateLimit-Remaining").First()),
                    Reset = Convert.ToInt64(response.Headers
                        .GetValues("X-RateLimit-Reset").First())
                }
            };
            return returnResponse;
        }
    }
}