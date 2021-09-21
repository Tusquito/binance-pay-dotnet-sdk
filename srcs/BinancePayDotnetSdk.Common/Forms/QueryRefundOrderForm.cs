using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-refund-query#request-parameters
    /// </summary>
    public class QueryRefundOrderForm : ApiRequestForm
    {
        /// <summary>
        /// The unique ID assigned by the merchant to identify a refund request.
        /// Maximum length 64.
        /// </summary>
        [JsonPropertyName("refundRequestId")]
        public string RefundRequestId { get; set; }
    }
}