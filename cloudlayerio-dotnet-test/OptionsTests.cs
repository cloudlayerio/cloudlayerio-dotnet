using cloudlayerio_dotnet.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class OptionsTests
    {
        [TestMethod]
        public void Serialize_Empty()
        {
            var options = new Options();
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{}", json);
        }

        [TestMethod]
        public void Serialize_TimeoutOnly()
        {
            var options = new Options {Timeout = 5000};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"timeout\":5000}", json);
        }

        [TestMethod]
        public void Serialize_DelayOnly()
        {
            var options = new Options {Delay = 2000};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"delay\":2000}", json);
        }

        [TestMethod]
        public void Serialize_FilenameOnly()
        {
            var options = new Options {Filename = "test.pdf"};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"filename\":\"test.pdf\"}", json);
        }

        [TestMethod]
        public void Serialize_InlineTrueOnly()
        {
            var options = new Options {Inline = true};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"inline\":true}", json);
        }

        [TestMethod]
        public void Serialize_InlineFalseOnly()
        {
            var options = new Options {Inline = false};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"inline\":false}", json);
        }

        [TestMethod]
        public void Serialize_All()
        {
            var options = new Options
            {
                Delay = 1000,
                Filename = "test.pdf",
                Timeout = 5000,
                Inline = true
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"timeout\":5000,\"delay\":1000,\"filename\":\"test.pdf\",\"inline\":true}", json);
        }
    }
}