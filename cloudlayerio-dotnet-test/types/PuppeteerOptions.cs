using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet_test.types
{
    /// <inheritdoc cref="IPuppeteerOptions" />
    public class PuppeteerOptions : IPuppeteerOptions
    {
        /// <inheritdoc />
        public WaitUntilOptions? WaitUntil { get; set; }

        /// <inheritdoc />
        public IWaitForSelector WaitForSelector { get; set; }

        /// <inheritdoc />
        public bool? PreferCSSPageSize { get; set; }

        /// <inheritdoc />
        public float? Scale { get; set; }

        /// <inheritdoc />
        public ILayoutDimension Height { get; set; }

        /// <inheritdoc />
        public ILayoutDimension Width { get; set; }

        /// <inheritdoc />
        public bool? Landscape { get; set; }

        /// <inheritdoc />
        public IPageRanges PageRanges { get; set; }

        /// <inheritdoc />
        public bool? AutoScroll { get; set; }
    }
}