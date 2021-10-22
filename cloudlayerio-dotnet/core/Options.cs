using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.core
{
    /// <inheritdoc />
    public class Options : IOptions
    {
        /// <inheritdoc />
        public int? Timeout { get; set; }

        /// <inheritdoc />
        public int? Delay { get; set; }

        /// <inheritdoc />
        public string Filename { get; set; }

        /// <inheritdoc />
        public bool? Inline { get; set; }
    }
}