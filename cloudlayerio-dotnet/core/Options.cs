using cloudlayerio_dotnet.interfaces;
using Newtonsoft.Json;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc />
    public class Options : IOptions
    {
        /// <inheritdoc />
        [JsonProperty(PropertyName = "timeout", NullValueHandling = NullValueHandling.Ignore)]
        public int? Timeout { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "delay", NullValueHandling = NullValueHandling.Ignore)]
        public int? Delay { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "inline", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Inline { get; set; }
    }
}