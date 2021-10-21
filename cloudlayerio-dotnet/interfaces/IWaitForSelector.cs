namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    /// Wait for selector options for puppeteer. This lets you wait for specific criteria to be met before 
    /// conversion to help ensure the page is done rendering.
    /// </summary>
    public interface IWaitForSelector
    {
        /// <summary>
        /// A selector of an element on the page to wait for until starting conversion.
        /// </summary>
        public string Selector { get; set; }

        /// <inheritdoc cref="IWaitForSelectorOptions" />
        public IWaitForSelectorOptions Options { get; set; }
    }
}
