using System.Text.Json.Serialization;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc cref="IPuppeteerOptions" />
    public class PuppeteerOptions : IPuppeteerOptions
    {
        /// <inheritdoc />
        public WaitUntilOptions? WaitUntil { get; set; }

        /// <inheritdoc />
        public IWaitForSelector WaitForSelector { get; set; }

        /// <inheritdoc />
        [JsonConverter(typeof(ToStringConverter<bool>))]
        [JsonPropertyName("preferCSSPageSize")]
        public bool? PreferCssPageSize { get; set; }

        /// <inheritdoc />
        public float? Scale { get; set; }

        /// <inheritdoc />
        [JsonConverter(typeof(ToStringConverter<ILayoutDimension>))]
        public ILayoutDimension Height { get; set; }

        /// <inheritdoc />
        [JsonConverter(typeof(ToStringConverter<ILayoutDimension>))]
        public ILayoutDimension Width { get; set; }

        /// <inheritdoc />
        public bool? Landscape { get; set; }

        /// <inheritdoc />
        [JsonConverter(typeof(ToStringConverter<IPageRanges>))]
        public IPageRanges PageRanges { get; set; }

        /// <inheritdoc />
        public bool? AutoScroll { get; set; }
    }
}