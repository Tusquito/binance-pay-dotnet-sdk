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
            var readerValue = reader.GetString();

            if (reader.TokenType == JsonTokenType.String && double.TryParse(readerValue, NumberStyles.Any, CultureInfo.InvariantCulture,
                out double doubleValue))
            {
                return doubleValue;
            }

            throw new JsonException("This string value can't be converted to double.");
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}