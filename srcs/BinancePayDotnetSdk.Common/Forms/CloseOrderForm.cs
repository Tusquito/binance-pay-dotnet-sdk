using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class CloseOrderForm : ApiRequestForm
    {
        /// <summary>
        /// Binance unique order id.
        /// letter or digit, no other symbol allowed, can not be empty if merchantTradeNo is empty
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
    }
}