using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.types
{
    /// <inheritdoc />
    public class PageRanges : IPageRanges
    {
        /// <summary>
        ///     Defines a page range.
        /// </summary>
        /// <param name="from">Starting page number.</param>
        /// <param name="to">Ending page number.</param>
        public PageRanges(int from, int to)
        {
            From = from;
            To = to;
        }

        /// <inheritdoc />
        public int From { get; set; }

        /// <inheritdoc />
        public int To { get; set; }

        public override string ToString()
        {
            return $"{From}-{To}";
        }
    }
}