using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class CreateOrderForm : ApiRequestForm
    {
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
        /// <summary>
        /// Order amount.
        /// minimum unit: 0.01, minimum equivalent value: 0.5 USD
        /// </summary>
        [JsonPropertyName("totalFee")]
        public double TotalFee { get; set; }
        /// <summary>
        /// maximum length 256
        /// </summary>
        [JsonPropertyName("productDetail")]
        public string ProductDetail { get; set; }
        /// <summary>
        /// Order currency, e.g. "BUSD".
        /// Only crypto token accepted, fiat NOT supported.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("currency")]
        public CurrencyType Currency { get; set; } = CurrencyType.BUSD;
        /// <summary>
        /// Redirect Url.
        /// maximum length 256
        /// </summary>
        [JsonPropertyName("returnUrl")]
        public string ReturnUrl { get; set; } = string.Empty;
        /// <summary>
        /// Operate entrance.
        /// "WEB", "APP"
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("tradeType")]
        public TradeType TradeType { get; set; } = TradeType.APP;
        /// <summary>
        /// maximum length 16
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("productType")]
        public ProductType ProductType { get; set; } = ProductType.Test;
        /// <summary>
        /// maximum length 256
        /// </summary>
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
    }
}