using System.Net.Http;
using cloudlayerio_dotnet.core;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.requests
{
    public class UrlToImage : 
        IOptions, IUrlOptions, IPuppeteerOptions, IImageOptions, IEndpointPath
    {
        public string Path => "url/image";

        public ImageType? ImageType { get; set; }
        
        public int? Timeout { get; set; }
        
        public int? Delay { get; set; }
        public string Filename { get; set; }
        public bool? Inline { get; set; }
        public WaitUntilOptions? WaitUntil { get; set; }
        public IWaitForSelector WaitForSelector { get; set; }
        public bool? PreferCssPageSize { get; set; }
        public float? Scale { get; set; }
        public ILayoutDimension Height { get; set; }
        public ILayoutDimension Width { get; set; }
        public bool? Landscape { get; set; }
        public IPageRanges PageRanges { get; set; }
        public bool? AutoScroll { get; set; }
        public string Url { get; set; }
    }
}