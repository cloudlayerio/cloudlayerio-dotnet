using cloudlayerio_dotnet.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class WaitUntilOptionsTests
    {
        [TestMethod]
        public void ConvertToString_Load()
        {
            var val = WaitUntilOptions.load.ToString();
            Assert.AreEqual("load", val);
        }
        
        [TestMethod]
        public void ConvertToString_DomContentLoaded()
        {
            var val = WaitUntilOptions.domcontentloaded.ToString();
            Assert.AreEqual("domcontentloaded", val);
        }
        
        [TestMethod]
        public void ConvertToString_NetworkIdle0()
        {
            var val = WaitUntilOptions.networkidle0.ToString();
            Assert.AreEqual("networkidle0", val);
        }
        
        [TestMethod]
        public void ConvertToString_NetworkIdle2()
        {
            var val = WaitUntilOptions.networkidle2.ToString();
            Assert.AreEqual("networkidle2", val);
        }
    }
}