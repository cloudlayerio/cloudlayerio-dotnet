namespace cloudlayerio_dotnet.interfaces
{
    public interface IViewport
    {
        /// <summary>
        /// Specify device scale factor (like DPR). Defaults to 1.
        /// </summary>
        public int DeviceScaleFactor { get; set; }

        /// <summary>
        /// Specifies if viewport supports touch events. Defaults to false.
        /// </summary>
        public bool HasTouch { get; set; }

        /// <summary>
        /// Page height in pixels. (Required)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Specifies if viewport is in landscape mode. Defaults to false.
        /// </summary>
        public bool IsLandscape { get; set; }

        /// <summary>
        /// Whether the meta viewport tag is taken into account. Defaults to false.
        /// </summary>
        public bool IsMobile { get; set; }

        /// <summary>
        /// Page width in pixels. (Required)
        /// </summary>
        public int Width { get; set; }
    }
}