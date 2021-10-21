using cloudlayerio_dotnet.interfaces;
using Newtonsoft.Json;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc cref="IPuppeteerOptions" />
    public class PuppeteerOptions : IPuppeteerOptions
    {
        [JsonProperty(PropertyName = "waitUntil", NullValueHandling = NullValueHandling.Ignore)]
        private string WaitUntilString => WaitUntil?.ToString();

        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        private string HeightString => Height?.ToString();

        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        private string WidthString => Width?.ToString();

        [JsonProperty(PropertyName = "pageRanges", NullValueHandling = NullValueHandling.Ignore)]
        private string PageRangesString => PageRanges?.ToString();

        /// <inheritdoc />
        [JsonIgnore]
        public WaitUntilOptions? WaitUntil { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "waitForSelector", NullValueHandling = NullValueHandling.Ignore)]
        public IWaitForSelector WaitForSelector { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "preferCSSPageSize", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PreferCssPageSize { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "scale", NullValueHandling = NullValueHandling.Ignore)]
        public float? Scale { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public ILayoutDimension Height { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public ILayoutDimension Width { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "landscape", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Landscape { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public IPageRanges PageRanges { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "autoScroll", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoScroll { get; set; }
    }
}