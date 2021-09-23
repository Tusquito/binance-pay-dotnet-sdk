using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-create#request-parameters
    /// </summary>
    public class CreateOrderForm : ApiRequestForm
    {
        /// <summary>
        /// The merchant account id, issued when merchant been created at Binance.
        /// </summary>
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
        [Required]
        [JsonPropertyName("merchantTradeNo")]
        public string MerchantTradeNo { get; set; }
        
        /// <summary>
        /// Operate entrance.
        /// </summary>
        [Required]
        [JsonPropertyName("tradeType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TradeType TradeType { get; set; } = TradeType.APP;
        
        /// <summary>
        /// Order amount.
        /// minimum unit: 0.01, minimum equivalent value: 0.5 USD
        /// </summary>
        [Required]
        [JsonPropertyName("totalFee")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double TotalFee { get; set; }

        /// <summary>
        /// Order currency.
        /// Only crypto token accepted, fiat NOT supported.
        /// </summary>
        [Required]
        [JsonPropertyName("currency")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrencyType Currency { get; set; } = CurrencyType.BUSD;

        [Required]
        [MaxLength(16)]
        [JsonPropertyName("productType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductType ProductType { get; set; } = ProductType.Test;

        [Required]
        [MaxLength(256)]
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        
        [MaxLength(256)]
        [JsonPropertyName("productDetail")]
        public string ProductDetail { get; set; }
        
        /// <summary>
        /// Redirect Url.
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("returnUrl")]
        public string ReturnUrl { get; set; } = string.Empty;
    }
}