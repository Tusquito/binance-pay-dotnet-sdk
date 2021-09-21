using System;
using System.IO;
using System.Threading.Tasks;
using BinancePayDotnetSdk.Common;
using BinancePayDotnetSdk.Common.Extensions;
using BinancePayDotnetSdk.Common.Forms;
using BinancePayDotnetSdk.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BinancePayDotnetSdk.Executable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await host.StartAsync();
            var payClient = host.Services.GetRequiredService<BinancePayClient>();
            var order = await payClient.CreateOrderAsync(new CreateOrderForm
            {
                TotalFee = 0.01,
                MerchantTradeNo = new Random(Guid.NewGuid().GetHashCode()).Next().ToString(),
                ProductDetail = "test product detail",
                ProductName = "test product name"
            });
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddBinancePayClient(configuration);
                });
        }
    }
}