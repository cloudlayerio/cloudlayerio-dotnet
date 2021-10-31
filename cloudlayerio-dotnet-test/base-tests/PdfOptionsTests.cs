using System.Collections.Generic;
using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.base_tests
{
    public class PdfOptionsTests<T> where T : IPdfOptions, new()
    {
        [TestMethod]
        public void Serialize_Empty()
        {
            var options = new T();
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{}", json);
        }

        [TestMethod]
        public void Serialize_Format()
        {
            var options = new T {Format = PDFFormat.a0};
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual("{\"format\":\"a0\"}", json);
        }

        [TestMethod]
        public void Serialize_Margin()
        {
            var options = new T
            {
                Margin = new Margin
                {
                    Bottom = new LayoutDimension(UnitTypes.Pixels, 100),
                    Top = new LayoutDimension(UnitTypes.Pixels, 200),
                    Left = new LayoutDimension(UnitTypes.Pixels, 300),
                    Right = new LayoutDimension(UnitTypes.Pixels, 400)
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"margin\":{\"left\":\"300px\",\"right\":\"400px\",\"top\":\"200px\",\"bottom\":\"100px\"}}",
                json);
        }

        [TestMethod]
        public void Serialize_FooterTemplateMargin()
        {
            var options = new T
            {
                FooterTemplate = new HeaderFooterTemplate
                {
                    Margin = new Margin
                    {
                        Bottom = new LayoutDimension(UnitTypes.Pixels, 110),
                        Top = new LayoutDimension(UnitTypes.Pixels, 220),
                        Left = new LayoutDimension(UnitTypes.Pixels, 330),
                        Right = new LayoutDimension(UnitTypes.Pixels, 440)
                    }
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"footerTemplate\":{\"margin\":{\"left\":\"330px\",\"right\":\"440px\",\"top\":\"220px\",\"bottom\":\"110px\"}}}",
                json);
        }

        [TestMethod]
        public void Serialize_HeaderTemplateMargin()
        {
            var options = new T
            {
                HeaderTemplate = new HeaderFooterTemplate
                {
                    Margin = new Margin
                    {
                        Bottom = new LayoutDimension(UnitTypes.Pixels, 111),
                        Top = new LayoutDimension(UnitTypes.Pixels, 221),
                        Left = new LayoutDimension(UnitTypes.Pixels, 331),
                        Right = new LayoutDimension(UnitTypes.Pixels, 441)
                    }
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"headerTemplate\":{\"margin\":{\"left\":\"331px\",\"right\":\"441px\",\"top\":\"221px\",\"bottom\":\"111px\"}}}",
                json);
        }

        [TestMethod]
        public void Serialize_HeaderTemplateMethod()
        {
            var options = new T
            {
                HeaderTemplate = new HeaderFooterTemplate
                {
                    Method = HeaderFooterTemplateMethod.extract
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"headerTemplate\":{\"method\":\"extract\"}}",
                json);
        }

        [TestMethod]
        public void Serialize_FooterTemplateMethod()
        {
            var options = new T
            {
                FooterTemplate = new HeaderFooterTemplate
                {
                    Method = HeaderFooterTemplateMethod.extract
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"footerTemplate\":{\"method\":\"extract\"}}",
                json);
        }

        [TestMethod]
        public void Serialize_HeaderTemplateSelector()
        {
            var options = new T
            {
                HeaderTemplate = new HeaderFooterTemplate
                {
                    Selector = "#testSelector"
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"headerTemplate\":{\"selector\":\"#testSelector\"}}",
                json);
        }

        [TestMethod]
        public void Serialize_FooterTemplateSelector()
        {
            var options = new T
            {
                FooterTemplate = new HeaderFooterTemplate
                {
                    Selector = "#testSelector"
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"footerTemplate\":{\"selector\":\"#testSelector\"}}",
                json);
        }

        [TestMethod]
        public void Serialize_HeaderTemplateStyle()
        {
            var options = new T
            {
                HeaderTemplate = new HeaderFooterTemplate
                {
                    Style = new Dictionary<string, string>
                    {
                        ["padding-bottom"] = "10px",
                        ["height"] = "40px"
                    }
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"headerTemplate\":{\"style\":{\"padding-bottom\":\"10px\",\"height\":\"40px\"}}}",
                json);
        }

        [TestMethod]
        public void Serialize_FooterTemplateStyle()
        {
            var options = new T
            {
                FooterTemplate = new HeaderFooterTemplate
                {
                    Style = new Dictionary<string, string>
                    {
                        ["padding-bottom"] = "10px",
                        ["height"] = "40px"
                    }
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"footerTemplate\":{\"style\":{\"padding-bottom\":\"10px\",\"height\":\"40px\"}}}",
                json);
        }

        [TestMethod]
        public void Serialize_HeaderTemplateImageStyle()
        {
            var options = new T
            {
                HeaderTemplate = new HeaderFooterTemplate
                {
                    ImageStyle = new Dictionary<string, string>
                    {
                        ["padding-bottom"] = "10px",
                        ["height"] = "40px"
                    }
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"headerTemplate\":{\"imageStyle\":{\"padding-bottom\":\"10px\",\"height\":\"40px\"}}}",
                json);
        }

        [TestMethod]
        public void Serialize_FooterTemplateImageStyle()
        {
            var options = new T
            {
                FooterTemplate = new HeaderFooterTemplate
                {
                    ImageStyle = new Dictionary<string, string>
                    {
                        ["padding-bottom"] = "10px",
                        ["height"] = "40px"
                    }
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"footerTemplate\":{\"imageStyle\":{\"padding-bottom\":\"10px\",\"height\":\"40px\"}}}",
                json);
        }

        [TestMethod]
        public void Serialize_HeaderTemplateTemplate()
        {
            var options = new T
            {
                HeaderTemplate = new HeaderFooterTemplate
                {
                    Template = "Test template"
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"headerTemplate\":{\"template\":\"Test template\"}}",
                json);
        }

        [TestMethod]
        public void Serialize_FooterTemplateTemplate()
        {
            var options = new T
            {
                FooterTemplate = new HeaderFooterTemplate
                {
                    Template = "Test template"
                }
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"footerTemplate\":{\"template\":\"Test template\"}}",
                json);
        }
        
        [TestMethod]
        public void Serialize_PrintBackground()
        {
            var options = new T
            {
                PrintBackground = true
            };
            var json = ClSerializer.Serialize(options);
            Assert.AreEqual(
                "{\"printBackground\":true}",
                json);
        }
    }
}