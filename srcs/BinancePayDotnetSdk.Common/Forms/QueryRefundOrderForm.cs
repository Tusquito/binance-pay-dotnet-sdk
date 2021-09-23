using System.ComponentModel.DataAnnotations;
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
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("refundRequestId")]
        public string RefundRequestId { get; set; }
    }
}