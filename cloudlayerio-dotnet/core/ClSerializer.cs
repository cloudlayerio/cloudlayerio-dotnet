using System.Text.Json;
using System.Text.Json.Serialization;
using cloudlayerio_dotnet.interfaces;

namespace cloudlayerio_dotnet.core
{
    public static class ClSerializer
    {
        public static string Serialize<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new ImageTypeEnumConverter(),
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                    new ToStringConverter<ILayoutDimension>(),
                    new ToStringConverter<IPageRanges>()
                }
            });

            return json;
        }

        public static T Deserialize<T>(string json) where T : class
        {
            var obj = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                    new ImageTypeEnumConverter(),
                    new InterfaceConverter<IViewport>(),
                    new DateTimeConverter()
                },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return obj;
        }
    }
}