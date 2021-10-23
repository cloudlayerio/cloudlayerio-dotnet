using System.Net.Http;
using System.Threading.Tasks;
using cloudlayerio_dotnet.requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class RequestBuilderTests
    {
        [TestMethod]
        public async Task Test1()
        {
            var httpClient = new HttpClient();
            var reqBuilder = new RequestBuilder<UrlToImage>(httpClient, "test");

            var urlToImageParams = new UrlToImage
            {
                Url = "https://google.com"
            };

            var rsp = await reqBuilder.SendRequest(urlToImageParams);
        }
    }
}