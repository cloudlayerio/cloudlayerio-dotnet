namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    ///     Paper margins for left, right, top, bottom
    /// </summary>
    public interface IMargin
    {
        /// <summary>
        ///     Left margin (in, px, cm, mm) Default: 0.4in
        /// </summary>
        public ILayoutDimension Left { get; set; }

        /// <summary>
        ///     Right margin (in, px, cm, mm) Default: 0.39in
        /// </summary>
        public ILayoutDimension Right { get; set; }

        /// <summary>
        ///     Top margin (in, px, cm, mm) Default: 0.4in
        /// </summary>
        public ILayoutDimension Top { get; set; }

        /// <summary>
        ///     Bottom margin (in, px, cm, mm) Default: 0.39in
        /// </summary>
        public ILayoutDimension Bottom { get; set; }
    }
}