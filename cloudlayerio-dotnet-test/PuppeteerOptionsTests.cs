using cloudlayerio_dotnet.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test
{
    [TestClass]
    public class PuppeteerOptionsTests
    {
        [TestMethod]
        public void Serialize_Empty()
        {
            var options = new PuppeteerOptions();
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{}", json);
        }

        [TestMethod]
        public void Serialize_HeightOnly()
        {
            var options = new PuppeteerOptions {Height = new LayoutDimension(UnitTypes.Pixels, 800)};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"height\":\"800px\"}", json);
        }

        [TestMethod]
        public void Serialize_WidthOnly()
        {
            var options = new PuppeteerOptions {Width = new LayoutDimension(UnitTypes.Pixels, 600)};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"width\":\"600px\"}", json);
        }

        [TestMethod]
        public void Serialize_LandscapeTrueOnly()
        {
            var options = new PuppeteerOptions {Landscape = true};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"landscape\":true}", json);
        }

        [TestMethod]
        public void Serialize_LandscapeFalseOnly()
        {
            var options = new PuppeteerOptions {Landscape = false};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"landscape\":false}", json);
        }

        [TestMethod]
        public void Serialize_ScaleOnly()
        {
            var options = new PuppeteerOptions {Scale = 0.4f};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"scale\":0.4}", json);
        }

        [TestMethod]
        public void Serialize_AutoScrollTrueOnly()
        {
            var options = new PuppeteerOptions {AutoScroll = true};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"autoScroll\":true}", json);
        }

        [TestMethod]
        public void Serialize_AutoScrollFalseOnly()
        {
            var options = new PuppeteerOptions {AutoScroll = false};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"autoScroll\":false}", json);
        }

        [TestMethod]
        public void Serialize_PageRangesOnly()
        {
            var options = new PuppeteerOptions {PageRanges = new PageRanges(1, 4)};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"pageRanges\":\"1-4\"}", json);
        }

        [TestMethod]
        public void Serialize_WaitUntilOnly()
        {
            var options = new PuppeteerOptions {WaitUntil = WaitUntilOptions.networkidle0};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"waitUntil\":\"networkidle0\"}", json);
        }

        [TestMethod]
        public void Serialize_WaitForSelectorSelectorOnly()
        {
            var options = new PuppeteerOptions
            {
                WaitForSelector = new WaitForSelector
                {
                    Selector = "#test"
                }
            };
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"waitForSelector\":{\"selector\":\"#test\"}}", json);
        }

        [TestMethod]
        public void Serialize_WaitForSelectorOptionsVisibleTrueOnly()
        {
            var options = new PuppeteerOptions
            {
                WaitForSelector = new WaitForSelector
                {
                    Selector = "#test",
                    Options = new WaitForSelectorOptions
                    {
                        Visible = true
                    }
                }
            };
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"waitForSelector\":{\"selector\":\"#test\",\"options\":{\"visible\":true}}}", json);
        }

        [TestMethod]
        public void Serialize_WaitForSelectorOptionsHiddenTrueOnly()
        {
            var options = new PuppeteerOptions
            {
                WaitForSelector = new WaitForSelector
                {
                    Selector = "#test",
                    Options = new WaitForSelectorOptions
                    {
                        Hidden = true
                    }
                }
            };
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"waitForSelector\":{\"selector\":\"#test\",\"options\":{\"hidden\":true}}}", json);
        }

        [TestMethod]
        public void Serialize_WaitForSelectorOptionsTimeoutTrueOnly()
        {
            var options = new PuppeteerOptions
            {
                WaitForSelector = new WaitForSelector
                {
                    Selector = "#test",
                    Options = new WaitForSelectorOptions
                    {
                        Timeout = 3000
                    }
                }
            };
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"waitForSelector\":{\"selector\":\"#test\",\"options\":{\"timeout\":3000}}}", json);
        }

        [TestMethod]
        public void Serialize_PreferCssPageSizeTrueOnly()
        {
            var options = new PuppeteerOptions {PreferCssPageSize = true};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"preferCSSPageSize\":true}", json);
        }

        [TestMethod]
        public void Serialize_PreferCssPageSizeFalseOnly()
        {
            var options = new PuppeteerOptions {PreferCssPageSize = false};
            var json = RequestSerializer.Serialize(options);
            Assert.AreEqual("{\"preferCSSPageSize\":false}", json);
        }
    }
}