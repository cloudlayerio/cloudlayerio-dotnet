using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.types
{
    public class WaitForSelector : IWaitForSelector
    {
        public string Selector { get; set; }

        public IWaitForSelectorOptions Options { get; set; }
    }
}