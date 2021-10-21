using cloudlayerio_dotnet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class WaitForSelectorOptionsTests
    {
        [TestMethod]
        public void Serialize_Empty()
        {
            var options = new WaitForSelectorOptions();
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{}", json);
        }

        [TestMethod]
        public void Serialize_VisibleTrueOnly()
        {
            var options = new WaitForSelectorOptions {Visible = true};
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{\"visible\":true}", json);
        }

        [TestMethod]
        public void Serialize_VisibleFalseOnly()
        {
            var options = new WaitForSelectorOptions {Visible = false};
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{\"visible\":false}", json);
        }

        [TestMethod]
        public void Serialize_HiddenTrueOnly()
        {
            var options = new WaitForSelectorOptions {Hidden = true};
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{\"hidden\":true}", json);
        }

        [TestMethod]
        public void Serialize_HiddenFalseOnly()
        {
            var options = new WaitForSelectorOptions {Hidden = false};
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{\"hidden\":false}", json);
        }

        [TestMethod]
        public void Serialize_TimeoutOnly()
        {
            var options = new WaitForSelectorOptions {Timeout = 3000};
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{\"timeout\":3000}", json);
        }
        
        [TestMethod]
        public void Serialize_All()
        {
            var options2 = new WaitForSelectorOptions { Visible = true, Hidden = true, Timeout = 2000};
            var json = JsonConvert.SerializeObject(options);
            Assert.AreEqual("{\"visible\":true,\"hidden\":true,\"timeout\":2000}", json);
        } 
    }
}