namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    ///     This is a non-serialized class, treated special due to the requirements around multipart/form-data
    /// </summary>
    public interface IFileOptions
    {
        /// <summary>
        ///     Path to the file on filesystem.
        /// </summary>
        public string FilePath { get; set; }
    }
}