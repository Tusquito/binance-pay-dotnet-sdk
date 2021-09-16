namespace BinancePayDotnetSdk.Common.Options
{
    public class ClientConfigurationOptions
    {
        public const string Name = nameof(ClientConfigurationOptions);
        public string ApiKey { get; init; }
        public string SecretKey { get; init; }
        public string MerchantId { get; init; }
        public string BinanceApiBaseUrl { get; init; } = "https://bpay.binanceapi.com";
        public bool EnableLogger { get; init; } = true;
    }
}