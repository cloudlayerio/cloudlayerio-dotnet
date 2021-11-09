using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cloudlayerio_dotnet.core
{
    public class ToStringConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value is bool)
            {
                var success = bool.TryParse(value.ToString(), out var boolVal);
                if (success) writer.WriteBooleanValue(boolVal);
            }
            else
            {
                writer.WriteStringValue(value?.ToString());
            }
        }
    }
}