namespace BinancePayDotnetSdk.Common.Enums
{
    /// <summary>
    /// Refers to https://developers.binance.com/docs/binance-pay/api-order-create#result-code
    /// </summary>
    public enum ResponseResultCode : int
    {
        SUCCESS = 000000,
        /// <summary>
        /// Reason: Server error.
        /// </summary>
        SERVER_ERROR = 50001,
        /// <summary>
        /// Reason: An unknown error occurred while processing the request.
        /// Solution: Try again later.
        /// </summary>
        UNKNOWN_ERROR = 400000,
        /// <summary>
        /// Reason: Parameter format is wrong or parameter transferring doesn't follow the rules.
        /// Solution: Please check whether the parameters are correct.
        /// </summary>
        INVALID_REQUEST = 400001,
        /// <summary>
        /// Reason: Incorrect signature result.
        /// Solution: Check whether the signature parameter and method comply with signature algorithm requirements.
        /// </summary>
        INVALID_SIGNATURE = 400002,
        /// <summary>
        /// Reason: Timestamp for this request is outside of the time window.
        /// Solution: Sync server clock.
        /// </summary>
        INVALID_TIMESTAMP = 400003,
        /// <summary>
        /// Reason: API identity key not found or invalid.
        /// Solution: Check API identity key.
        /// </summary>
        INVALID_API_KEY_OR_IP = 400004,
        /// <summary>
        /// Reason: API identity key format invalid.
        /// Solution: Check API identity key.
        /// </summary>
        BAD_API_KEY_FMT = 400005,
        /// <summary>
        /// Reason: A parameter was missing/empty/null, or malformed.
        /// </summary>
        MANDATORY_PARAM_EMPTY_OR_MALFORMED = 400100,
        /// <summary>
        /// Reason: A parameter was not valid, was empty/null, or too long/short, or wrong format.
        /// </summary>
        INVALID_PARAM_WRONG_LENGTH = 400101,
        /// <summary>
        /// Reason: A parameter was not valid, the value is out of range.
        /// </summary>
        INVALID_PARAM_WRONG_VALUE = 400102,
        /// <summary>
        /// Reason: A parameter was not valid, contains illegal characters.
        /// </summary>
        INVALID_PARAM_ILLEGAL_CHAR = 400103,
        /// <summary>
        /// Reason: Invalid request, content length too large.
        /// </summary>
        INVALID_REQUEST_TOO_LARGE = 400104,
        /// <summary>
        /// Reason: merchantTradeNo is invalid or duplicated.
        /// </summary>
        INVALID_MERCHANT_TRADE_NO = 400201,
        /// <summary>
        /// Reason: Order not found.
        /// </summary>
        ORDER_NOT_FOUND = 400202,
        /// <summary>
        /// Reason: Not support for this account, please check account status.
        /// </summary>
        INVALID_ACCOUNT_STATUS = 400203,
        /// <summary>
        /// Reason: The Order is not applicable to close as it was paid or has any payment activity on the way.
        /// </summary>
        INVALID_ORDER_STATUS = 400204,
        /// <summary>
        /// Reason: Sub-merchant already exists.
        /// Solution: Please check merchant name.
        /// </summary>
        SUB_MERCHANT_EXISTS = 400205,
        /// <summary>
        /// Reason: The sub merchant does not exist or is in an unavailable state.
        /// </summary>
        SUB_MERCHANT_INVALID = 400206,
        /// <summary>
        /// Reason: Invalid prepayId.
        /// </summary>
        INVALID_PREPAY_ID = 400301,
        /// <summary>
        /// Reason: Refund attempts more than 10 times.
        /// </summary>
        TOO_MANY_REFUND_ATTEMPTS = 400302,
        /// <summary>
        /// Reason: Refund amount is grater than remaining amount.
        /// </summary>
        INVALID_REFUND_AMOUNT = 400303,
        /// <summary>
        /// Reason: The merchant account remaining amount is not enough to do refund.
        /// </summary>
        ACCOUNT_REMAINING_AMOUNT_NOT_ENOUGH = 400304
        
        
        
        
    }
}