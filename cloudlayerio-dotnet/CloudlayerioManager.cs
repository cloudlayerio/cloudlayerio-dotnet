using System;
using System.Net.Http;
using System.Text;
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
        private readonly ApiEndpointVersion _apiEndpointVersion = ApiEndpointVersion.v2;

        /// <summary>
        ///     Initialize the cloudlayer.io Manager
        /// </summary>
        /// <param name="apiKey">API Key from your Dashboard -> API Keys (Keep this secure)</param>
        public CloudlayerioManager(string apiKey)
            : this(apiKey, new HttpClient(), ApiEndpointVersion.v2)
        {
        }
        
        /// <summary>
        ///     Initialize the cloudlayer.io Manager
        /// </summary>
        /// <param name="apiKey">API Key from your Dashboard -> API Keys (Keep this secure)</param>
        /// <param name="apiEndpointVersion">Optional version of the API to call.</param>
        public CloudlayerioManager(string apiKey, ApiEndpointVersion apiEndpointVersion)
            : this(apiKey, new HttpClient(), apiEndpointVersion)
        {
        }

        /// <summary>
        ///     Initialize the cloudlayer.io Manager
        /// </summary>
        /// <param name="apiKey">API Key from your Dashboard -> API Keys (Keep this secure)</param>
        /// <param name="httpClient">HttpClient used for making connection.</param>
        /// <param name="apiEndpointVersion">Optional version of the API to call.</param>
        public CloudlayerioManager(string apiKey, HttpClient httpClient, ApiEndpointVersion? apiEndpointVersion)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            
            if (apiEndpointVersion.HasValue)
            {
                _apiEndpointVersion = apiEndpointVersion.Value;
            }
        }

        /// <summary>
        ///     This endpoint lets you to convert any publicly accessible URL into an Image.
        /// </summary>
        /// <param name="urlToImageParams">Url to Image parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse<UrlToImage>> UrlToImage(UrlToImage urlToImageParams)
        {
            return SendRequest(urlToImageParams);
        }

        /// <summary>
        ///     This endpoint lets you to convert any publicly accessible URL into a PDF.
        /// </summary>
        /// <param name="urlToPdfParams">Url to PDF parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse<UrlToPdf>> UrlToPdf(UrlToPdf urlToPdfParams)
        {
            return SendRequest(urlToPdfParams);
        }

        /// <summary>
        ///     This endpoints lets you to convert any html to an image.
        /// </summary>
        /// <param name="htmlToImage">Html to Image parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse<HtmlToImage>> HtmlToImage(HtmlToImage htmlToImage)
        {
            return SendRequest(htmlToImage);
        }
        
        /// <summary>
        ///     This endpoints lets you to convert any html to a pdf.
        /// </summary>
        /// <param name="htmlToPdf">Html to Pdf parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse<HtmlToPdf>> HtmlToPdf(HtmlToPdf htmlToPdf)
        {
            return SendRequest(htmlToPdf);
        }
        
        /// <summary>
        ///     This endpoints lets you to convert any html to a pdf.
        /// </summary>
        /// <param name="docxToPdf">Docx to Pdf parameters.</param>
        /// <returns>Returns a ReturnResponse type</returns>
        public Task<ReturnResponse<DocxToPdf>> DocxToPdf(DocxToPdf docxToPdf)
        {
            return SendRequest(docxToPdf);
        }

        private Task<ReturnResponse<T>> SendRequest<T>(T obj) where T : class, IEndpointPath
        {
            var reqBuilder = new RequestBuilder<T>(_httpClient, _apiKey, _apiEndpointVersion);
            return reqBuilder.SendRequest(obj);
        }
    }
}