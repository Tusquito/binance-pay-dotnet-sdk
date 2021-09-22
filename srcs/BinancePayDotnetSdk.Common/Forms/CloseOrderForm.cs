using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-close#request-parameters
    /// </summary>
    public class CloseOrderForm : ApiSubMerchantRequestForm
    {
        /// <summary>
        /// Binance unique order id.
        /// Letter or digit, no other symbol allowed.
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
    }
}