using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet_test.base_tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.requests_tests
{
    [TestClass]
    public class UrlToImagePuppeteerOptionsTests : PuppeteerOptionsTests<UrlToImage>
    {
    }

    [TestClass]
    public class UrlToImageOptionsTests : OptionsTests<UrlToImage>
    {
    }

    [TestClass]
    public class UrlToImageUrlOptionsTests : UrlOptionsTests<UrlToImage>
    {
    }

    [TestClass]
    public class UrlToImageImageOptionsTests : ImageOptionsTests<UrlToImage>
    {
    }

    [TestClass]
    public class UrlToImageTests
    {
        [TestMethod]
        public void Path_IsCorrect()
        {
            var urlToImage = new UrlToImage();
            Assert.AreEqual("url/image", urlToImage.Path);
        }
    }
}