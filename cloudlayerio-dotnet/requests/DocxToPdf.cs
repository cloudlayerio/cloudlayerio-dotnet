using System.Text.Json.Serialization;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.requests
{
    public class DocxToPdf :
        IOptions, IUrlOptions, IFileOptions, IEndpointPath
    {
        [JsonIgnore] public string Path => "docx/pdf";

        [JsonIgnore] public string FilePath { get; set; }

        public int? Timeout { get; set; }
        public int? Delay { get; set; }
        public string Filename { get; set; }
        public bool? Inline { get; set; }
        
        public bool? Async { get; set; }
        public string Url { get; set; }
    }
}