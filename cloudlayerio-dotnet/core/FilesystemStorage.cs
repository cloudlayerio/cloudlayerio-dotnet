using System.IO;

namespace cloudlayerio_dotnet.core
{
    public class FilesystemStorage : IStorage
    {
        /// <summary>
        ///     Creates a Filesystem Storage stream. By default this overwrites existing files.
        /// </summary>
        /// <param name="filePath">Filepath to create the stream.</param>
        /// <returns>Filestream for the filepath</returns>
        public Stream GetFileStream(string filePath)
        {
            return new FileStream(filePath, FileMode.Create);
        }
    }
}