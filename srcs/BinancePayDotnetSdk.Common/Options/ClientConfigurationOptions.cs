namespace BinancePayDotnetSdk.Common.Options
{
    public class ClientConfigurationOptions
    {
        public const string Name = nameof(ClientConfigurationOptions);
        public string ApiKey { get; init; }
        public string SecretKey { get; init; }
        public long MerchantId { get; init; }
        public string BinanceApiBaseUrl { get; init; }
        public bool EnableLogger { get; init; }
    }
}