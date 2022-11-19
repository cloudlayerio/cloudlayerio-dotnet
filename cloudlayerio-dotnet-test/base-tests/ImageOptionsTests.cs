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
            var options = new T {ImageType = ImageType.Png};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"png\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeEPS()
        {
            var options = new T {ImageType = ImageType.Jpg};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"jpg\"}", json);
        }

        [TestMethod]
        public void Serialize_ImageTypeGIF()
        {
            var options = new T {ImageType = ImageType.Webp};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"imageType\":\"webp\"}", json);
        }
    }
}