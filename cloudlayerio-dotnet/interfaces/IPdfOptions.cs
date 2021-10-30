using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.interfaces
{
    public interface IPdfOptions
    {
        /// <summary>
        /// Specifies whether or not to print background graphics.
        /// </summary>
        public bool? PrintBackground { get; set; }
        
        /// <summary>
        /// Paper format to render the PDF.
        /// (letter, legal, tabloid, ledger, a0, a1, a2, a3, a4, a5, a6)
        /// </summary>
        public PDFFormat? Format { get; set; }

        /// <summary>
        /// Paper margins for the PDF.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Header options for PDF.
        /// </summary>
        public IHeaderFooterTemplate HeaderTemplate { get; set; }

        /// <summary>
        /// Footer options for PDF.
        /// </summary>
        public IHeaderFooterTemplate FooterTemplate { get; set; }
    }
}