using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet_test.base_tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.requests_tests
{
    [TestClass]
    public class HtmlToImagePuppeteerOptionsTests : PuppeteerOptionsTests<HtmlToImage>
    {
    }

    [TestClass]
    public class HtmlToImageOptionsTests : OptionsTests<HtmlToImage>
    {
    }

    [TestClass]
    public class HtmlToImageHtmlOptionsTests : HtmlOptionsTests<HtmlToImage>
    {
    }

    [TestClass]
    public class HtmlToImageImageOptionsTests : ImageOptionsTests<HtmlToImage>
    {
    }

    [TestClass]
    public class HtmlToImageTests
    {
        [TestMethod]
        public void Path_IsCorrect()
        {
            var urlToImage = new HtmlToImage();
            Assert.AreEqual("html/image", urlToImage.Path);
        }
    }
}