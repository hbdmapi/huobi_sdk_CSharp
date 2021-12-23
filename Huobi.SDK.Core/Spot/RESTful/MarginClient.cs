using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.Spot.RESTful.Response.Margin;
using Huobi.SDK.Core.Spot.RESTful.Request.Margin;

namespace Huobi.SDK.Core.Spot.RESTful
{
    /// <summary>
    /// Responsible to operate margin
    /// </summary>
    public class MarginClient
    {
        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public MarginClient(string accessKey, string secretKey, string host = Host.SPOT)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Transfer specific asset from spot trading account to cross margin account
        /// </summary>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> CrossTransferIn(string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/cross-margin/transfer-in");

            string body = $"{{ \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Transfer specific asset from cross margin account to spot trading account
        /// </summary>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> CrossTransferOut(string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/cross-margin/transfer-out");

            string body = $"{{ \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns loan interest rates and quota applied on the user
        /// </summary>
        /// <returns>CrossGetLoanInfoResponse</returns>
        public async Task<CrossGetLoanInfoResponse> CrossGetLoanInfo()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/loan-info");

            return await HttpRequest.GetAsync<CrossGetLoanInfoResponse>(url);
        }

        /// <summary>
        /// Place an order to apply a margin loan.
        /// </summary>
        /// <param name="currency">The currency to borrow</param>
        /// <param name="amount">The amount of currency to borrow (precision: 3 decimal places)</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> CrossApplyLoan(string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/cross-margin/orders");

            string body = $"{{ \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Repays margin loan with you asset in your margin account.
        /// </summary>
        /// <param name="orderId">The previously returned order id when loan order was created</param>
        /// <param name="amount">The amount of currency to repay</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> CrossRepay(string orderId, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/cross-margin/orders/{orderId}/repay");

            string body = $"{{ \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns margin orders based on a specific searching criteria.
        /// </summary>
        /// <returns>GetCrossLoanOrdersResponse</returns>
        public async Task<CrossGetLoanOrdersResponse> CrossGetLoanOrders(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/loan-orders", request);

            return await HttpRequest.GetAsync<CrossGetLoanOrdersResponse>(url);
        }

        /// <summary>
        /// Returns the balance of the margin loan account.
        /// </summary>
        /// <returns>GetCrossMarginAccountResponse</returns>
        public async Task<CrossGetMarginAccountResponse> CrossGetMarginAccount(string subUserId)
        {
            GetRequest request = new GetRequest()
                .AddParam("sub-uid", subUserId);
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/accounts/balance", request);

            return await HttpRequest.GetAsync<CrossGetMarginAccountResponse>(url);
        }

        /// <summary>
        /// General repays margin loan.
        /// </summary>
        /// <param name="request">PostRepaymentResponse</param>
        /// <returns>TransferResponse</returns>
        public async Task<PostRepaymentResponse> PostRepayment(GeneralRepayRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v2/account/repayment");

            return await HttpRequest.PostAsync<PostRepaymentResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Returns the repayment records
        /// </summary>
        /// <returns>GetCrossMarginAccountResponse</returns>
        public async Task<GetRepaymentResponse> GetRepayment(GetRepaymentRequest request)
        {
            GetRequest getRequest = new GetRequest()
                .AddParam("repayId", request.repayId)
                .AddParam("accountId", request.accountId)
                .AddParam("currency", request.currency)
                .AddParam("startTime", request.startTime.ToString())
                .AddParam("endTime", request.endTime.ToString())
                .AddParam("sort", request.sort)
                .AddParam("limit", request.limit.ToString())
                .AddParam("fromId", request.fromId.ToString());

            string url = _urlBuilder.Build(GET_METHOD, "/v2/account/repayment", getRequest);

            return await HttpRequest.GetAsync<GetRepaymentResponse>(url);
        }

        /// <summary>
        /// Transfer specific asset from spot trading account to isolated margin account
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> IsolatedTransferInAsync(string symbol, string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/dw/transfer-in/margin");

            string body = $"{{ \"symbol\":\"{symbol}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Transfer specific asset from isolated margin account to spot trading account
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> IsolatedTransferOutAsync(string symbol, string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/dw/transfer-out/margin");

            string body = $"{{ \"symbol\":\"{symbol}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns loan interest rates and quota applied on the user
        /// </summary>
        /// <param name="symbols">Trading symbol (multiple selections acceptable, separated by comma)</param>
        /// <returns>GetLoanInfoResponse</returns>
        public async Task<IsolatedGetLoanInfoResponse> IsolatedGetLoanInfoAsync(string symbols)
        {
            var request = new GetRequest();

            if (!string.IsNullOrEmpty(symbols))
            {
                request.AddParam("symbols", symbols);
            }

            string url = _urlBuilder.Build(GET_METHOD, "/v1/margin/loan-info", request);

            return await HttpRequest.GetAsync<IsolatedGetLoanInfoResponse>(url);
        }

        /// <summary>
        /// Place an order to apply a margin loan.
        /// </summary>
        /// <param name="symbol">The trading symbol to borrow margin</param>
        /// <param name="currency">The currency to borrow</param>
        /// <param name="amount">The amount of currency to borrow (precision: 3 decimal places)</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> IsolatedApplyLoanAsync(string symbol, string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/margin/orders");

            string body = $"{{ \"symbol\":\"{symbol}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Repays margin loan with you asset in your margin account.
        /// </summary>
        /// <param name="orderId">The previously returned order id when loan order was created</param>
        /// <param name="amount">The amount of currency to repay</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> IsolatedRepayAsync(string orderId, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/margin/orders/{orderId}/repay");

            string body = $"{{ \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns margin orders based on a specific searching criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetLoanOrdersResponse</returns>
        public async Task<IsolatedGetLoanOrdersResponse> IsolatedGetLoanOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/margin/loan-orders", request);

            return await HttpRequest.GetAsync<IsolatedGetLoanOrdersResponse>(url);
        }

        /// <summary>
        /// Returns the balance of the margin loan account.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="subUid">Sub user ID (mandatory field while parent user querying sub user’s margin account details)</param>
        /// <returns>GetMarginAccountResponse</returns>
        public async Task<IsolatedGetMarginAccountResponse> IsolatedGetMarginAccountAsync(string symbol, string subUid)
        {
            var request = new GetRequest();

            if (!string.IsNullOrEmpty(symbol))
            {
                request.AddParam("symbol", symbol);
            }

            if (subUid != null)
            {
                request.AddParam("sub-uid", subUid);
            }

            string url = _urlBuilder.Build(GET_METHOD, "/v1/margin/accounts/balance", request);

            return await HttpRequest.GetAsync<IsolatedGetMarginAccountResponse>(url);
        }
    }
}
