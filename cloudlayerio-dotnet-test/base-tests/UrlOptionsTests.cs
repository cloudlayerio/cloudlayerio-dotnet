using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.base_tests
{
    public class UrlOptionsTests<T> where T : IUrlOptions, new()
    {
        [TestMethod]
        public void Url_Exists()
        {
            var options = new T {Url = "https://cloudlayer.io"};
            var json = ClSerializer.Serialize(options);

            Assert.AreEqual("{\"url\":\"https://cloudlayer.io\"}", json);
        }
    }
}