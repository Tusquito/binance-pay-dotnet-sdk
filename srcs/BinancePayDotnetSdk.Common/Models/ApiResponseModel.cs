using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Models
{
    public class ApiResponseModel<TData>
    {
        /// <summary>
        /// "SUCCESS" or "FAIL"
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("status")]
        public ResponseStatus Status { get; set; }
        /// <summary>
        /// refer to https://developers.binance.com/docs/binance-pay/api-order-query#result-code
        /// </summary>
        [JsonPropertyName("code")] 
        public string Code { get; set; }
        [JsonPropertyName("data")]
        public TData Data { get; set; }
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}