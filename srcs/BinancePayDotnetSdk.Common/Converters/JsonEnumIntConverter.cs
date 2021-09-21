using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    internal class JsonEnumIntConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is JsonTokenType.Number or JsonTokenType.String)
            {
                var enumDic = Enum.GetValues(typeof(T)).Cast<int>()
                    .ToDictionary(item => item, item => Enum.GetName(typeof(T), item));

                if (int.TryParse(reader.GetString(), out int enumValue) || reader.TryGetInt32(out enumValue))
                {
                    if (enumDic.TryGetValue(enumValue, out string enumName))
                    {
                        return (T) Enum.Parse(typeof(T), enumName);
                    }
                }

                throw new JsonException($"{reader.GetString()} is not a {typeof(T).Name} value.");
            }

            throw new JsonException($"This integer value can't be converted to {typeof(T).Name}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Convert.ToInt32(value));
        }
    }
}