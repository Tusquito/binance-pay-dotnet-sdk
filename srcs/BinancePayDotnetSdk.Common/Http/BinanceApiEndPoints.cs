namespace BinancePayDotnetSdk.Common.Http
{
    internal static class BinanceApiEndPoints
    {
        // POST
        public const string CreateOrder = "/binancepay/openapi/order";
        // POST
        public const string CloseOrder = "/binancepay/openapi/order/close";
        // POST
        public const string QueryOrder = "/binancepay/openapi/order/query";
        // POST
        public const string TransferFund = "/binancepay/openapi/wallet/transfer";
    }
}