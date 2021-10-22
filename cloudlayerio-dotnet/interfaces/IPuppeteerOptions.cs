using cloudlayerio_dotnet.core;

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
        public bool? PreferCssPageSize { get; set; }

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
    }
}