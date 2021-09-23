using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    public class JsonIsoAlphaTwoRegionInfoConverter : JsonConverter<RegionInfo>
    {
        public override RegionInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException("This converter has to be used to convert string to RegionInfo.");
            }

            try
            {
                string readerValue = reader.GetString();
                
                if (string.IsNullOrEmpty(readerValue))
                {
                    throw new Exception();
                    
                }
                return new RegionInfo(readerValue);
            }
            catch (Exception)
            {
                throw new JsonException("This string can't be parsed to RegionInfo.");
            }
        }

        public override void Write(Utf8JsonWriter writer, RegionInfo value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.TwoLetterISORegionName);
        }
    }
}