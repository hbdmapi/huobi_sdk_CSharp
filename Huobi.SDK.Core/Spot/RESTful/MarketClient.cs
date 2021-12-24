using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Core.Spot.RESTful.Response.Market;

namespace Huobi.SDK.Core.Spot.RESTful
{
    /// <summary>
    /// Responsible to get market information
    /// </summary>
    public class MarketClient
    {
        private PublicUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">the host that the client connects to</param>
        public MarketClient(string host = Host.SPOT)
        {
            _urlBuilder = new PublicUrlBuilder(host);
        }

        /// <summary>
        /// Retrieves all klines in a specific range.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetKlineResponse> GetKlineAsync(GetRequest request)
        {
            string url = _urlBuilder.Build("/market/history/kline", request);

            return await HttpRequest.GetAsync<GetKlineResponse>(url);
        }

        /// <summary>
        /// Retrieves the latest ticker with some important 24h aggregated market data.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <returns>GetMergedResponse</returns>
        public async Task<GetMergedResponse> GetMergedAsync(string symbol)
        {
            string url = _urlBuilder.Build($"/market/detail/merged?symbol={symbol}");

            return await HttpRequest.GetAsync<GetMergedResponse>(url);
        }

        /// <summary>
        /// Retrieve the latest tickers for all supported pairs.
        /// </summary>
        /// <returns>GetTickersResponse</returns>
        public async Task<GetTickersResponse> GetTicksAsync()
        {
            string url = _urlBuilder.Build("/market/tickers");

            return await HttpRequest.GetAsync<GetTickersResponse>(url);
        }

        /// <summary>
        /// Retrieves the current order book of a specific pair
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetDepthResponse</returns>
        public async Task<GetDepthResponse> GetDepthAsync(GetRequest request)
        {
            string url = _urlBuilder.Build("/market/depth", request);

            return await HttpRequest.GetAsync<GetDepthResponse>(url);
        }

        /// <summary>
        /// Retrieves the latest trade with its price, volume, and direction.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <returns>GetTradeResponse</returns>
        public async Task<GetTradeResponse> GetTradeAsync(string symbol)
        {
            string url = _urlBuilder.Build($"/market/trade?symbol={symbol}");

            return await HttpRequest.GetAsync<GetTradeResponse>(url);
        }

        /// <summary>
        /// Retrieves the most recent trades with their price, volume, and direction.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="size">The number of data returns</param>
        /// <returns>GetLastTradesResponse</returns>
        public async Task<GetHisTradesResponse> GetHisTradesAsync(string symbol, int size)
        {
            string url = _urlBuilder.Build($"/market/history/trade?symbol={symbol}&size={size}");

            return await HttpRequest.GetAsync<GetHisTradesResponse>(url);
        }

        /// <summary>
        /// Retrieves the summary of trading in the market for the last 24 hours.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <returns>GetDetailResponse</returns>
        public async Task<GetDetailResponse> GetDetailAsync(string symbol)
        {
            string url = _urlBuilder.Build($"/market/detail?symbol={symbol}");

            return await HttpRequest.GetAsync<GetDetailResponse>(url);
        }
    }
}
