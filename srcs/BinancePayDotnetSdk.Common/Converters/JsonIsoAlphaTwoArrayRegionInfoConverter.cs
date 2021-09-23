using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Converters
{
    public class JsonIsoAlphaTwoArrayRegionInfoConverter : JsonConverter<RegionInfo[]>
    {
        public override RegionInfo[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException("This converter has to be used to convert string to RegionInfo");
            }
            
            try
            {
                string readerValue = reader.GetString();
                
                if (string.IsNullOrEmpty(readerValue))
                {
                    throw new Exception();
                }

                string[] splitValue = readerValue.Split(',');
                RegionInfo[] result = new RegionInfo[splitValue.Length];
                
                for (int i = 0; i < splitValue.Length; i++)
                {
                    result[i] = new RegionInfo(splitValue[i]);
                }

                return result;
            }
            catch (Exception)
            {
                throw new JsonException("This string can't be parse to RegionInfo");
            }
        }

        public override void Write(Utf8JsonWriter writer, RegionInfo[] value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Select(x => x.TwoLetterISORegionName).Aggregate((x,y) => $"{x},{y}"));
        }
    }
}