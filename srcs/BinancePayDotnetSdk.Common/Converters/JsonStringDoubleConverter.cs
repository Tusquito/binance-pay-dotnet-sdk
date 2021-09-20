using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    public class JsonStringDoubleConverter: JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && double.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture,
                out double doubleValue))
            {
                return doubleValue;
            }

            try
            {
                if (reader.TokenType == JsonTokenType.Number && reader.TryGetDouble(out doubleValue))
                {
                    return doubleValue;
                }
            }
            catch
            {
                throw new JsonException("This string value can't be converted to double.");
            }
            throw new JsonException("This string value can't be converted to double.");
            
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}