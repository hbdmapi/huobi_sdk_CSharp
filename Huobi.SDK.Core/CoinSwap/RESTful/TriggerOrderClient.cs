using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using System;
using Huobi.SDK.Core.CoinSwap.RESTful.Request.TriggerOrder;
using Huobi.SDK.Core.CoinSwap.RESTful.Response.TriggerOrder;

namespace Huobi.SDK.Core.CoinSwap.RESTful
{
    public class TriggerOrderClient
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
        public TriggerOrderClient(string accessKey, string secretKey, string host = Host.FUTURES)
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
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_trigger_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// cancel all order if orderId is null, else cancel some orders what orderId set
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CancelOrderAsync(string contractCode, string orderId = null,
                                                                        string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_trigger_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_trigger_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
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
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> GetOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null,
                                                                          int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_trigger_openorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
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
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> GetHisOrderAsync(string contractCode, int tradeType, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = "created_at")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_trigger_hisorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": \"{tradeType}\",\"status\": \"{status}\",\"create_date\": \"{createDate}\"";
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
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_tpsl_order");

            return await HttpRequest.PostAsync<TpslOrderResponse>(url, JsonConvert.SerializeObject(request));
        }
        
        /// <summary>
        /// tpsl cancel
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> TpslCancelAsync(string contractCode, string orderId = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_tpsl_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_tpsl_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
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
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> GetTpslOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null,
                                                                              int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_tpsl_openorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
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
        /// <param name="contractCode"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> GetTpslHisOrderAsync(string contractCode, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = "created_at")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_tpsl_hisorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"status\": \"{status}\",\"create_date\": {createDate}";
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
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<GetRelationTpslOrderResponse> GetRelationTpslOrderAsync(string contractCode, long orderId)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_relation_tpsl_order");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"order_id\": {orderId}";
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
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_track_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// track cancel
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="offset"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> TrackCancelAsync(string contractCode = null, string orderId = null,
                                                                string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_track_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_track_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
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
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tradeType"></param>
        /// <returns></returns>
        public async Task<GetTrackOpenOrderResponse> GetTrackOpenOrderAsync(string contractCode = null,
                                                                  int? pageIndex = null, int? pageSize = null,
                                                                  int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_track_openorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
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

        public async Task<GetTrackHisOrderResponse> GetTrackHisOrderAsync(string contractCode, string status, int tradeType, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_track_hisorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": \"{tradeType}\",\"status\": \"{status}\",\"create_date\": \"{createDate}\"";
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
