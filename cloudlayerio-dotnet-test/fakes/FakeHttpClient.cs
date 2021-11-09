using System.Net;
using System.Net.Http;
using Moq;

namespace cloudlayerio_dotnet_test.fakes
{
    public static class FakeHttpClient
    {
        public static HttpClient CreateFakeHttpClient(string content)
        {
            var mockFakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> {CallBase = true};
            var httpClient = new HttpClient(mockFakeHttpMessageHandler.Object);

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            };

            // httpResponseMessage.Headers.Add("X-Ratelimit-Limit", "-1");
            // httpResponseMessage.Headers.Add("X-Ratelimit-Remaining", "-1");
            // httpResponseMessage.Headers.Add("X-Ratelimit-Reset", "-1");

            mockFakeHttpMessageHandler.Setup(a =>
                a.Send(It.IsAny<HttpRequestMessage>())).Returns(httpResponseMessage);

            return httpClient;
        }
    }
}