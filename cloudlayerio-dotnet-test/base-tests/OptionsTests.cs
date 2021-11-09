using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.base_tests
{
    public class OptionsTests<T> where T : IOptions, new()
    {
        [TestMethod]
        public void Serialize_Empty()
        {
            var options = new T();
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{}", json);
        }

        [TestMethod]
        public void Serialize_TimeoutOnly()
        {
            var options = new T {Timeout = 5000};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"timeout\":5000}", json);
        }

        [TestMethod]
        public void Serialize_DelayOnly()
        {
            var options = new T {Delay = 2000};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"delay\":2000}", json);
        }

        [TestMethod]
        public void Serialize_FilenameOnly()
        {
            var options = new T {Filename = "test.pdf"};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"filename\":\"test.pdf\"}", json);
        }

        [TestMethod]
        public void Serialize_InlineTrueOnly()
        {
            var options = new T {Inline = true};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"inline\":true}", json);
        }

        [TestMethod]
        public void Serialize_InlineFalseOnly()
        {
            var options = new T {Inline = false};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"inline\":false}", json);
        }

        [TestMethod]
        public void Serialize_All()
        {
            var options = new T
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