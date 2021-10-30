using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.types
{
    public class ViewPort : IViewport
    {
        public int DeviceScaleFactor { get; set; }
        
        public bool HasTouch { get; set; }
        
        public int Height { get; set; }
        
        public bool IsLandscape { get; set; }
        
        public bool IsMobile { get; set; }
        
        public int Width { get; set; }
    }
}