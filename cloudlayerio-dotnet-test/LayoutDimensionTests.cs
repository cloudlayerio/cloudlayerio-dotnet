using cloudlayerio_dotnet.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class LayoutDimensionTests
    {
        [TestMethod]
        public void LayoutDimension_Pixels()
        {
            var test = new LayoutDimension(UnitTypes.Pixels, 800).ToString();
            Assert.AreEqual(test, "800px");
        }

        [TestMethod]
        public void LayoutDimension_Millimeters()
        {
            var test = new LayoutDimension(UnitTypes.Millimeters, 25).ToString();
            Assert.AreEqual(test, "25mm");
        }

        [TestMethod]
        public void LayoutDimension_Inches()
        {
            var test = new LayoutDimension(UnitTypes.Inches, 1.2f).ToString();
            Assert.AreEqual(test, "1.2in");
        }

        [TestMethod]
        public void LayoutDimension_Centimeters()
        {
            var test = new LayoutDimension(UnitTypes.Centimeters, 0.24f).ToString();
            Assert.AreEqual(test, "0.24cm");
        }

        [TestMethod]
        public void Serialize_Test()
        {
            var test = new LayoutDimension(UnitTypes.Centimeters, 0.24f).ToString();
            var val = RequestSerializer.Serialize(test);
            Assert.AreEqual("\"0.24cm\"", val);
        }
    }
}