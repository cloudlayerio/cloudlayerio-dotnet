using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet_test.types
{
    /// <inheritdoc cref="IWaitForSelector" />
    public class WaitForSelector : IWaitForSelector
    {
        /// <inheritdoc />
        public string Selector { get; set; }

        /// <inheritdoc />
        public IWaitForSelectorOptions Options { get; set; }
    }
}