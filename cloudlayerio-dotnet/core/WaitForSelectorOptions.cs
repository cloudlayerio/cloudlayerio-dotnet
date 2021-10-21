using cloudlayerio_dotnet.interfaces;
using Newtonsoft.Json;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc cref="IWaitForSelectorOptions" />
    public class WaitForSelectorOptions : IWaitForSelectorOptions
    {
        /// <inheritdoc />
        [JsonProperty(PropertyName = "visible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Visible { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "hidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "timeout", NullValueHandling = NullValueHandling.Ignore)]
        public int? Timeout { get; set; }
    }
}