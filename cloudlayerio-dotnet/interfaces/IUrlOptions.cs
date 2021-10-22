namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    /// Options for URL based endpoints.
    /// </summary>
    public interface IUrlOptions
    {
        /// <summary>
        /// Source Url used for generating output document.
        /// </summary>
        public string Url { get; set; }
    }
}