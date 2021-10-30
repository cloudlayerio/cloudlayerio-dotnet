using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    ///     Options that are specific to Puppeteer endpoints.
    /// </summary>
    public interface IPuppeteerOptions
    {
        /// <inheritdoc cref="WaitUntilOptions" />
        public WaitUntilOptions? WaitUntil { get; set; }

        /// <inheritdoc cref="IWaitForSelector" />
        IWaitForSelector WaitForSelector { get; set; }

        /// <summary>
        ///     Give any CSS @page size declared in the page priority over what is declared
        ///     in width and height or format options.
        /// </summary>
        public bool? PreferCSSPageSize { get; set; }

        /// <summary>
        ///     Scale of the webpage rendering. Defaults to 1. Scale amount must be between 0.1 and 2.
        /// </summary>
        public float? Scale { get; set; }

        /// <summary>
        ///     Paper height.
        /// </summary>
        public ILayoutDimension Height { get; set; }

        /// <summary>
        ///     Paper width.
        /// </summary>
        public ILayoutDimension Width { get; set; }

        /// <summary>
        ///     Paper orientation, false sets it to portrait and true to landscape.
        /// </summary>
        public bool? Landscape { get; set; }

        /// <summary>
        ///     Paper ranges to print, e.g., '1-5, 8, 11-13'. Defaults to the empty string,
        ///     which means print all pages.
        /// </summary>
        public IPageRanges PageRanges { get; set; }

        /// <summary>
        ///     Will attempt to auto scroll the page down to the very end. Useful for forcing
        ///     lazy-loaded content to load.
        /// </summary>
        public bool? AutoScroll { get; set; }

        /// <summary>
        ///     Set the viewport options such as width, height, deviceScaleFactor, isMobile,
        ///     hasTouch, isLandscape.
        /// </summary>
        public IViewport ViewPort { get; set; }

        /// <summary>
        ///     Specify the timezone to emulate during page rendering.
        ///     For a list of available values see: <a href="https://source.chromium.org/chromium/chromium/deps/icu.git/+/faee8bc70570192d82d2978a71e2a615788597d1:source/data/misc/metaZones.txt">Available Timezones</a>
        /// </summary>
        /// <example>Asia/Hong_Kong</example>
        public string TimeZone { get; set; }
    }
}