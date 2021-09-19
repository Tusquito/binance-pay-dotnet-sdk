using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Forms
{
    public class CreateOrderForm : ApiRequestForm
    {
        /// <summary>
        /// Order amount.
        /// minimum unit: 0.01, minimum equivalent value: 0.5 USD
        /// </summary>
        [JsonPropertyName("totalFee")]
        [JsonConverter(typeof(CustomDoubleConverter))]
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
        [JsonPropertyName("currency")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
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
        [JsonPropertyName("tradeType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TradeType TradeType { get; set; } = TradeType.APP;
        /// <summary>
        /// maximum length 16
        /// </summary>
        [JsonPropertyName("productType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductType ProductType { get; set; } = ProductType.Test;
        /// <summary>
        /// maximum length 256
        /// </summary>
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
    }
}