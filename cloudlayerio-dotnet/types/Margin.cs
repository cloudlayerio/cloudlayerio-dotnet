using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.types
{
    public class Margin : IMargin
    {
        public ILayoutDimension Left { get; set; }
        
        public ILayoutDimension Right { get; set; }
        
        public ILayoutDimension Top { get; set; }
        
        public ILayoutDimension Bottom { get; set; }
    }
}