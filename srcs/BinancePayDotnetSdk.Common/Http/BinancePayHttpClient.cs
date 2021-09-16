using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BinancePayDotnetSdk.Common.Forms;
using BinancePayDotnetSdk.Common.Models;
using BinancePayDotnetSdk.Common.Options;
using BinancePayDotnetSdk.Common.Utils;

namespace BinancePayDotnetSdk.Common.Http
{
    internal class BinancePayHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ClientConfigurationOptions _configuration;
        private static readonly Random Random = new(Guid.NewGuid().GetHashCode());
        internal BinancePayHttpClient(ClientConfigurationOptions configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration.BinanceApiBaseUrl),
                DefaultRequestHeaders = 
                {
                    {BinanceApiRequestHeaders.Nonce, GenerateNonce()},
                    {BinanceApiRequestHeaders.CertificateSn, configuration.ApiKey}
                }
            };
        }

        internal async Task<TResponseModel> GetAsync<TResponseModel>(string url) 
            where TResponseModel : ApiResponseModel<ApiResponseDataModel>

        {
            try
            {
                UpdateHttpClientHeaders();
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return JsonSerializer.Deserialize<TResponseModel>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(GetAsync)}<{typeof(TResponseModel).Name}>", e);
                return null;
            }
        }
        
        internal async Task<TResponseModel> PostAsync<TRequestForm, TResponseModel>(string url, TRequestForm form) 
            where TRequestForm : ApiRequestForm 
            where TResponseModel : new()
        {
            try
            {
                form.MerchantId = _configuration.MerchantId;
                string body = JsonSerializer.Serialize(form);
                UpdateHttpClientHeaders(body);
                HttpResponseMessage response = await _httpClient.PostAsync(url, new StringContent(body , Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                ClientLogger.Info($"POST {url}");
                return JsonSerializer.Deserialize<TResponseModel>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                ClientLogger.Error($"{nameof(PostAsync)}<{typeof(TRequestForm).Name}, {typeof(TResponseModel).Name}>", e);
                return new TResponseModel();
            }
        }
        
        private static string GenerateNonce(int length = 32)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
        
        private void UpdateHttpClientHeaders(string body = null)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(BinanceApiRequestHeaders.Timestamp))
            {
                _httpClient.DefaultRequestHeaders.Remove(BinanceApiRequestHeaders.Timestamp);
            }
            _httpClient.DefaultRequestHeaders.Add(BinanceApiRequestHeaders.Timestamp, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString());
            
            if (_httpClient.DefaultRequestHeaders.Contains(BinanceApiRequestHeaders.Signature))
            {
                _httpClient.DefaultRequestHeaders.Remove(BinanceApiRequestHeaders.Signature);
            }

            _httpClient.DefaultRequestHeaders.Add(BinanceApiRequestHeaders.Signature, GenerateRequestSignature(GenerateRequestPayload(body), _configuration.SecretKey));
        }
        
        private string GenerateRequestPayload(string body = null)
        {
            return $"{(_httpClient.DefaultRequestHeaders.TryGetValues(BinanceApiRequestHeaders.Timestamp, out var timestampValues) ? timestampValues.FirstOrDefault() : string.Empty)}\n" +
                   $"{(_httpClient.DefaultRequestHeaders.TryGetValues(BinanceApiRequestHeaders.Nonce, out var nonceValues) ? nonceValues.FirstOrDefault() : string.Empty)}\n" +
                   $"{(string.IsNullOrEmpty(body) ? string.Empty : body)}\n";
        }
        
        private static string GenerateRequestSignature(string payload, string secretKey)
        {
            HMACSHA512 hmac = new HMACSHA512(Encoding.ASCII.GetBytes(secretKey));
            return BitConverter.ToString(hmac.ComputeHash(Encoding.ASCII.GetBytes(payload))).Replace("-", string.Empty).ToUpperInvariant();
        }
    }
    
}