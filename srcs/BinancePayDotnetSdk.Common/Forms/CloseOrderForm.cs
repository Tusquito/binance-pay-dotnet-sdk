using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-close#request-parameters
    /// </summary>
    public class CloseOrderForm : ApiRequestForm
    {
        /// <summary>
        /// The merchant account id, issued when merchant been created at Binance.
        /// </summary>
        [Required]
        [JsonPropertyName("merchantId")]
        [JsonConverter(typeof(JsonStringLongConverter))]
        public long MerchantId { get; set; }
        
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
        
        /// <summary>
        /// Binance unique order id.
        /// Letter or digit, no other symbol allowed.
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
    }
}