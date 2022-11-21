using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using cloudlayerio_dotnet.types;

namespace cloudlayerio_dotnet.core;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var unixTime = reader.GetInt64();
        var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTime).DateTime;

        return dateTime;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var unixTime = new DateTimeOffset(value).ToUnixTimeMilliseconds();
        writer.WriteNumberValue(unixTime);
    }
}