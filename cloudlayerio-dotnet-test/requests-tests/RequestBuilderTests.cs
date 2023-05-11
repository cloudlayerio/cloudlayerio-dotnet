using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet_test.fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Language;
using Moq.Protected;

namespace cloudlayerio_dotnet_test.requests_tests
{
    [TestClass]
    public class RequestBuilderTests
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _httpClient;

        private ISetupSequentialResult<HttpResponseMessage> When()
        {
            return _fakeHttpMessageHandler.SetupSequence(a => a.Send(It.IsAny<HttpRequestMessage>()));
        }

        [TestInitialize]
        public void Setup()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _httpClient.Dispose();
        }

        public static HttpResponseMessage ResponseMessage(HttpStatusCode statusCode)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = null!
            };
        }

        public static HttpResponseMessage ResponseMessage(HttpStatusCode statusCode, string content)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            };
        }

        public static HttpResponseMessage ResponseMessage(HttpStatusCode statusCode, Stream content)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StreamContent(content)
            };
        }

        [TestMethod]
        public async Task ApiKeyHeader_Exists()
        {
            var fakeFileStream = new FakeFileStorage();
            var testKey = "test-key-1";
            var reqBuilder =
                new RequestBuilder<UrlToImage>(_httpClient, testKey, fakeFileStream, ApiEndpointVersion.v2);

            var urlToImageParams = new UrlToImage
            {
                Url = "https://google.com"
            };

            When().Returns(ResponseMessage(HttpStatusCode.OK, ""));
            await reqBuilder.SendRequest(urlToImageParams);

            var apiKeyHeaderValue = _httpClient.DefaultRequestHeaders
                .GetValues("x-api-key").SingleOrDefault();

            Assert.AreEqual(testKey, apiKeyHeaderValue);
        }

        [TestMethod]
        public async Task UrlToImage_SendCalledOnce()
        {
            var fakeFileStream = new FakeFileStorage();
            var testKey = "test-key-1";

            var reqBuilder =
                new RequestBuilder<UrlToImage>(_httpClient, testKey, fakeFileStream, ApiEndpointVersion.v2);

            var urlToImageParams = new UrlToImage
            {
                Url = "https://google.com"
            };

            When().Returns(ResponseMessage(HttpStatusCode.OK, ""));
            await reqBuilder.SendRequest(urlToImageParams);

            _fakeHttpMessageHandler.Protected().Verify("SendAsync", Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }

        [TestMethod]
        public async Task UrlToPdf_SendCalledOnce()
        {
            var fakeFileStream = new FakeFileStorage();
            var testKey = "test-key-1";

            var reqBuilder = new RequestBuilder<UrlToPdf>(_httpClient, testKey, fakeFileStream, ApiEndpointVersion.v2);

            var urlToPdfParams = new UrlToPdf
            {
                Url = "https://google.com"
            };

            When().Returns(ResponseMessage(HttpStatusCode.OK, ""));
            await reqBuilder.SendRequest(urlToPdfParams);

            _fakeHttpMessageHandler.Protected().Verify("SendAsync", Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }

        [TestMethod]
        public async Task HtmlToImage_SendCalledOnce()
        {
            var fakeFileStream = new FakeFileStorage();
            var testKey = "test-key-1";

            var reqBuilder =
                new RequestBuilder<HtmlToImage>(_httpClient, testKey, fakeFileStream, ApiEndpointVersion.v2);

            var htmlToImageParams = new HtmlToImage();
            htmlToImageParams.SetHtml("<h1>This is a test</h1>");

            When().Returns(ResponseMessage(HttpStatusCode.OK, ""));
            await reqBuilder.SendRequest(htmlToImageParams);

            _fakeHttpMessageHandler.Protected().Verify("SendAsync", Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}