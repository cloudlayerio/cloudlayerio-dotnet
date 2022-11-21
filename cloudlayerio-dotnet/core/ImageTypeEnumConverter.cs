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
            if (!Enum.TryParse(reader.GetString(), true, out ImageType result))
                throw new Exception("Could not read value");
            
            return result;
        }

        public override void Write(Utf8JsonWriter writer, ImageType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToLower());
        }
    }
}