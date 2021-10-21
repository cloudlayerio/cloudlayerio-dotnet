using System.ComponentModel.DataAnnotations;
using cloudlayerio_dotnet.interfaces;
using Newtonsoft.Json;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc cref="IWaitForSelector" />
    public class WaitForSelector : IWaitForSelector
    {
        /// <inheritdoc />
        [Required]
        [JsonProperty(PropertyName = "selector", NullValueHandling = NullValueHandling.Ignore)]
        public string Selector { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "options", NullValueHandling = NullValueHandling.Ignore)]
        public IWaitForSelectorOptions Options { get; set; }
    }
}