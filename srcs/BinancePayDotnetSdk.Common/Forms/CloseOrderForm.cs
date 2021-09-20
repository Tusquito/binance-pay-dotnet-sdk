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
        /// letter or digit, no other symbol allowed, can not be empty if merchantTradeNo is empty
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
    }
}