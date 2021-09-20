namespace BinancePayDotnetSdk.Common.Http
{
    internal static class BinanceApiEndPoints
    {
        // POST
        internal const string CreateOrder = "/binancepay/openapi/order";
        // POST
        internal const string CloseOrder = "/binancepay/openapi/order/close";
        // POST
        internal const string QueryOrder = "/binancepay/openapi/order/query";
        // POST
        internal const string TransferFund = "/binancepay/openapi/wallet/transfer";
        // POST
        internal const string RefundOrder = "/binancepay/openapi/order/refund";
    }
}