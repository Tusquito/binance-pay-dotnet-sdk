using System;
using System.Threading.Tasks;
using BinancePayDotnetSdk.Common.Forms;
using BinancePayDotnetSdk.Common.Http;
using BinancePayDotnetSdk.Common.Models;
using BinancePayDotnetSdk.Common.Options;
using BinancePayDotnetSdk.Common.Utils;

namespace BinancePayDotnetSdk.Common
{
    public class BinancePayClient
    {
        private readonly BinancePayHttpClient _httpClient;
        public BinancePayClient(ClientConfigurationOptions configuration)
        {
            if (configuration.EnableLogger)
            {
                ClientLogger.Enable();
            }
            else
            {
                ClientLogger.Disable();
            }
            
            if (string.IsNullOrEmpty(configuration.ApiKey))
            {
                ClientLogger.Error("ApiKey can't be null or empty.", new ArgumentException());
            }
            else
            {
                ClientLogger.Info($"ApiKey: {configuration.ApiKey}");
            }
            if (string.IsNullOrEmpty(configuration.SecretKey))
            {
                ClientLogger.Error("SecretKey can't be null or empty.", new ArgumentException());
            }
            else
            {
                ClientLogger.Info($"SecretKey: {configuration.SecretKey}");
            }
            if (string.IsNullOrEmpty(configuration.MerchantId))
            {
                ClientLogger.Error("MerchantId can't be null or empty.", new ArgumentException());
            }
            else
            {
                ClientLogger.Info($"MerchantId: {configuration.MerchantId}");
            }

            _httpClient = new BinancePayHttpClient(configuration);
        }

        public async Task<CreateOrderResponseModel> CreateOrderAsync(CreateOrderForm form)
        {
            try
            {
                return await _httpClient.PostAsync<CreateOrderForm, CreateOrderResponseModel>(BinanceApiEndPoints.CreateOrder, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(CreateOrderAsync)}", e);
                return null;
            }
        }
        
        public async Task<CloseOrderResponseModel> CloseOrderAsync(CloseOrderForm form)
        {
            try
            {
                return await _httpClient.PostAsync<CloseOrderForm, CloseOrderResponseModel>(BinanceApiEndPoints.CloseOrder, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(CloseOrderAsync)}", e);
                return null;
            }
        }
    }
}