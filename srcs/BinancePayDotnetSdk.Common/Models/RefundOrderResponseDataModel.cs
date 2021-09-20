﻿using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Models
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-refund#refundresult
    /// </summary>
    public class RefundOrderResponseDataModel
    {
        /// <summary>
        /// The unique ID assigned by the merchant to identify a refund request.
        /// Maximum length 64.
        /// </summary>
        [JsonPropertyName("refundRequestId")]
        public string RefundRequestId { get; set; }
        /// <summary>
        /// The unique ID assigned by Binance for the original order to be refunded.
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
        /// <summary>
        /// The total amount of prepay order.
        /// Minimum unit: 0.01, minimum equivalent value: 0.5 USD.
        /// </summary>
        [JsonPropertyName("orderAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double OrderAmount { get; set; }
        /// <summary>
        /// The total refunded amount included this refund request.
        /// </summary>
        [JsonPropertyName("refundedAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double RefundedAmount { get; set; }
        /// <summary>
        /// The refund amount of this refund request.
        /// </summary>
        [JsonPropertyName("refundAmount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double RefundAmount { get; set; }
        /// <summary>
        /// The remaining attempts of this original order.
        /// If this value becomes 1, then your next refund request amount will be ignored.
        /// Binance will refund all the remaining amount of this original order.
        /// </summary>
        [JsonPropertyName("remainingAttempts")]
        [JsonConverter(typeof(JsonStringIntConverter))]
        public int RemainingAttempts { get; set; }
        /// <summary>
        /// The payer open id of this original order.
        /// </summary>
        [JsonPropertyName("payerOpenId")]
        public string PayerOpenId { get; set; }
        /// <summary>
        /// The flag to mark this request refundRequestId is duplicate or not. It will be 'Y' or 'N'
        /// </summary>
        [JsonPropertyName("duplicateRequest")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DuplicateRequestFlag DuplicateRequestFlag { get; set; }
    }
}