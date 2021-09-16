﻿using System;
using System.Threading.Tasks;
using BinancePayDotnetSdk.Common;
using BinancePayDotnetSdk.Common.Forms;
using BinancePayDotnetSdk.Common.Options;
using Nito.AsyncEx;

namespace BinancePayDotnetSdk.Executable
{
    class Program
    {
        private static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        private static async Task MainAsync(string[] args)
        {
            BinancePayClient client = new BinancePayClient(new ClientConfigurationOptions
            {
                ApiKey = Environment.GetEnvironmentVariable("BINANCE_API_KEY"),
                SecretKey = Environment.GetEnvironmentVariable("BINANCE_SECRET_KEY"),
                MerchantId = Environment.GetEnvironmentVariable("BINANCE_MERCHANT_ID")
            });
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var test = await client.CreateOrderAsync(new CreateOrderForm
            {
                MerchantTradeNo = random.Next().ToString(),
                ProductDetail = "Test detail",
                ProductName = "Test product name",
                TotalFee = 25.17,
            });
        }
    }
}