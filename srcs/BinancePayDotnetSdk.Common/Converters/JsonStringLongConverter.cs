using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    public class JsonStringLongConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && long.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture,
                out long longResult))
            {
                return longResult;
            }

            try
            {
                if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out longResult))
                {
                    return longResult;
                }
            }
            catch
            {
                throw new JsonException("This string value can't be converted to long.");
            }
            throw new JsonException("This string value can't be converted to long.");
            
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}