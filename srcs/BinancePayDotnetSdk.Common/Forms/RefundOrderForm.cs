using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-refund#request-parameters
    /// </summary>
    public class RefundOrderForm : ApiRequestForm
    {
        /// <summary>
        /// The unique ID assigned by the merchant to identify a refund request.The value must be same for one refund request.
        /// Maximum length 64.
        /// </summary>
        [JsonPropertyName("refundRequestId")]
        public string RefundRequestId { get; set; }
        /// <summary>
        /// The unique ID assigned by Binance for the original order to be refunded.
        /// Letter or digit, no other symbol allowed.
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
        /// <summary>
        /// The refund amount that is initiated by the merchant.
        /// </summary>
        [JsonPropertyName("refundAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double RefundAmount { get; set; }
        /// <summary>
        /// Maximum length 256.
        /// </summary>
        [JsonPropertyName("refundReason")]
        public string RefundReason { get; set; }
    }
}