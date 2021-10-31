using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.base_tests
{
    public class ImageOptionsTests<T> where T : IImageOptions, new()
    {
        [TestMethod]
        public void Serialize_Empty()
        {
            var options = new T();
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeBMP()
        {
            var options = new T {ImageType = ImageType.BMP};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"BMP\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeEPS()
        {
            var options = new T {ImageType = ImageType.EPS};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"EPS\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeGIF()
        {
            var options = new T {ImageType = ImageType.GIF};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"GIF\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeJPEG()
        {
            var options = new T {ImageType = ImageType.JPEG};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"JPEG\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypePNG()
        {
            var options = new T {ImageType = ImageType.PNG};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"PNG\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeSVG()
        {
            var options = new T {ImageType = ImageType.SVG};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"SVG\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeTIFF()
        {
            var options = new T {ImageType = ImageType.TIFF};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"TIFF\"}", json);
        }
    }
}