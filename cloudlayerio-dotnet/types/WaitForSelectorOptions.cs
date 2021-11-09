using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.types
{
    public class WaitForSelectorOptions : IWaitForSelectorOptions
    {
        public bool? Visible { get; set; }

        public bool? Hidden { get; set; }

        public int? Timeout { get; set; }
    }
}