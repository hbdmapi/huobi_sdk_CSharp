using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Transfer;

namespace Huobi.SDK.Core.LinearSwap.RESTful
{
    /// <summary>
    /// Responsible to transfer
    /// </summary>
    public class TransferClient
    {
        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        public TransferClient(string accessKey, string secretKey)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, Host.FUTURES);
        }

        /// <summary>
        /// transfer coin betwee spot and ***-USDT linear swap
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <param name="marginAccount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferAsync(string from, string to, double amount, string marginAccount, string currency = "USDT")
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/v2/account/transfer");

            // content
            string content = $"{{ \"from\":\"{from}\", \"to\":\"{to}\", \"currency\":\"{currency}\", \"amount\":{amount}, \"margin-account\":\"{marginAccount}\" }}";
            return await HttpRequest.PostAsync<TransferResponse>(url, content);
        }
    }
}
