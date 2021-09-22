using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Models
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-refund-query#refundresult
    /// </summary>
    public class QueryRefundOrderResponseDataModel
    {
        /// <summary>
        /// The unique ID assigned by the merchant to identify a refund request.
        /// Maximum length 64.
        /// </summary>
        [JsonPropertyName("refundRequestId")]
        public string RefundRequestId { get; init; }
        /// <summary>
        /// The unique ID assigned by Binance for the original order to be refunded.
        /// Letter or digit, no other symbol allowed.
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; init; }
        /// <summary>
        /// The total amount of prepay order.
        /// Minimum unit: 0.01, minimum equivalent value: 0.5 USD.
        /// </summary>
        [JsonPropertyName("orderAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double OrderAmount { get; init; }
        /// <summary>
        /// The total refunded amount included this refund request.
        /// Minimum unit: 0.01, minimum equivalent value: 0.5 USD.
        /// </summary>
        [JsonPropertyName("refundedAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double RefundedAmount { get; init; }
        /// <summary>
        /// The refund amount of this refund request.
        /// Minimum unit: 0.01, minimum equivalent value: 0.5 USD.
        /// </summary>
        [JsonPropertyName("refundAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double RefundAmount { get; init; }
        /// <summary>
        /// The remaining attempts of this original order.
        /// If this value becomes 1, then your next refund request amount will be ignored.
        /// We will refund all the remaining amount of this original order.
        /// </summary>
        [JsonPropertyName("remainingAttempts")]
        [JsonConverter(typeof(JsonStringLongConverter))]
        public long RemainingAttempts { get; init; }
        /// <summary>
        /// The payer open id of this original order.
        /// </summary>
        [JsonPropertyName("payerOpenId")]
        public string PayerOpenId { get; init; }
        /// <summary>
        /// The status of this refund.
        /// Example: REFUND_SUCCESS,REFUND_FAIL,REFUND_PENDING
        /// </summary>
        [JsonPropertyName("refundStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RefundStatus RefundStatus { get; init; }
    }
}