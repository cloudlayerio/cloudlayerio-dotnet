using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet_test.types
{
    /// <inheritdoc cref="IWaitForSelectorOptions" />
    public class WaitForSelectorOptions : IWaitForSelectorOptions
    {
        /// <inheritdoc />
        public bool? Visible { get; set; }

        /// <inheritdoc />
        public bool? Hidden { get; set; }

        /// <inheritdoc />
        public int? Timeout { get; set; }
    }
}