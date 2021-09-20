using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class ApiMerchantRequestForm : ApiRequestForm
    {
        /// <summary>
        /// The merchant account id, issued when merchant been created at Binance.
        /// </summary>
        [JsonPropertyName("merchantId")]
        public string MerchantId { get; set; }
    }
}