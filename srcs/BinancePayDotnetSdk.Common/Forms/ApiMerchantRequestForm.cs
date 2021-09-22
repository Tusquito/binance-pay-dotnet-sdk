using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class ApiMerchantRequestForm : ApiRequestForm
    {
        /// <summary>
        /// The merchant account id, issued when merchant been created at Binance.
        /// </summary>
        [JsonPropertyName("merchantId")]
        [JsonConverter(typeof(JsonStringLongConverter))]
        public long MerchantId { get; set; }
    }
}