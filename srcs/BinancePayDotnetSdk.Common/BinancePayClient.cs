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
            if (string.IsNullOrEmpty(configuration.BinanceApiBaseUrl))
            {
                ClientLogger.Error("BinanceApiBaseUrl can't be null or empty.", new ArgumentException());
            }
            else
            {
                ClientLogger.Info($"BinanceApiBaseUrl: {configuration.BinanceApiBaseUrl}");
            }
            
            _httpClient = new BinancePayHttpClient(configuration);
        }

        /// <summary>
        /// Create order API used for merchant/partner to initiate acquiring order.
        /// </summary>
        public async Task<CreateOrderResponseModel> CreateOrderAsync(CreateOrderForm form)
        {
            try
            {
                return await _httpClient.PostMerchantRequestAsync<CreateOrderForm, CreateOrderResponseModel>(BinanceApiEndPoints.CreateOrder, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(CreateOrderAsync)}", e);
                return null;
            }
        }
        /// <summary>
        /// Close order API used for merchant/partner to close order without any prior payment activities triggered by user.
        /// The successful close result will be notified asynchronously through Order Notification Webhook with bizStatus = "PAY_CLOSED".
        /// </summary>
        public async Task<CloseOrderResponseModel> CloseOrderAsync(CloseOrderForm form)
        {
            try
            {
                return await _httpClient.PostMerchantRequestAsync<CloseOrderForm, CloseOrderResponseModel>(BinanceApiEndPoints.CloseOrder, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(CloseOrderAsync)}", e);
                return null;
            }
        }
        /// <summary>
        /// Query order API used for merchant/partner to query order status.
        /// </summary>
        public async Task<QueryOrderResponseModel> QueryOrderAsync(QueryOrderForm form)
        {
            try
            {
                if(!string.IsNullOrEmpty(form.PrepayId) && !string.IsNullOrEmpty(form.MerchantTradeNo))
                {
                    throw new ArgumentException(
                        "You can't query orders by merchantTradeNo and prepayId at the same time, please choose one and try again.");
                }
                
                return await _httpClient.PostMerchantRequestAsync<QueryOrderForm, QueryOrderResponseModel>(BinanceApiEndPoints.QueryOrder, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(QueryOrderAsync)}", e);
                return null;
            }
        }
        /// <summary>
        /// Fund transfer API used for merchant/partner to initiate Fund transfer between wallets.
        /// </summary>
        public async Task<TransferFundResponseModel> TransferFundAsync(TransferFundForm form)
        {
            try
            {
                return await _httpClient.PostMerchantRequestAsync<TransferFundForm, TransferFundResponseModel>(BinanceApiEndPoints.TransferFund, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(TransferFundAsync)}", e);
                return null;
            }
        }
        
        /// <summary>
        /// Refund order API used for Marchant/Partner to refund for a successful payment.
        /// </summary>
        public async Task<RefundOrderResponseModel> RefundOrderAsync(RefundOrderForm form)
        {
            try
            {
                return await _httpClient.PostAsync<RefundOrderForm, RefundOrderResponseModel>(BinanceApiEndPoints.RefundOrder, form);
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(RefundOrderAsync)}", e);
                return null;
            }
        }
    }
}