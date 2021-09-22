using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class ApiSubMerchantRequestForm : ApiMerchantRequestForm
    {
        /// <summary>
        /// The sub merchant account id, issued when sub merchant been created at Binance,
        /// The parameter subMerchantId is required when configuring show subMerchant info.
        /// </summary>
        [JsonPropertyName("subMerchantId")]
        [JsonConverter(typeof(JsonStringLongConverter))]
        public long SubMerchantId { get; set; }

        /// <summary>
        /// The order id, Unique identifier for the request.
        /// Letter or digit, no other symbol allowed, maximum length 32.
        /// </summary>
        [JsonPropertyName("merchantTradeNo")]
        public string MerchantTradeNo { get; set; }
    }
}