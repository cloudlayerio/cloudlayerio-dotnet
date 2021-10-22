using System.Text.Json;
using System.Text.Json.Serialization;

namespace cloudlayerio_dotnet.core
{
    public static class RequestSerializer
    {
        public static string Serialize<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                    
                }
            });

            return json;
        }

        public static T Deserialize<T>(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}