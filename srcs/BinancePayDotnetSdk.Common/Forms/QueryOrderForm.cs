using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class QueryOrderForm : ApiRequestForm
    {
        /// <summary>
        /// Binance unique order id
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
    }
}