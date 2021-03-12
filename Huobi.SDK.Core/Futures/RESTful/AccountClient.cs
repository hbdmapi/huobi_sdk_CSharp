using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.Futures.RESTful.Response.Account;

namespace Huobi.SDK.Core.Futures.RESTful
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
        /// get balance valuation
        /// </summary>
        /// <param name="valuationAsset"></param>
        /// <returns></returns>
        public async Task<GetBalanceValuationResponse> GetBalanceValuationAsync(string valuationAsset = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_balance_valuation");

            // content
            string content = null;
            if (valuationAsset != null)
            {
                content = $",\"valuation_asset\": \"{valuationAsset}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetBalanceValuationResponse>(url, content);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, symbol is option param<br/>
        /// if request sub account assets, param subUid is must need, symbol is option param
        /// </summary>
        /// <param name="symbol">such as BTC-USDT</param>
        /// <param name="subUid"></param>
        /// <returns></returns>
        public async Task<GetAccountInfoResponse> GetAccountInfoAsync(string symbol = null, long? subUid = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_account_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_sub_account_info");
            }

            // content
            string content = null;
            if (symbol != null)
            {
                content = $",\"symbol\": \"{symbol}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetAccountInfoResponse>(url, content);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, symbol is option param<br/>
        /// if request sub account assets, param subUid is must need, symbol is option param
        /// </summary>
        /// <param name="symbol">such as BTC-USDT</param>
        /// <param name="subUid"></param>
        /// <returns></returns>
        public async Task<GetPositionInfoResponse> GetPositionInfoAsync(string symbol = null, long? subUid = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_position_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_sub_account_info");
            }

            // content
            string content = null;
            if (symbol != null)
            {
                content = $",\"symbol\": \"{symbol}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetPositionInfoResponse>(url, content);
        }

        /// <summary>
        /// set sub auth
        /// </summary>
        /// <param name="subUid"></param>
        /// <param name="subAuth"></param>
        /// <returns></returns>
        public async Task<SetSubAuthResponse> SetSubAuthAsync(string subUid, int subAuth)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_sub_auth");

            // content
            string content = $"{{ \"sub_uid\": \"{subUid}\", \"sub_auth\": \"{subAuth}\" }}";

            return await HttpRequest.PostAsync<SetSubAuthResponse>(url, content);
        }

        /// <summary>
        /// get all sub account assets
        /// </summary>
        /// <param name="symbol">such as BTC-USDT</param>
        /// <returns></returns>
        public async Task<GetAllSubAssetsResponse> GetAllSubAssetsAsync(string symbol = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_sub_account_list");

            // content
            string content = null;
            if (symbol != null)
            {
                content = $",\"symbol\": \"{symbol}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetAllSubAssetsResponse>(url, content);
        }

        /// <summary>
        /// sub account info list
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetSubAccountInfoListResponse> GetSubAccountInfoListAsync(string symbol = null,
                                                                                    int? pageIndex = null, int? pageSize= null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_sub_account_info_list");

            // content
            string content = null;
            if (symbol != null)
            {
                content = $",\"symbol\": \"{symbol}\"";
            }
            if (pageIndex != null)
            {
                content = $",\"page_index\": {pageIndex}";
            }
            if (pageSize != null)
            {
                content = $",\"page_size\": {pageSize}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetSubAccountInfoListResponse>(url, content);
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
        public async Task<GetAccountTransHisResponse> GetAccountTransHisAsync(string symbol, bool beMasterSub = false, string type = null, int? createDate = null,
                                                                              int? pageIndex = null, int? pageSize = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_financial_record");
            if (beMasterSub)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_master_sub_transfer_record");
            }

            // content
            string content = $",\"symbol\": \"{symbol}\"";
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
        /// financial record exact
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="symbol"></param>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="fromId"></param>
        /// <param name="size"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public async Task<GetFinancialRecordExactResponse> GetFinancialRecordExactAsync(string symbol, 
                                                                string type = null, long? startTime = null, long? endTime = null,
                                                                long? fromId = null, int? size = 20, string direct = "prev")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_financial_record_exact");

            // content
            string content = $",\"symbol\": \"{symbol}\", \"size\": {size}, \"direct\": \"{direct}\"";
            if (type != null)
            {
                content += $",\"type\": \"{type}\"";
            }
            if (startTime != null)
            {
                content += $",\"start_time\": {startTime}";
            }
            if (endTime != null)
            {
                content += $",\"end_time\": {endTime}";
            }
            if (fromId != null)
            {
                content += $",\"from_id\": {fromId}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetFinancialRecordExactResponse>(url, content);
        }

        /// <summary>
        /// user settlement records
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetUserSettlementRecordsResponse> GetUserSettlementRecordsAsync(string symbol, long? startTime, long? endTime,
                                                                                          int? pageIndex = null, int? pageSize = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_user_settlement_records");

            // content
            string content = $",\"symbol\": \"{symbol}\"";
            if (startTime != null)
            {
                content += $",\"start_time\": \"{startTime}\"";
            }
            if (endTime != null)
            {
                content += $",\"end_time\": {endTime}";
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

            return await HttpRequest.PostAsync<GetUserSettlementRecordsResponse>(url, content);
        }

        /// <summary>
        /// get order limit
        /// </summary>
        /// <param name="orderPriceType"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetOrderLimitResponse> GetOrderLimitAsync(string orderPriceType, string symbol = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_order_limit");

            // content
            string content = $",\"order_price_type\":\"{orderPriceType}\"";
            if (symbol != null)
            {
                content += $",\"symbol\": \"{symbol}\"";
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
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetFeeResponse> GetFeeAsync(string symbol)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_fee");

            // content
            string content = $"{{ \"symbol\": \"{symbol}\" }}";
            return await HttpRequest.PostAsync<GetFeeResponse>(url, content);
        }

        /// <summary>
        /// get transfer limit
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetTransferLimitResponse> GetTransferLimitAsync(string symbol = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_transfer_limit");

            // content
            string content = null;
            if (symbol != null)
            {
                content += $",\"symbol\": \"{symbol}\"";
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
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetPositionLimitResponse> GetPositionLimitAsync(string symbol = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_position_limit");

            // content
            string content = null;
            if (symbol != null)
            {
                content += $",\"symbol\": \"{symbol}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetPositionLimitResponse>(url, content);
        }

        /// <summary>
        /// get account_position_info
        /// </summary>
        /// <param name="symbol">such as BTC-USDT</param>
        /// <returns></returns>
        public async Task<GetAccountPositionResponse> GetAccountPositionAsync(string symbol)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_account_position_info");

            // content
            string content = $"{{ \"symbol\": \"{symbol}\" }}";

            return await HttpRequest.PostAsync<GetAccountPositionResponse>(url, content);
        }

        public async Task<AccountTransferResponse> AccountTransferAsync(string symbol, double amount, long subUid, string type)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_master_sub_transfer");

            // content
            string content = $"{{ \"symbol\":\"{symbol}\", \"amount\":{amount}, \"sub_uid\":{subUid}, \"type\":\"{type}\" }}";
            
            return await HttpRequest.PostAsync<AccountTransferResponse>(url, content);
        }
        
        /// <summary>
        /// api_trading_status
        /// </summary>
        /// <returns></returns>
        public async Task<GetApiTradingStatusResponse> GetApiTradingStatusAsync()
        {
            // ulr
            string url = _urlBuilder.Build(GET_METHOD, "/api/v1/contract_api_trading_status");

            // content is null
            return await HttpRequest.GetAsync<GetApiTradingStatusResponse>(url);
        }

        /// <summary>
        /// get valid lever rate
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetValidLeverRateResponse> GetValidLeverRateAsync(string symbol)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_available_level_rate");

            // content
            string content = $"{{ \"symbol\": \"{symbol}\" }}";
            return await HttpRequest.PostAsync<GetValidLeverRateResponse>(url, content);
        }
    }
}


