using System.IO;
using cloudlayerio_dotnet.core;

namespace cloudlayerio_dotnet_test.fakes
{
    public class FakeFileStorage : IStorage
    {
        private readonly MemoryStream _stream;

        public FakeFileStorage()
        {
            _stream = new MemoryStream();
        }

        public Stream GetFileStream(string filePath)
        {
            return _stream;
        }
    }
}