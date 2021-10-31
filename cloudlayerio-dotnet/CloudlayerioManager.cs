using System.Net.Http;
using System.Threading.Tasks;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet.responses;

namespace cloudlayerio_dotnet
{
    /// <summary>
    ///     Initialization object for creating requests with cloudlayer.io
    /// </summary>
    public class CloudlayerioManager
    {
        private readonly string _apiKey;
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
            _apiKey = apiKey;
        }

        /// <summary>
        ///     This endpoint allows you to convert any publicly accessible URL into an Image.
        /// </summary>
        /// <param name="urlToImageParams">Url to Image parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse> UrlToImage(UrlToImage urlToImageParams)
        {
            return SendRequest(urlToImageParams);
        }

        /// <summary>
        ///     This endpoint allows you to convert any publicly accessible URL into a PDF.
        /// </summary>
        /// <param name="urlToPdfParams">Url to PDF parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse> UrlToPdf(UrlToPdf urlToPdfParams)
        {
            return SendRequest(urlToPdfParams);
        }

        private Task<ReturnResponse> SendRequest<T>(T obj) where T : class, IEndpointPath
        {
            var reqBuilder = new RequestBuilder<T>(_httpClient, _apiKey);
            return reqBuilder.SendRequest(obj);
        }
    }
}