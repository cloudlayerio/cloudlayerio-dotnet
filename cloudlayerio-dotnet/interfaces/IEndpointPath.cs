using System.Text.Json.Serialization;

namespace cloudlayerio_dotnet.interfaces
{
    public interface IEndpointPath
    {
        [JsonIgnore] public string Path { get; }
    }
}