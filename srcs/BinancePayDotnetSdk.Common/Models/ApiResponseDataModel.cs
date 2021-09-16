using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Models
{
    public class ApiResponseDataModel
    {
        [JsonPropertyName("merchantId")]
        public string MerchantId { get; set; }
    }
}