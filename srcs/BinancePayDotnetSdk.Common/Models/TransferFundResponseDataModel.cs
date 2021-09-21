using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Models
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-wallet-transfer#transferresult
    /// </summary>
    public class TransferFundResponseDataModel
    {
        /// <summary>
        /// Used to query the transfer status, query the necessary fields for the transfer status
        /// </summary>
        [JsonPropertyName("tranId")]
        public string TransferId { get; init; }
        /// <summary>
        /// The transfer amount
        /// </summary>
        [JsonPropertyName("amount")]
        [JsonConverter(typeof(JsonStringDoubleConverter))]
        public double Amount { get; init; }
        /// <summary>
        /// SUCCESS (indicating that the transfer is completely successful), FAILURE (indicating that the transfer has failed, it may be that the transferor has a problem with the transferee), PROCESS (the transfer is in progress)
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransferStatusType Status { get; init; }
        /// <summary>
        /// transfer currency, e.g. "BUSD"
        /// </summary>
        [JsonPropertyName("currency")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrencyType Currency { get; init; }
        
    }
}