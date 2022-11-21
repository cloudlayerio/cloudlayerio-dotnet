using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using cloudlayerio_dotnet.interfaces;
using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.core
{
    public class InterfaceConverter<T> : JsonConverter<T> where T: class
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(IViewport))
            {
                return JsonSerializer.Deserialize<ViewPort>(ref reader, options) as T;
            }

            throw new Exception("Unknown type");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}