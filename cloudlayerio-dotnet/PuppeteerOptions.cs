using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet
{
    /// <inheritdoc cref="IPuppeteerOptions"/>
    public class PuppeteerOptions : IPuppeteerOptions
    {
        public WaitUntilOptions? WaitUntil { get; set; }
        public IWaitForSelector WaitForSelector { get; set; }
        public bool? PreferCssPageSize { get; set; }
        public int? Scale { get; set; }
        public ILayoutDimension Height { get; set; }
        public ILayoutDimension Width { get; set; }
        public bool? Landscape { get; set; }
        public string PageRanges { get; set; }
        public bool? AutoScroll { get; set; }
    }
}