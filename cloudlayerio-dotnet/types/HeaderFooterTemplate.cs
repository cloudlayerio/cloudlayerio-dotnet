using System.Collections.Generic;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.types
{
    public class HeaderFooterTemplate : IHeaderFooterTemplate
    {
        public HeaderFooterTemplateMethod? Method { get; set; }
        public string Selector { get; set; }
        public Margin Margin { get; set; }
        public IDictionary<string, string> Style { get; set; }
        public IDictionary<string, string> ImageStyle { get; set; }
        public string Template { get; set; }
    }
}