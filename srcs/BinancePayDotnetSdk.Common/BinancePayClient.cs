using System;
using System.Threading.Tasks;
using BinancePayDotnetSdk.Common.Enums;
using BinancePayDotnetSdk.Common.Forms;
using BinancePayDotnetSdk.Common.Http;
using BinancePayDotnetSdk.Common.Models;
using BinancePayDotnetSdk.Common.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BinancePayDotnetSdk.Common
{
    public class BinancePayClient
    {
        private readonly BinancePayHttpClient _httpClient;
        private readonly ILogger<BinancePayClient> _logger;
        private readonly ClientConfigurationOptions _configuration;
        public BinancePayClient(BinancePayHttpClient httpClient, ILogger<BinancePayClient> logger, IOptions<ClientConfigurationOptions> options)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = options.Value;
        }

        /// <summary>
        /// Create order API used for merchant/partner to initiate acquiring order.
        /// </summary>
        public async Task<CreateOrderResponseModel> CreateOrderAsync(CreateOrderForm form)
        {
            try
            {
                form.MerchantId = _configuration.MerchantId;
                return await _httpClient.PostAsync<CreateOrderForm, CreateOrderResponseModel>(BinanceApiEndPoints.CreateOrder, form);
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
                form.MerchantId = _configuration.MerchantId;
                return await _httpClient.PostAsync<CloseOrderForm, CloseOrderResponseModel>(BinanceApiEndPoints.CloseOrder, form);
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
                
                form.MerchantId = _configuration.MerchantId;
                return await _httpClient.PostAsync<QueryOrderForm, QueryOrderResponseModel>(BinanceApiEndPoints.QueryOrder, form);
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
                form.MerchantId = _configuration.MerchantId;
                return await _httpClient.PostAsync<TransferFundForm, TransferFundResponseModel>(BinanceApiEndPoints.TransferFund, form);
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(TransferFundAsync)}<{nameof(TransferFundResponseModel)}> {e.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Create Sub-merchant API used for merchant/partner.
        /// </summary>
        public async Task<CreateOrderResponseModel> CreateSubMerchantAsync(CreateSubMerchantRequestForm form)
        {
            try
            {
                form.MainMerchantId = _configuration.MerchantId;
                
                if (form.MerchantType == MerchantType.PERSONAL)
                {
                    if (form.CertificateValidDate == null
                        || string.IsNullOrEmpty(form.CertificateNumber)
                        || form.CertificateCountry == null
                        || form.CertificateType == null)
                    {
                        throw new Exception("Some fields are missing for 'personal' merchant type.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(form.CompanyName)
                        || string.IsNullOrEmpty(form.RegistrationNumber)
                        || form.RegistrationCountry == null
                        || string.IsNullOrEmpty(form.RegistrationAddress)
                        || form.IncorporationDate == null
                        || form.SiteType == null)
                    {
                        throw new Exception("Some fields are missing for not 'personal' merchant type.");
                    }
                }

                if (form.SiteType == SiteType.WEB && string.IsNullOrEmpty(form.SiteUrl))
                {
                    throw new Exception("Some fields are missing for 'web' site type.");
                }

                if (form.SiteType != SiteType.OTHERS && string.IsNullOrEmpty(form.SiteName))
                {
                    throw new Exception("Some fields are missing for not 'others' site type.");
                }
                
                return await _httpClient.PostAsync<CreateSubMerchantRequestForm, CreateOrderResponseModel>(BinanceApiEndPoints.CreateSubMerchant, form);
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(CreateSubMerchantAsync)}<{nameof(CreateSubMerchantRequestForm)}> {e.Message}");
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