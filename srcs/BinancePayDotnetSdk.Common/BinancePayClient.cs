using System;
using System.Threading.Tasks;
using BinancePayDotnetSdk.Common.Forms;
using BinancePayDotnetSdk.Common.Http;
using BinancePayDotnetSdk.Common.Models;
using Microsoft.Extensions.Logging;

namespace BinancePayDotnetSdk.Common
{
    public class BinancePayClient
    {
        private readonly BinancePayHttpClient _httpClient;
        private readonly ILogger<BinancePayClient> _logger;
        public BinancePayClient(BinancePayHttpClient httpClient, ILogger<BinancePayClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
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
                _logger.LogError($"{nameof(CreateOrderAsync)}<{nameof(CreateOrderResponseModel)}> {e.Message}");
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
                _logger.LogError($"{nameof(CloseOrderAsync)}<{nameof(CloseOrderResponseModel)}> {e.Message}");
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
                _logger.LogError($"{nameof(QueryOrderAsync)}<{nameof(QueryOrderResponseModel)}> {e.Message}");
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
                _logger.LogError($"{nameof(TransferFundAsync)}<{nameof(TransferFundResponseModel)}> {e.Message}");
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
                _logger.LogError($"{nameof(RefundOrderAsync)}<{nameof(RefundOrderResponseModel)}> {e.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Refund order API used for Marchant/Partner to refund for a successful payment.
        /// </summary>
        public async Task<QueryRefundOrderResponseModel> QueryRefundOrderAsync(QueryOrderForm form)
        {
            try
            {
                return await _httpClient.PostAsync<QueryOrderForm, QueryRefundOrderResponseModel>(BinanceApiEndPoints.QueryRefundOrder, form);
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(QueryRefundOrderAsync)}<{nameof(QueryRefundOrderResponseModel)}> {e.Message}");
                return null;
            }
        }
    }
}