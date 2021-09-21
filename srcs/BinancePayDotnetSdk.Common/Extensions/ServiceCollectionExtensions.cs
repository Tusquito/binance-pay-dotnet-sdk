using System;
using BinancePayDotnetSdk.Common.Http;
using BinancePayDotnetSdk.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinancePayDotnetSdk.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBinancePayClient(this IServiceCollection services, IConfiguration configuration)
        {
            var clientConfig = configuration.GetSection(ClientConfigurationOptions.Name)
                .Get<ClientConfigurationOptions>();
            if (clientConfig.EnableLogger)
            {
                services.AddLogging();
            }
            services.AddHttpClient(nameof(BinancePayHttpClient), config =>
            {
                config.BaseAddress = new Uri(clientConfig.BinanceApiBaseUrl);
                config.DefaultRequestHeaders.Add(BinanceApiRequestHeaders.CertificateSn, clientConfig.ApiKey);
            });
            services.Configure<ClientConfigurationOptions>(configuration.GetSection(ClientConfigurationOptions.Name));
            services.AddTransient<BinancePayHttpClient>();   
            services.AddTransient<BinancePayClient>();
            return services;
        }
    }
}