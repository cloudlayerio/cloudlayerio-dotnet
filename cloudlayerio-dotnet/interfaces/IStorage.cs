using System.IO;

namespace cloudlayerio_dotnet.core
{
    public interface IStorage
    {
        Stream GetFileStream(string filePath);
    }
}