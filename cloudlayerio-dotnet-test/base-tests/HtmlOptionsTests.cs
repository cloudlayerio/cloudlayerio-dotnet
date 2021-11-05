using System;
using System.Text;
using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.base_tests
{
    public class HtmlOptionsTests<T> where T : IHtmlOptions, new()
    {
        [TestMethod]
        public void Html_Exists()
        {
            const string html = "<h1>This is some test html!</h1>";
            var bytes = Encoding.Default.GetBytes(html);
            var base64EncodedHtml = Convert.ToBase64String(bytes);

            var options = new T {Html = base64EncodedHtml};
            var json = ClSerializer.Serialize(options);

            Assert.AreEqual($"{{\"html\":\"{base64EncodedHtml}\"}}", json);
        }
        
        [TestMethod]
        public void Html_SetHtmlCorrect()
        {
            const string html = "<h1>This is some test html!</h1>";
            var bytes = Encoding.Default.GetBytes(html);
            var base64EncodedHtml = Convert.ToBase64String(bytes);

            var options = new T();
            options.SetHtml(html);
            
            Assert.AreEqual(base64EncodedHtml, options.Html);
        }
    }
}