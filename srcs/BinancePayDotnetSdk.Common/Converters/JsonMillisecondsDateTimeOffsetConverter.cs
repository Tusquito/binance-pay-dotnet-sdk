using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    internal class JsonMillisecondsDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long milliseconds))
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
            }
            
            throw new JsonException("This integer value can't be converted to DateTimeOffset"); 
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.ToUnixTimeMilliseconds());
        }
    }
}