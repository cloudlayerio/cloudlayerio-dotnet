using System.Text.Json.Serialization;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.requests
{
    public class UrlToImage :
        IOptions, IUrlOptions, IImageOptions, IPuppeteerOptions, IEndpointPath
    {
        [JsonIgnore] public string Path => "url/image";

        public ImageType? ImageType { get; set; }

        public int? Timeout { get; set; }
        public int? Delay { get; set; }
        public string Filename { get; set; }
        public bool? Inline { get; set; }
        public WaitUntilOptions? WaitUntil { get; set; }
        public IWaitForSelector WaitForSelector { get; set; }
        public bool? PreferCSSPageSize { get; set; }
        public float? Scale { get; set; }
        public ILayoutDimension Height { get; set; }
        public ILayoutDimension Width { get; set; }
        public bool? Landscape { get; set; }
        public IPageRanges PageRanges { get; set; }
        public bool? AutoScroll { get; set; }
        public IViewport ViewPort { get; set; }
        public string TimeZone { get; set; }
        public string Url { get; set; }
    }
}