using System.Text.Json.Serialization;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class ApiRequestForm
    {
        /// <summary>
        /// The merchant account id, issued when merchant been created at Binance.
        /// </summary>
        [JsonPropertyName("merchantId")]
        public string MerchantId { get; set; }
        /// <summary>
        /// The sub merchant account id, issued when sub merchant been created at Binance,
        /// The parameter subMerchantId is required when configuring show subMerchant info.
        /// </summary>
        [JsonPropertyName("subMerchantId")]
        public string SubMerchantId { get; set; }

        /// <summary>
        /// The order id, Unique identifier for the request.
        /// letter or digit, no other symbol allowed, maximum length 32
        /// </summary>
        [JsonPropertyName("merchantTradeNo")]
        public string MerchantTradeNo { get; set; }
    }
}