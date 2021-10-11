using cloudlayerio_dotnet.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static cloudlayerio_dotnet.Interfaces.LayoutDimension;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLayoutDimension_Pixels()
        {
            string test = new LayoutDimension(UnitTypes.Pixels, 800).ToString();
            Assert.AreEqual(test, "800px");
        }

        [TestMethod]
        public void TestLayoutDimension_Millimeters()
        {
            string test = new LayoutDimension(UnitTypes.Millimeters, 25).ToString();
            Assert.AreEqual(test, "25mm");
        }

        [TestMethod]
        public void TestLayoutDimension_Inches()
        {
            string test = new LayoutDimension(UnitTypes.Inches, 1.2f).ToString();
            Assert.AreEqual(test, "1.2in");
        }

        [TestMethod]
        public void TestLayoutDimension_Centimeters()
        {
            string test = new LayoutDimension(UnitTypes.Centimeters, 0.24f).ToString();
            Assert.AreEqual(test, "0.24cm");
        }
    }
}
