using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Market;

namespace Huobi.SDK.Core.LinearSwap.RESTful
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
        /// get contract info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetContractInfoResponse> GetContractInfoAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_contract_info";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetContractInfoResponse>(url);
        }

        /// <summary>
        /// get index info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetIndexResponse> GetIndexAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_index";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetIndexResponse>(url);
        }

        /// <summary>
        /// get price limit
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetPriceLimitResponse> GetPriceLimitAsync(string contractCode)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_price_limit?contract_code={contractCode}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetPriceLimitResponse>(url);
        }

        /// <summary>
        /// get open interest
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetOpenInterestResponse> GetOpenInterestAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_open_interest";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetOpenInterestResponse>(url);
        }

        /// <summary>
        /// get depth
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<GetDepthResponse> GetDepthAsync(string contractCode, string type)
        {
            // location
            string location = $"/linear-swap-ex/market/depth?contract_code={contractCode}&&type={type}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetDepthResponse>(url);
        }

        /// <summary>
        /// get kline
        /// must and just one size or from/to has value
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<GetKLineResponse> GetKLineAsync(string contractCode, string period,
                                                          int? size = null, int? from = null, int? to = null)
        {
            // location
            string location = $"/linear-swap-ex/market/history/kline?contract_code={contractCode}&&period={period}";

            // option
            string option = null;
            if (size != null)
            {
                option += $"&&size={size}";
            }
            if (from != null)
            {
                option += $"&&from={from}";
            }
            if (to != null)
            {
                option += $"&&to={to}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetKLineResponse>(url);
        }

        /// <summary>
        /// get margin detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetMergedResponse> GetGetMergedAsync(string contractCode)
        {
            // location
            string location = $"/linear-swap-ex/market/detail/merged?contract_code={contractCode}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetMergedResponse>(url);
        }

        /// <summary>
        /// get trade info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetTradeResponse> GetTradeAsync(string contractCode)
        {
            // location
            string location = $"/linear-swap-ex/market/trade?contract_code={contractCode}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetTradeResponse>(url);
        }

        /// <summary>
        /// get his trade info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<GetHisTradeResponse> GetHisTradeAsync(string contractCode, int size)
        {
            // location
            string location = $"/linear-swap-ex/market/history/trade?contract_code={contractCode}&&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetHisTradeResponse>(url);
        }

        /// <summary>
        /// get risk info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetRiskInfoResponse> GetRiskInfoAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_risk_info";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
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
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetInsuranceFundResponse> GetInsuranceFundAsync(string contractCode, int? pageIndex = null, int? pageSize = null)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_insurance_fund?contract_code={contractCode}";

            // option
            string option = null;
            if (pageIndex != null)
            {
                option += $"&&size={pageIndex}";
            }
            if (pageSize != null)
            {
                option += $"&&from={pageSize}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetInsuranceFundResponse>(url);
        }

        /// <summary>
        /// isolated margin get adjust factor
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetAdjustFactorFundResponse> IsolatedGetAdjustFactorFundAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_adjustfactor";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetAdjustFactorFundResponse>(url);
        }

        /// <summary>
        /// cross margin get adjust factor
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetAdjustFactorFundResponse> CrossGetAdjustFactorFundAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_cross_adjustfactor";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
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
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <param name="amountType"></param>
        /// <returns></returns>
        public async Task<GetHisOpenInterestResponse> GetHisOpenInterestAsync(string contractCode, string period, int amountType, int? size = null)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_his_open_interest?contract_code={contractCode}&&period={period}&&amount_type={amountType}";

            // option
            string option = null;
            if (size != null)
            {
                option += $"&&size={size}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetHisOpenInterestResponse>(url);
        }

        /// <summary>
        /// get elite account ratio
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<GetElitePositionRatioResponse> GetEliteAccountRatioAsync(string contractCode, string period)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_elite_account_ratio?contract_code={contractCode}&&period={period}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetElitePositionRatioResponse>(url);
        }

        /// <summary>
        /// get elite position ratio
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<GetElitePositionRatioResponse> GetElitePositionRatioAsync(string contractCode, string period)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_elite_position_ratio?contract_code={contractCode}&&period={period}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetElitePositionRatioResponse>(url);
        }

        /// <summary>
        /// isolated margin get api status
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetApiStatusResponse> IsolatedGetApiStatusAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_api_state";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetApiStatusResponse>(url);
        }

        /// <summary>
        /// cross margin get transfer state
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetTransferStateResponse> CrossGetTransferStateAsync(string marginAccount = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_cross_transfer_state";

            // option
            string option = null;
            if (marginAccount != null)
            {
                option += $"margin_account={marginAccount}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetTransferStateResponse>(url);
        }

        /// <summary>
        /// cross margin get trade state
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetTradeStatusResponse> CrossGetTradeStateAsync(string contractCode = null)
        {
            // location
            string location = "/linear-swap-api/v1/swap_cross_trade_state";

            // option
            string option = null;
            if (contractCode != null)
            {
                option += $"contract_code={contractCode}";
            }
            if (option != null)
            {
                location += $"?{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetTradeStatusResponse>(url);
        }

        /// <summary>
        /// get funding rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<GetFundingRateResponse> GetFundingRateAsync(string contractCode)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_funding_rate?contract_code={contractCode}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetFundingRateResponse>(url);
        }

        /// <summary>
        /// get his funding rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisFundingRateResponse> GetHisFundingRateAsync(string contractCode, int? pageIndex = null, int? pageSize = null)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_historical_funding_rate?contract_code={contractCode}";

            // option
            string option = null;
            if (pageIndex != null)
            {
                option += $"&&page_index={pageIndex}";
            }
            if (pageSize != null)
            {
                option += $"&&page_size={pageSize}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetHisFundingRateResponse>(url);
        }

        /// <summary>
        /// get liquidation orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetLiquidationOrdersResponse> GetLiquidationOrdersAsync(string contractCode, int tradeType, int createDate,
                                                                                    int? pageIndex = null, int? pageSize = null)
        {
            // location
            string location = $"/linear-swap-api/v1/swap_liquidation_orders?contract_code={contractCode}&&trade_type={tradeType}&&create_date={createDate}";

            // option
            string option = null;
            if (pageIndex != null)
            {
                option += $"&&page_index={pageIndex}";
            }
            if (pageSize != null)
            {
                option += $"&&page_size={pageSize}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetLiquidationOrdersResponse>(url);
        }

        /// <summary>
        /// get premium index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <param name="amountType"></param>
        /// <returns></returns>
        public async Task<GetStrKLineResponse> GetPremiumIndexKLineAsync(string contractCode, string period, int size)
        {
            // location
            string location = $"/index/market/history/linear_swap_premium_index_kline?contract_code={contractCode}&&period={period}&&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetStrKLineResponse>(url);
        }

        /// <summary>
        /// get estimated rate kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<GetStrKLineResponse> GetEstimatedRateKLineAsync(string contractCode, string period, int size)
        {
            // location
            string location = $"/index/market/history/linear_swap_estimated_rate_kline?contract_code={contractCode}&&period={period}&&size={size}";

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetStrKLineResponse>(url);
        }

        public async Task<GetBasisResponse> GetBasisAsync(string contractCode, string period, int size = 150, string basisPriceType = null)
        {
            // location
            string location = $"/index/market/history/linear_swap_basis?contract_code={contractCode}&&period={period}&&size={size}";

            // option
            string option = null;
            if (basisPriceType != null)
            {
                option += $"&&basis_price_type={basisPriceType}";
            }
            if (option != null)
            {
                location += $"{option}";
            }

            string url = _urlBuilder.Build(location);
            return await HttpRequest.GetAsync<GetBasisResponse>(url);
        }

    }
}
