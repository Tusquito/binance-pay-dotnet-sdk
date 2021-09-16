using BinancePayDotnetSdk.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinancePayDotnetSdk.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBinancePayClient(IServiceCollection services, IConfiguration configuration)
        {
            ClientConfigurationOptions clientConfigurationOptions = configuration.GetSection(ClientConfigurationOptions.Name).Get<ClientConfigurationOptions>();
            
            if (clientConfigurationOptions == null)
            {
                return;
            }

            services.AddSingleton(new BinancePayClient(clientConfigurationOptions));
        }
    }
}