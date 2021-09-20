using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    public class JsonStringIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture,
                out int intValue))
            {
                return intValue;
            }

            try
            {
                if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out intValue))
                {
                    return intValue;
                }
            }
            catch
            {
                throw new JsonException("This string value can't be converted to int.");
            }
            throw new JsonException("This string value can't be converted to int.");
            
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}