﻿using Newtonsoft.Json;

namespace cloudlayerio_dotnet
{
    /// <inheritdoc />
    class Options : IOptions
    {
        /// <inheritdoc />
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "delay", NullValueHandling = NullValueHandling.Ignore)]
        public int? Delay { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        /// <inheritdoc />
        [JsonProperty(PropertyName = "inline", NullValueHandling = NullValueHandling.Ignore)]
        public bool Inline { get; set; }
    }
}
