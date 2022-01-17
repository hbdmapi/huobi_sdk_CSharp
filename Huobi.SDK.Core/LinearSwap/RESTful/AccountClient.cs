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

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public AccountClient(string accessKey, string secretKey, string host = Host.FUTURES)
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
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_balance_valuation");

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
        /// if request account assets, param subUid is not need in any time, contractCode is option param<br/>
        /// if request sub account assets, param subUid is must need, contractCode is option param
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <param name="subUid"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<IsolatedGetAccountInfoResponse> IsolatedGetAccountInfoAsync(string contractCode = null, long? subUid = null,
                                                                                      string tradePartition = null)
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
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<IsolatedGetAccountInfoResponse>(url, content);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, contractCode is option param<br/>
        /// if request sub account assets, param subUid is must need, contractCode is option param
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="subUid"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<CrossGetAccountInfoResponse> CrossGetAccountInfoAsync(string marginAccount = null, long? subUid = null,
                                                                                string contractType = null, string pair = null,
                                                                                string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_account_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_sub_account_info");
            }

            // content
            string content = null;
            if (marginAccount != null)
            {
                content += $",\"margin_account\": \"{marginAccount}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                 content +=  $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<CrossGetAccountInfoResponse>(url, content);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, contractCode is option param<br/>
        /// if request sub account assets, param subUid is must need, contractCode is option param
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <param name="subUid"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetPositionInfoResponse> IsolatedGetPositionInfoAsync(string contractCode = null, long? subUid = null,
                                                                                string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_position_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_position_info");
            }

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (subUid != null)
            {
                content += $",\"sub_uid\": {subUid}";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetPositionInfoResponse>(url, content);
        }

        /// <summary>
        /// if request account assets, param subUid is not need in any time, contractCode is option param<br/>
        /// if request sub account assets, param subUid is must need, contractCode is option param
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="subUid"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetPositionInfoResponse> CrossGetPositionInfoAsync(string contractCode = null, long? subUid = null,
                                                                             string contractType = null, string pair = null,
                                                                             string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_position_info");
            if (subUid != null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_sub_position_info");
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
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                 content +=  $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetPositionInfoResponse>(url, content);
        }

        /// <summary>
        /// get all sub account assets
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <param name="tradePartition"></param>
        /// 
        /// <returns></returns>
        public async Task<GetAllSubAssetsResponse> IsolatedGetAllSubAssetsAsync(string contractCode = null,
                                                                                string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_account_list");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetAllSubAssetsResponse>(url, content);
        }

        /// <summary>
        /// get all sub account assets
        /// </summary>
        /// <param name="marginAccount">such as USDT</param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetAllSubAssetsResponse> CrossGetAllSubAssetsAsync(string marginAccount = null,
                                                                             string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_sub_account_list");

            // content
            string content = null;
            if (marginAccount != null)
            {
                content += $",\"margin_account\": \"{marginAccount}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            
            return await HttpRequest.PostAsync<GetAllSubAssetsResponse>(url, content);
        }

        /// <summary>
        /// isolated margin, sub account info list
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetSubAccountInfoListResponse> IsolatedGetSubAccountInfoListAsync(string contractCode = null,
                                                                                            int? pageIndex = null, int? pageSize= null,
                                                                                            string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_account_info_list");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (pageIndex != null)
            {
                content += $",\"page_index\": {pageIndex}";
            }
            if (pageSize != null)
            {
                content += $",\"page_size\": {pageSize}";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetSubAccountInfoListResponse>(url, content);
        }

        /// <summary>
        /// cross margin, sub account info list
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetSubAccountInfoListResponse> CrossGetSubAccountInfoListAsync(string marginAccount = null,
                                                                                         int? pageIndex = null, int? pageSize= null,
                                                                                         string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_sub_account_info_list");

            // content
            string content = null;
            if (marginAccount != null)
            {
                content += $",\"margin_account\": \"{marginAccount}\"";
            }
            if (pageIndex != null)
            {
                content += $",\"page_index\": {pageIndex}";
            }
            if (pageSize != null)
            {
                content += $",\"page_size\": {pageSize}";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetSubAccountInfoListResponse>(url, content);
        }

        /// <summary>
        /// get lever_position_limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="leverRate"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetLeverPositionLimitResponse> IsolatedGetLeverPositionLimitAsync(string contractCode=null,
                                                                                         int? leverRate = null,
                                                                                         string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_lever_position_limit");

            // content
            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (leverRate != null)
            {
                content += $",\"lever_rate\": {leverRate}";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetLeverPositionLimitResponse>(url, content);
        }

        /// <summary>
        /// get lever_position_limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="leverRate"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="businessType"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetLeverPositionLimitResponse> CrossGetLeverPositionLimitAsync(string contractCode=null,
                                                                                         int? leverRate = null,
                                                                                         string contractType = null,
                                                                                         string pair = null,
                                                                                         string businessType = null,
                                                                                         string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_lever_position_limit");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (leverRate != null)
            {
                content += $",\"lever_rate\": {leverRate}";
            }
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
            }
            if (businessType != null)
            {
                content += $",\"business_type\": \"{businessType}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            System.Console.WriteLine(url);
            System.Console.WriteLine(content);
            return await HttpRequest.PostAsync<GetLeverPositionLimitResponse>(url, content);
        }

        /// <summary>
        /// get account_position_info
        /// </summary>
        /// <param name="contractCode">such as BTC-USDT</param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetAccountPositionResponse> IsolatedGetAccountPositionAsync(string contractCode, string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_account_position_info");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetAccountPositionResponse>(url, content);
        }

        /// <summary>
        /// get account_position_info
        /// </summary>
        /// <param name="marginAccount">such as USDT</param>
        /// <returns></returns>
        public async Task<GetAccountPositionResponseSingle> CrossGetAccountPositionAsync(string marginAccount = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_account_position_info");

            // content
            string content = $"{{ \"margin_account\": \"{marginAccount}\" }}";

            return await HttpRequest.PostAsync<GetAccountPositionResponseSingle>(url, content);
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
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_sub_auth");

            // content
            string content = $"{{ \"sub_uid\": \"{subUid}\", \"sub_auth\": \"{subAuth}\" }}";

            return await HttpRequest.PostAsync<SetSubAuthResponse>(url, content);
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
        /// <param name="clientOrderId"></param>
        /// <returns></returns>
        public async Task<AccountTransferResponse> AccountTransferAsync(string asset, string fromMarginAccount, string toMarginAccount, double amount,
                                                                        long? subUid = null, string type = null, long? clientOrderId = null)
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
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\": {clientOrderId}";
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

        public async Task<GetFinancialRecordExactResponse> GetFinancialRecordExactAsync(string marginAccount,
                                                                string contractCode = null, string type = null,
                                                                long? startTime = null, long? endTime = null,
                                                                long? fromId = null, int? size = 20, string direct = "prev")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_financial_record_exact");

            // content
            string content = $",\"margin_account\": \"{marginAccount}\", \"size\": {size}, \"direct\": \"{direct}\"";
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
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
        /// isolated margin, user settlement records
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IsolatedGetUserSettlementRecordsResponse> IsolatedGetUserSettlementRecordsAsync(string contractCode, long? startTime, long? endTime,
                                                                                                          int? pageIndex = null, int? pageSize = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_user_settlement_records");

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
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

            return await HttpRequest.PostAsync<IsolatedGetUserSettlementRecordsResponse>(url, content);
        }

        /// <summary>
        /// cross margin, user settlement records
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<CrossGetUserSettlementRecordsResponse> CrossGetUserSettlementRecordsAsync(string marginAccount, long? startTime, long? endTime,
                                                                                                    int? pageIndex = null, int? pageSize = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_user_settlement_records");

            // content
            string content = $",\"margin_account\": \"{marginAccount}\"";
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

            return await HttpRequest.PostAsync<CrossGetUserSettlementRecordsResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get valid lever rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetValidLeverRateResponse> IsolatedGetValidLeverRateAsync(string contractCode, string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_available_level_rate");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetValidLeverRateResponse>(url, content);
        }

        /// <summary>
        /// cross margin get valid lever rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="businessType"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetValidLeverRateResponse> CrossGetValidLeverRateAsync(string contractCode = null, string businessType = null,
                                                                                 string contractType = null, string pair = null,
                                                                                 string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_available_level_rate");

            // content
            string content = null;
            if (contractCode != null)
            {
                content +=  $",\"contract_code\": \"{contractCode}\"";
            }
            if (businessType != null)
            {
                content +=  $",\"business_type\": \"{businessType}\"";
            }
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                 content +=  $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetValidLeverRateResponse>(url, content);
        }

        /// <summary>
        /// get order limit
        /// </summary>
        /// <param name="orderPriceType"></param>
        /// <param name="contractCode"></param>
        /// <param name="businessType"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetOrderLimitResponse> GetOrderLimitAsync(string orderPriceType, string contractCode = null,
                                                                    string businessType = null, string contractType = null,
                                                                    string pair = null, string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_order_limit");

            // content
            string content = $",\"order_price_type\":\"{orderPriceType}\"";
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (businessType != null)
            {
                content +=  $",\"business_type\": \"{businessType}\"";
            }
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                 content +=  $",\"trade_partition\": \"{tradePartition}\"";
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
        /// <param name="businessType"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetFeeResponse> GetFeeAsync(string contractCode = null, string businessType = null,
                                                      string contractType = null, string pair = null,
                                                      string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_fee");

            // content
            string content = null;
            if (contractCode != null)
            {
                content +=  $",\"contract_code\": \"{contractCode}\"";
            }
            if (businessType != null)
            {
                content +=  $",\"business_type\": \"{businessType}\"";
            }
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                 content +=  $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetFeeResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get transfer limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetTransferLimitResponse> IsolatedGetTransferLimitAsync(string contractCode = null,
                                                                                  string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_transfer_limit");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetTransferLimitResponse>(url, content);
        }

        /// <summary>
        /// cross margin get transfer limit
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetTransferLimitResponse> CrossGetTransferLimitAsync(string marginAccount = null,
                                                                               string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_transfer_limit");

            // content
            string content = null;
            if (marginAccount != null)
            {
                content += $",\"margin_account\": \"{marginAccount}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
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
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetPositionLimitResponse> IsolatedGetPositionLimitAsync(string contractCode = null,
                                                                                  string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_position_limit");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetPositionLimitResponse>(url, content);
        }

        /// <summary>
        /// get position limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="businessType"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetPositionLimitResponse> CrossGetPositionLimitAsync(string contractCode = null, string businessType = null,
                                                                               string contractType = null, string pair = null,
                                                                               string tradePartition = null)
        {
            // ulr
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_position_limit");

            // content
            string content = null;
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (businessType != null)
            {
                content +=  $",\"business_type\": \"{businessType}\"";
            }
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                 content +=  $",\"trade_partition\": \"{tradePartition}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }
            return await HttpRequest.PostAsync<GetPositionLimitResponse>(url, content);
        }

        /// <summary>
        /// api trading status
        /// </summary>
        /// <returns></returns>
        public async Task<GetApiTradingStatusResponse> GetApiTradingStatusAsync()
        {
            // ulr
            string url = _urlBuilder.Build(GET_METHOD, "/linear-swap-api/v1/swap_api_trading_status");

            // content is null
            return await HttpRequest.GetAsync<GetApiTradingStatusResponse>(url);
        }
    }
}


