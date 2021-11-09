using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.types_tests
{
    [TestClass]
    public class PdfFormatTests
    {
        [TestMethod]
        public void ConvertToString_A0()
        {
            var json = ClSerializer.Serialize(PDFFormat.a0);
            Assert.AreEqual("\"a0\"", json);
        }

        [TestMethod]
        public void ConvertToString_A1()
        {
            var json = ClSerializer.Serialize(PDFFormat.a1);
            Assert.AreEqual("\"a1\"", json);
        }

        [TestMethod]
        public void ConvertToString_A2()
        {
            var json = ClSerializer.Serialize(PDFFormat.a2);
            Assert.AreEqual("\"a2\"", json);
        }

        [TestMethod]
        public void ConvertToString_A3()
        {
            var json = ClSerializer.Serialize(PDFFormat.a3);
            Assert.AreEqual("\"a3\"", json);
        }

        [TestMethod]
        public void ConvertToString_A4()
        {
            var json = ClSerializer.Serialize(PDFFormat.a4);
            Assert.AreEqual("\"a4\"", json);
        }

        [TestMethod]
        public void ConvertToString_A5()
        {
            var json = ClSerializer.Serialize(PDFFormat.a5);
            Assert.AreEqual("\"a5\"", json);
        }

        [TestMethod]
        public void ConvertToString_A6()
        {
            var json = ClSerializer.Serialize(PDFFormat.a6);
            Assert.AreEqual("\"a6\"", json);
        }

        [TestMethod]
        public void ConvertToString_Ledger()
        {
            var json = ClSerializer.Serialize(PDFFormat.ledger);
            Assert.AreEqual("\"ledger\"", json);
        }

        [TestMethod]
        public void ConvertToString_Legal()
        {
            var json = ClSerializer.Serialize(PDFFormat.legal);
            Assert.AreEqual("\"legal\"", json);
        }

        [TestMethod]
        public void ConvertToString_Letter()
        {
            var json = ClSerializer.Serialize(PDFFormat.letter);
            Assert.AreEqual("\"letter\"", json);
        }

        [TestMethod]
        public void ConvertToString_Tabloid()
        {
            var json = ClSerializer.Serialize(PDFFormat.tabloid);
            Assert.AreEqual("\"tabloid\"", json);
        }
    }
}