using System.Net.Http;
using System.Threading.Tasks;
using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet.responses;

namespace cloudlayerio_dotnet
{
    /// <summary>
    ///     Initialization object for creating requests with cloudlayer.io
    /// </summary>
    public class CloudlayerioManager
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Initialize the cloudlayer.io Manager
        /// </summary>
        /// <param name="apiKey">API Key from your Dashboard -> API Keys (Keep this secure)</param>
        public CloudlayerioManager(string apiKey)
            : this(apiKey, new HttpClient())
        {
        }

        /// <summary>
        ///     Initialize the cloudlayer.io Manager
        /// </summary>
        /// <param name="apiKey">API Key from your Dashboard -> API Keys (Keep this secure)</param>
        /// <param name="httpClient">HttpClient used for making connection.</param>
        public CloudlayerioManager(string apiKey, HttpClient httpClient)
        {
            _httpClient = httpClient;
            ConfigureHttpClient(apiKey);
        }

        private void ConfigureHttpClient(string apiKey)
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        /// <summary>
        ///     This endpoint allows you to convert any publicly accessible URL into an Image.
        /// </summary>
        /// <param name="urlToImageParams">Url to Image parameters.</param>
        public Task<ReturnResponse> UrlToImage(UrlToImage urlToImageParams)
        {
            var reqBuilder = new RequestBuilder<UrlToImage>(_httpClient);
            return reqBuilder.SendRequest(urlToImageParams);
        }
    }
}