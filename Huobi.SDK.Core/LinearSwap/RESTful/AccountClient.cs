using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Account;

namespace Huobi.SDK.Core.LinearSwap.RESTful
{
    /// <summary>
    /// Responsible to operate account
    /// </summary>
    public class AccountClient
    {
        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        private const string DEFAULT_HOST = "api.btcgateway.pro";

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public AccountClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, contractCode is option param<br/>
        /// if request sub account assets, param subUid is must need, contractCode is option param
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <param name="subUid"></param>
        /// <returns></returns>
        public async Task<GetAccountAssetsResponse> GetAccountAssetsAsync(string contractCode = null, long? subUid = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_account_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_account_info");
            }

            // content
            string content = null;
            if (contractCode != null)
            {
                content = $",\"contract_code\": \"{contractCode}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetAccountAssetsResponse>(url, content);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, contractCode is option param<br/>
        /// if request sub account assets, param subUid is must need, contractCode is option param
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <param name="subUid"></param>
        /// <returns></returns>
        public async Task<GetAccountPositionResponse> GetAccountPositionAsync(string contractCode = null, long? subUid = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_position_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_account_info");
            }

            // content
            string content = null;
            if (contractCode != null)
            {
                content = $",\"contract_code\": \"{contractCode}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetAccountPositionResponse>(url, content);
        }

        /// <summary>
        /// get all sub account assets
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <returns></returns>
        public async Task<GetAllSubAssetsResponse> GetAllSubAssetsAsync(string contractCode = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_account_list");

            // content
            string content = null;
            if (contractCode != null)
            {
                content = $",\"contract_code\": \"{contractCode}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetAllSubAssetsResponse>(url, content);
        }

        /// <summary>
        /// param asset/fromMarginAccount/toMarginAccount/amount is must nedd <br/>
        /// if master to sub trans, param subUid/type is must need <br/>
        /// if inner sub account trans, param subUid/type is no need <br/>
        /// param type value must be one of: master_to_sub/sub_to_master
        /// </summary>
        /// <param name="asset">such as USDT</param>
        /// <param name="from_margin_account">such as BTC-USDT</param>
        /// <param name="to_margin_account">such as ETH-USDT</param>
        /// <param name="amount"></param>
        /// <param name="sub_uid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<AccountTransferResponse> AccountTransferAsync(string asset, string fromMarginAccount, string toMarginAccount, double amount,
                                                                        long? subUid = null, string type = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_master_sub_transfer");
            if (subUid == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_transfer_inner");
            }

            // content
            string content = $",\"asset\":\"{asset}\", \"from_margin_account\":\"{fromMarginAccount}\", \"to_margin_account\":\"{toMarginAccount}\", \"amount\":{amount}";
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid},\"type\": \"{type}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<AccountTransferResponse>(url, content);
        }

        /// <summary>
        /// if beMasterSub = true to send request for get records betwee master and sub trans, else get account trans <br/>
        /// type must be one of:34(to sub account)/35(to master account) if beMasterSub=true, else see linear-swap-api/v1/swap_financial_record <br/>
        /// createDate is how many days ago, default is 7 days and meas from -7 day 00:00:00(utc+8)
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="beMasterSub"></param>
        /// <param name="type"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetAccountTransHisResponse> GetAccountTransHisAsync(string marginAccount, bool beMasterSub = false, string type = null, int? createDate = null,
                                                                              int? pageIndex = null, int? pageSize = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_financial_record");
            if (beMasterSub)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_master_sub_transfer_record");
            }

            // content
            string content = $",\"margin_account\": \"{marginAccount}\"";
            if (type != null)
            {
                content += $",\"type\": \"{type}\"";
                if (beMasterSub)
                {
                    content += $",\"transfer_type\": \"{type}\"";
                }
            }
            if (createDate != null)
            {
                content += $",\"create_date\": {createDate}";
            }
            else
            {
                if (beMasterSub)
                {
                    createDate = 7;
                    content += $",\"create_date\": {createDate}";
                }
            }
            if (pageIndex != null)
            {
                content += $",\"page_index\": {pageIndex}";
            }
            if (pageSize != null)
            {
                content += $",\"page_size\": {pageSize}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetAccountTransHisResponse>(url, content);
        }

        /// <summary>
        /// get valid lever rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetValidLeverRateResponse> GetValidLeverRateAsync(string contractCode)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_available_level_rate");

            // content
            string content = $"{{ \"contract_code\": \"{contractCode}\" }}";
            return await HttpRequest.PostAsync<GetValidLeverRateResponse>(url, content);
        }

        /// <summary>
        /// get order limit
        /// </summary>
        /// <param name="orderPriceType"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetOrderLimitResponse> GetOrderLimitAsync(string orderPriceType, string contractCode = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_order_limit");

            // content
            string content = $",\"order_price_type\":\"{orderPriceType}\"";
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetOrderLimitResponse>(url, content);
        }

        /// <summary>
        /// get fee
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetFeeResponse> GetFeeAsync(string contractCode)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_fee");

            // content
            string content = $"{{ \"contract_code\": \"{contractCode}\" }}";
            return await HttpRequest.PostAsync<GetFeeResponse>(url, content);
        }

        /// <summary>
        /// get transfer limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetTransferLimitResponse> GetTransferLimitAsync(string contractCode = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_transfer_limit");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetTransferLimitResponse>(url, content);
        }

        /// <summary>
        /// get position limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetPositionLimitResponse> GetPositionLimitAsync(string contractCode = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_position_limit");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetPositionLimitResponse>(url, content);
        }

        public async Task<GetApiTradingStatusResponse> GetApiTradingStatusAsync(string contractCode = null)
        {
            // ulr
            string url = _urlBuilder.Build(GET_METHOD, "/linear-swap-api/v1/swap_api_trading_status");

            // content is null
            return await HttpRequest.GetAsync<GetApiTradingStatusResponse>(url);
        }
    }
}


