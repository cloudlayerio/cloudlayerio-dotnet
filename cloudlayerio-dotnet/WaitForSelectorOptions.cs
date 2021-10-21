using cloudlayerio_dotnet.interfaces;
using Newtonsoft.Json;

namespace cloudlayerio_dotnet
{
    /// <inheritdoc cref="IWaitForSelectorOptions" />
    public class WaitForSelectorOptions : IWaitForSelectorOptions
    {
        [JsonProperty(PropertyName = "visible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Visible { get; set; }

        [JsonProperty(PropertyName = "hidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty(PropertyName = "timeout", NullValueHandling = NullValueHandling.Ignore)]
        public int? Timeout { get; set; }
    }
}