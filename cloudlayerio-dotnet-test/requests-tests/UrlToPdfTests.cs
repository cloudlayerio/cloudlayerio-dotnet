using cloudlayerio_dotnet.requests;
using cloudlayerio_dotnet_test.base_tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.requests_tests
{
    [TestClass]
    public class UrlToPdfPuppeteerOptionsTests : PuppeteerOptionsTests<UrlToPdf>
    {
    }

    [TestClass]
    public class UrlToPdfOptionsTests : OptionsTests<UrlToPdf>
    {
    }

    [TestClass]
    public class UrlToPdfUrlOptionsTests : UrlOptionsTests<UrlToPdf>
    {
    }

    [TestClass]
    public class UrlToPdfPdfOptionsTests : PdfOptionsTests<UrlToPdf>
    {
    }

    [TestClass]
    public class UrlToPdfTests
    {
        [TestMethod]
        public void Path_IsCorrect()
        {
            var urlToPdf = new UrlToPdf();
            Assert.AreEqual("url/pdf", urlToPdf.Path);
        }
    }
}