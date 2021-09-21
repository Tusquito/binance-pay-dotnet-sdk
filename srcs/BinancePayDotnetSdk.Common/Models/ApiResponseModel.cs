using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Models
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-create#response-parameters
    /// </summary>
    public class ApiResponseModel<TData>
    {
        /// <summary>
        /// "SUCCESS" or "FAIL"
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("status")]
        public ResponseStatus Status { get; init; }
        /// <summary>
        /// refer to https://developers.binance.com/docs/binance-pay/api-order-query#result-code
        /// </summary>
        [JsonPropertyName("code")] 
        [JsonConverter(typeof(JsonEnumIntConverter<ResponseResultCode>))]
        public ResponseResultCode Code { get; init; }
        [JsonPropertyName("data")]
        public TData Data { get; init; }
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; init; }
    }
}