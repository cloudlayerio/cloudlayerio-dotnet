using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.core
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