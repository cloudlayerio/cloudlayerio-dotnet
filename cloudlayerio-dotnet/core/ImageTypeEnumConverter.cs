using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.core
{
    public class ImageTypeEnumConverter : JsonConverter<ImageType>
    {
        public override ImageType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, ImageType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToUpper());
        }
    }
}