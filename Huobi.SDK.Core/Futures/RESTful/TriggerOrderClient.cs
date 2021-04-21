using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using System;
using Huobi.SDK.Core.Futures.RESTful.Request.TriggerOrder;
using Huobi.SDK.Core.Futures.RESTful.Response.TriggerOrder;

namespace Huobi.SDK.Core.Futures.RESTful
{
    public class TriggerOrderClient
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
        public TriggerOrderClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Place a new order and send to the exchange to be matched.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> PlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_trigger_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// cancel all order if orderId is null, else cancel some orders what orderId set
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CancelOrderAsync(string symbol, string orderId = null, string contractCode = null, string contractType = null,
                                                                string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_trigger_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_trigger_cancelall");
            }

            // content
            string content = $",\"symbol\": \"{symbol}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (offset != null)
            {
                content += $",\"offset\": \"{offset}\"";
            }
            if (direction != null)
            {
                content += $",\"direction\": \"{direction}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// get open order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> GetOpenOrderAsync(string symbol, string contractCode = null,
                                                                  int? pageIndex = null, int? pageSize = null,
                                                                  int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_trigger_openorders");

            // content
            string content = $",\"symbol\": \"{symbol}\"";
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
            if (tradeType != null)
            {
                content += $",\"trade_type\": {tradeType}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetOpenOrderResponse>(url, content);
        }

        /// <summary>
        /// get his order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> GetHisOrderAsync(string symbol, string contractCode, int tradeType, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_trigger_hisorders");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"trade_type\": \"{tradeType}\",\"status\": \"{status}\",\"create_date\": \"{createDate}\"";
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
            if (sortBy != null)
            {
                content += $",\"sort_by\": \"{sortBy}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderResponse>(url, content);
        }

        /// <summary>
        /// tpsl order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TpslOrderResponse> TpslOrderAsync(TpslOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_tpsl_order");

            return await HttpRequest.PostAsync<TpslOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// tpsl cancel
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="contractCode"></param>
        /// <param name="contractType"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> TpslCancelAsync(string symbol, string orderId = null, string contractCode = null, 
                                                               string contractType = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_tpsl_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_tpsl_cancelall");
            }

            // content
            string content = "";
            if (symbol != null)
            {
                content += $",\"symbol\": \"{symbol}\"";
            }
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (direction != null)
            {
                content += $",\"direction\": \"{direction}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// get tpsl open order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tradeType"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> GetTpslOpenOrderAsync(string symbol, string contractCode = null, 
                                                                      int? pageIndex = null, int? pageSize = null, int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_tpsl_openorders");

            // content
            string content = $",\"symbol\": \"{symbol}\"";
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
            if (tradeType != null)
            {
                content += $",\"trade_type\": {tradeType}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetOpenOrderResponse>(url, content);
        }

        /// <summary>
        /// get tpsl his order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> GetTpslHisOrderAsync(string symbol, string status, int createDate, string contractCode = null,
                                                                    int? pageIndex = null, int? pageSize = null, string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_tpsl_hisorders");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"status\": \"{status}\",\"create_date\": {createDate}";
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
            if (sortBy != null)
            {
                content += $",\"sort_by\": \"{sortBy}\"";
            }

            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderResponse>(url, content);
        }

        /// <summary>
        /// get relation tpsl order 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<GetRelationTpslOrderResponse> GetRelationTpslOrderAsync(string symbol, long orderId)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_relation_tpsl_order");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"order_id\": {orderId}";
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetRelationTpslOrderResponse>(url, content);
        }

        /// <summary>
        /// track order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PlaceOrderResponse> TrackOrderAsync(TrackOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_track_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// track cancel
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="contractCode"></param>
        /// <param name="contractType"></param>
        /// <param name="offset"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> TrackCancelAsync(string symbol, string orderId = null, string contractCode = null, string contractType = null,
                                                                string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_track_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_track_cancelall");
            }

            // content
            string content = $",\"symbol\": \"{symbol}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (offset != null)
            {
                content += $",\"offset\": \"{offset}\"";
            }
            if (direction != null)
            {
                content += $",\"direction\": \"{direction}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// get track open orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tradeType"></param>
        /// <returns></returns>
        public async Task<GetTrackOpenOrderResponse> GetTrackOpenOrderAsync(string symbol, string contractCode = null,
                                                                  int? pageIndex = null, int? pageSize = null,
                                                                  int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_track_openorders");

            // content
            string content = $",\"symbol\": \"{symbol}\"";
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
            if (tradeType != null)
            {
                content += $",\"trade_type\": {tradeType}";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetTrackOpenOrderResponse>(url, content);
        }

        public async Task<GetTrackHisOrderResponse> GetTrackHisOrderAsync(string symbol, string contractCode, string status, int tradeType, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_track_hisorders");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"trade_type\": \"{tradeType}\",\"status\": \"{status}\",\"create_date\": \"{createDate}\"";
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
            if (sortBy != null)
            {
                content += $",\"sort_by\": \"{sortBy}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetTrackHisOrderResponse>(url, content);
        }

    }
}
