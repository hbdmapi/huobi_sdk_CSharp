using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.Futures.RESTful.Response.Market;

namespace Huobi.SDK.Core.Futures.RESTful
{
    /// <summary>
    /// Responsible to get market information
    /// </summary>
    public class MarketClient
    {
        private const string DEFAULT_HOST = "api.btcgateway.pro";

        private PublicUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">the host that the client connects to</param>
        public MarketClient(string host = DEFAULT_HOST)
        {
            _urlBuilder = new PublicUrlBuilder(host);
        }

        /// <summary>
        /// contract info
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="contractType"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetContractInfoResponse> GetContractInfoAsync(string symbol = null, string contractType = null, string contractCode = null)
        {
            // location
            string location = "/api/v1/contract_contract_info";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"&symbol={symbol}";
            }
            if (contractType != null)
            {
                option += $"&contract_type={contractType}";
            }
            if (contractCode != null)
            {
                option += $"&contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option.Substring(1)}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetContractInfoResponse>(url);
        }

        /// <summary>
        /// get index info
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetIndexResponse> GetIndexAsync(string symbol = null)
        {
            // location
            string location = "/api/v1/contract_index";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"&symbol={symbol}";
            }
            if (option != null)
            {
                location += $"?{option.Substring(1)}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetIndexResponse>(url);
        }

        /// <summary>
        /// get price limit
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="contractType"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetPriceLimitResponse> GetPriceLimitAsync(string symbol = null, string contractType = null, string contractCode = null)
        {
            // location
            string location = $"/api/v1/contract_price_limit";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"&symbol={symbol}";
            }
            if (contractType != null)
            {
                option += $"&contract_type={contractType}";
            }
            if (contractCode != null)
            {
                option += $"&contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option.Substring(1)}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetPriceLimitResponse>(url);
        }

        /// <summary>
        /// get open interest
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="contractType"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetOpenInterestResponse> GetOpenInterestAsync(string symbol = null, string contractType = null, string contractCode = null)
        {
            // location
            string location = "/api/v1/contract_open_interest";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"&symbol={symbol}";
            }
            if (contractType != null)
            {
                option += $"&contract_type={contractType}";
            }
            if (contractCode != null)
            {
                option += $"&contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option.Substring(1)}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetOpenInterestResponse>(url);
        }

        /// <summary>
        /// get delivery price
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetDeliveryPriceResponse> GetDeliveryPriceAsync(string symbol)
        {
            // location
            string location = $"/api/v1/contract_delivery_price?symbol={symbol}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetDeliveryPriceResponse>(url);
        }

        /// <summary>
        /// get depth
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<GetDepthResponse> GetDepthAsync(string symbol, string type)
        {
            // location
            string location = $"/market/depth?symbol={symbol}&type={type}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetDepthResponse>(url);
        }

        /// <summary>
        /// get kline
        /// must and just one size or from/to has value
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<GetKLineResponse> GetKLineAsync(string symbol, string period,
                                                          int? size = null, int? from = null, int? to = null)
        {
            // location
            string location = $"/market/history/kline?symbol={symbol}&period={period}";

            // option
            string option = null;
            if (size != null)
            {
                option += $"&size={size}";
            }
            if (from != null)
            {
                option += $"&from={from}";
            }
            if (to != null)
            {
                option += $"&to={to}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetKLineResponse>(url);
        }

        /// <summary>
        /// get mark price kline
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<GetStrKLineResponse> GetMarkPriceKLineAsync(string symbol, string period, int size)
        {
            // location
            string location = $"/index/market/history/mark_price_kline?symbol={symbol}&period={period}&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetStrKLineResponse>(url);
        }

        /// <summary>
        /// get margin detail
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetMergedResponse> GetMergedAsync(string symbol)
        {
            // location
            string location = $"/market/detail/merged?symbol={symbol}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetMergedResponse>(url);
        }

        /// <summary>
        /// Get Batch Merged
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetBatchMergedResponse> GetBatchMergedAsync(string symbol = null)
        {
            // location
            string location = $"/market/detail/batch_merged";
            if (symbol != null)
            {
                location += $"?symbol={symbol}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetBatchMergedResponse>(url);
        }

        /// <summary>
        /// get trade info
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetTradeResponse> GetTradeAsync(string symbol = null)
        {
            // location
            string location = $"/market/trade";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"symbol={symbol}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetTradeResponse>(url);
        }

        /// <summary>
        /// get his trade info
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<GetHisTradeResponse> GetHisTradeAsync(string symbol, int size)
        {
            // location
            string location = $"/market/history/trade?symbol={symbol}&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetHisTradeResponse>(url);
        }

        /// <summary>
        /// get risk info
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetRiskInfoResponse> GetRiskInfoAsync(string symbol = null)
        {
            // location
            string location = "/api/v1/contract_risk_info";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"symbol={symbol}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetRiskInfoResponse>(url);
        }

        /// <summary>
        /// get insurance fund
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetInsuranceFundResponse> GetInsuranceFundAsync(string symbol)
        {
            // location
            string location = $"/api/v1/contract_insurance_fund?symbol={symbol}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetInsuranceFundResponse>(url);
        }

        /// <summary>
        /// get adjust factor
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetAdjustFactorFundResponse> GetAdjustFactorFundAsync(string symbol = null)
        {
            // location
            string location = "/api/v1/contract_adjustfactor";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"symbol={symbol}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetAdjustFactorFundResponse>(url);
        }

        /// <summary>
        /// get his open interest
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <param name="amountType"></param>
        /// <returns></returns>
        public async Task<GetHisOpenInterestResponse> GetHisOpenInterestAsync(string symbol, string contractType, string period, int amountType, int size = 48)
        {
            // location
            string location = $"/api/v1/contract_his_open_interest?symbol={symbol}&contract_type={contractType}&period={period}&amount_type={amountType}&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetHisOpenInterestResponse>(url);
        }

        /// <summary>
        /// ladder margin
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetLadderMarginResponse> GetLadderMarginAsync(string symbol = null)
        {
            // location
            string location = "/api/v1/contract_ladder_margin";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"?symbol={symbol}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetLadderMarginResponse>(url);
        }

        /// <summary>
        /// get elite account ratio
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<GetElitePositionRatioResponse> GetEliteAccountRatioAsync(string symbol, string period)
        {
            // location
            string location = $"/api/v1/contract_elite_account_ratio?symbol={symbol}&period={period}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetElitePositionRatioResponse>(url);
        }

        /// <summary>
        /// get elite position ratio
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<GetElitePositionRatioResponse> GetElitePositionRatioAsync(string symbol, string period)
        {
            // location
            string location = $"/api/v1/contract_elite_position_ratio?symbol={symbol}&period={period}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetElitePositionRatioResponse>(url);
        }

        /// <summary>
        /// get estimated settlement price
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetEstimatedSettlementPriceResponse> GetEstimatedSettlementPriceAsync(string symbol = null)
        {
            // location
            string location = $"/api/v1/contract_estimated_settlement_price";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"?symbol={symbol}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetEstimatedSettlementPriceResponse>(url);
        }

        /// <summary>
        /// get api status
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<GetApiStatusResponse> GetApiStatusAsync(string symbol = null)
        {
            // location
            string location = "/api/v1/contract_api_state";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"symbol={symbol}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetApiStatusResponse>(url);
        }

        /// <summary>
        /// get liquidation orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetLiquidationOrdersResponse> GetLiquidationOrdersAsync(string symbol, int tradeType, int createDate,
                                                                                    int? pageIndex = null, int? pageSize = null)
        {
            // location
            string location = $"/api/v1/contract_liquidation_orders?symbol={symbol}&trade_type={tradeType}&create_date={createDate}";

            // option
            string option = null;
            if (pageIndex != null)
            {
                option += $"&page_index={pageIndex}";
            }
            if (pageSize != null)
            {
                option += $"&page_size={pageSize}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetLiquidationOrdersResponse>(url);
        }

        /// <summary>
        /// get settlement records
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetSettlementRecordsResponse> GetSettlementRecordsAsync(string symbol, long? startTime, long? endTime,
                                                                                  int? pageIndex = null, int? pageSize = null)
        {
            // location
            string location = $"/api/v1/contract_settlement_records?symbol={symbol}";

            // option
            string option = null;
            if (startTime != null)
            {
                option += $"&start_time={startTime}";
            }
            if (endTime != null)
            {
                option += $"&end_time={endTime}";
            }
            if (pageIndex != null)
            {
                option += $"&page_index={pageIndex}";
            }
            if (pageSize != null)
            {
                option += $"&page_size={pageSize}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetSettlementRecordsResponse>(url);
        }

        /// <summary>
        /// get index kline
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<GetKLineResponse> GetIndexKLineAsync(string symbol, string period, int size)
        {
            // location
            string location = $"/index/market/history/index?symbol={symbol}&period={period}&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetKLineResponse>(url);
        }

        public async Task<GetBasisResponse> GetBasisAsync(string symbol, string period, int size = 150, string basisPriceType = null)
        {
            // location
            string location = $"/index/market/history/basis?symbol={symbol}&period={period}&size={size}";

            // option
            string option = null;
            if (basisPriceType != null)
            {
                option += $"&basis_price_type={basisPriceType}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetBasisResponse>(url);
        }

        public async Task<GetBboResponse> GetBboAsync(string symbol = null)
        {
            // location
            string location = "/market/bbo";

            // option
            string option = null;
            if (symbol != null)
            {
                option += $"symbol={symbol}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetBboResponse>(url);
        }

    }
}
