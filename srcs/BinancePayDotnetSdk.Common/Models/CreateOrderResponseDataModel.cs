﻿using System;
using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Models
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-order-create#child-attribute
    /// </summary>
    public class CreateOrderResponseDataModel
    {
        /// <summary>
        /// unique id generated by binance
        /// </summary>
        [JsonPropertyName("prepayId")]
        public string PrepayId { get; set; }
        /// <summary>
        /// operate entrance
        /// "WEB", "APP"
        /// </summary>
        [JsonPropertyName("tradeType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TradeType TradeType { get; set; }
        /// <summary>
        /// expire time in milli seconds
        /// </summary>
        [JsonPropertyName("expireTime")] 
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset ExpireTime { get; set; }
        /// <summary>
        /// qr code img link
        /// </summary>
        [JsonPropertyName("qrcodeLink")] 
        public string QrCodeLink { get; set; }
        /// <summary>
        /// qr contend info
        /// </summary>
        [JsonPropertyName("qrContent")]
        public string QrContent { get; set; }
    }
}