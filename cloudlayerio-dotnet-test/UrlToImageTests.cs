using cloudlayerio_dotnet.requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test
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