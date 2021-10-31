namespace cloudlayerio_dotnet.types
{
    /// <summary>
    ///     Specifies the header and footer templating method to use.
    /// </summary>
    public enum HeaderFooterTemplateMethod
    {
        /// <summary>
        ///     The default templating method that Puppeteer uses out of the box.
        /// </summary>
        template,

        /// <summary>
        ///     Extract the footer from the body and convert to an embedded header/footer template.
        /// </summary>
        extract
    }
}