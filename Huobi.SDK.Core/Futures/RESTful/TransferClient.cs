using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.Futures.RESTful.Response.Transfer;

namespace Huobi.SDK.Core.Futures.RESTful
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
        /// transfer
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferAsync(string currency, double amount, string type)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/v1/futures/transfer");

            // content
            string content = $"{{ \"currency\":\"{currency}\", \"amount\":{amount}, \"type\":\"{type}\" }}";
            return await HttpRequest.PostAsync<TransferResponse>(url, content);
        }
    }
}
