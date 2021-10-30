using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.interfaces
{
    public interface IHeaderFooterTemplate
    {
        /// <summary>
        /// Header/Footer Templating style to use.
        /// </summary>
        public HeaderFooterTemplateMethod Method { get; set; }

        /// <summary>
        /// If using 'extract' method used to specify the selector to use to extract
        /// the header/footer from the body.
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// Specifies the margin for the header/footer.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Any Css Styles to inject into the header/footer.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Any Css styles to inject into the header/footer for any embedded images.
        /// </summary>
        public string ImageStyle { get; set; }

        /// <summary>
        /// If using 'template' method this is the string template to use. Ignored if method is
        /// set to 'extract'.
        /// </summary>
        public string Template { get; set; }
    }
}