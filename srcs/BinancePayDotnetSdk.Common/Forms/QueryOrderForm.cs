using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-query#request-parameters
    /// </summary>
    public class QueryOrderForm : ApiSubMerchantRequestForm
    {
        /// <summary>
        /// Binance unique order id
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
    }
}