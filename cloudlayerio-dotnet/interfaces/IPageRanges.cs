namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    ///     Paper ranges to print, e.g., '1-5, 8, 11-13'. Defaults to the empty string, which means print all pages.
    /// </summary>
    public interface IPageRanges
    {
        /// <summary>
        ///     Starting page number.
        /// </summary>
        public int From { get; set; }

        /// <summary>
        ///     Ending page number.
        /// </summary>
        public int To { get; set; }
    }
}