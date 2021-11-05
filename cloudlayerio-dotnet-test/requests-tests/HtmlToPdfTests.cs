using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet_test.base_tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.requests_tests
{
    [TestClass]
    public class HtmlToPdfPuppeteerOptionsTests : PuppeteerOptionsTests<HtmlToPdf>
    {
    }

    [TestClass]
    public class HtmlToPdfOptionsTests : OptionsTests<HtmlToPdf>
    {
    }

    [TestClass]
    public class HtmlToPdfHtmlOptionsTests : HtmlOptionsTests<HtmlToPdf>
    {
    }

    [TestClass]
    public class HtmlToPdfImageOptionsTests : PdfOptionsTests<HtmlToPdf>
    {
    }

    [TestClass]
    public class HtmlToPdfTests
    {
        [TestMethod]
        public void Path_IsCorrect()
        {
            var urlToImage = new HtmlToPdf();
            Assert.AreEqual("html/pdf", urlToImage.Path);
        }
    }
}