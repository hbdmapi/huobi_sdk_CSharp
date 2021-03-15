using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using System;
using Huobi.SDK.Core.Futures.RESTful.Request.Order;
using Huobi.SDK.Core.Futures.RESTful.Response.Order;

namespace Huobi.SDK.Core.Futures.RESTful
{
    public class OrderClient
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
        public OrderClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
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
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// Place multipler orders (at most 10 orders)
        /// </summary>
        /// <param name="requests"></param>
        /// <returns>PlaceOrdersResponse</returns>
        public async Task<PlaceBatchOrderResponse> PlaceBatchOrderAsync(PlaceOrderRequest[] requests)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_batchorder");

            // content
            string content = JsonConvert.SerializeObject(requests);
            content = $"{{ \"orders_data\":{content} }}";
            return await HttpRequest.PostAsync<PlaceBatchOrderResponse>(url, content);
        }

        /// <summary>
        /// cancel all order if orderId and clientOrderId are null <br/>
        /// place set one of orderId/clientOrderId value when cancel one order. orderId is valid if orderId and clientOrderId are set value both.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="contractCode"></param>
        /// <param name="contractType"></param>
        /// <param name="offset"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CancelOrderAsync(string symbol, string orderId = null, string clientOrderId = null,
                                                                string contractCode = null, string contractType = null,
                                                                string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_cancel");
            if (orderId == null && clientOrderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_cancelall");
            }

            // content
            string content = $",\"symbol\": \"{symbol}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\": {clientOrderId}";
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
        /// switch contract code's lever rate
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="leverRate"></param>
        /// <returns></returns>
        public async Task<SwitchLeverRateResponse> SwitchLeverRateAsync(string symbol, int leverRate)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_switch_lever_rate");

            // content
            string content = $"{{\"symbol\": \"{symbol}\", \"lever_rate\": {leverRate}}}";

            return await HttpRequest.PostAsync<SwitchLeverRateResponse>(url, content);
        }

        /// <summary>
        /// get order information
        /// just and must one of orderId/clientOrderId has value
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId">multi orders split with,</param>
        /// <param name="clientOrderId">multi orders split with,</param>
        /// <returns></returns>
        public async Task<GetOrderInfoResponse> GetOrderInfoAsync(string symbol, string orderId = null, string clientOrderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_order_info");

            // content
            string content = $",\"symbol\":\"{symbol}\"";
            if (orderId != null)
            {
                content += $",\"order_id\":\"{orderId}\"";
            }
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\":\"{clientOrderId}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetOrderInfoResponse>(url, content);
        }

        /// <summary>
        /// get order detail
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <param name="createdAt"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOrderDetailResponse> GetOrderDetailAsync(string symbol, long orderId, long? createdAt = null,
                                                                int? orderType = null, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_order_detail");

            // content
            string content = $",\"symbol\": \"{symbol}\", \"order_id\": {orderId}";
            if (createdAt != null)
            {
                content += $",\"created_at\": {createdAt}";
            }
            if (orderType != null)
            {
                content += $",\"order_type\": {orderType}";
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

            return await HttpRequest.PostAsync<GetOrderDetailResponse>(url, content);
        }

        /// <summary>
        /// get open order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> GetOpenOrderAsync(string symbol, int? pageIndex = null, int? pageSize = null,
                                                                  string sortBy = null, int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_openorders");

            // content
            string content = $",\"symbol\": \"{symbol}\"";
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
        /// get his order info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> GetHisOrderAsync(string symbol, int tradeType, int type, string status,
                                                                int createDate, int? pageIndex = null, int? pageSize = null,
                                                                string contractCode = null, string orderType =null, string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_hisorders");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"trade_type\": {tradeType},\"type\": {type},\"status\": \"{status}\",\"create_date\": {createDate}";
            if (pageIndex != null)
            {
                content += $",\"page_index\": {pageIndex}";
            }
            if (pageSize != null)
            {
                content += $",\"page_size\": {pageSize}";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (orderType != null)
            {
                content += $",\"order_type\": \"{orderType}\"";
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
        /// hisorders exact
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="order_price_type"></param>
        /// <param name="start_time"></param>
        /// <param name="end_time"></param>
        /// <param name="from_id"></param>
        /// <param name="size"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public async Task<GetHisOrderExactResponse> GetHisOrderExactAsync(string symbol, int tradeType, int type, string status, string contractCode = null,
                                                                string order_price_type = null, long? start_time = null, long? end_time = null,
                                                                long? from_id = null, int? size = null, string direct = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_hisorders_exact");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"trade_type\": \"{tradeType}\",\"type\": \"{type}\",\"status\": \"{status}\"";
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (order_price_type != null)
            {
                content += $",\"order_price_type\": \"{order_price_type}\"";
            }
            if (start_time != null)
            {
                content += $",\"start_time\": {start_time}";
            }
            if (end_time != null)
            {
                content += $",\"end_time\": {end_time}";
            }
            if (from_id != null)
            {
                content += $",\"from_id\": {from_id}";
            }
            if (size != null)
            {
                content += $",\"size\": {size}";
            }
            if (direct != null)
            {
                content += $",\"direct\": \"{direct}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderExactResponse>(url, content);
        }

        /// <summary>
        /// get his match record
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisMatchResponse> GetHisMatchAsync(string symbol, int tradeType, int createDate,
                                                                string contractCode = null, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_matchresults");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"trade_type\": {tradeType},\"create_date\": \"{createDate}\"";
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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisMatchResponse>(url, content);
        }

        /// <summary>
        /// matchresults exact
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="start_time"></param>
        /// <param name="end_time"></param>
        /// <param name="from_id"></param>
        /// <param name="size"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public async Task<GetHisMatchExactResponse> GetHisMatchExactAsync(string symbol, int tradeType, string contractCode,
                                                                          long? start_time, long? end_time, long? from_id,
                                                                          int? size, string direct)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/contract_matchresults_exact");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"trade_type\": {tradeType}";
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (start_time != null)
            {
                content += $",\"start_time\": {start_time}";
            }
            if (end_time != null)
            {
                content += $",\"end_time\": {end_time}";
            }
            if (from_id != null)
            {
                content += $",\"from_id\": {from_id}";
            }
            if (size != null)
            {
                content += $",\"size\": {size}";
            }
            if (direct != null)
            {
                content += $",\"direct\": \"{direct}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisMatchExactResponse>(url, content);
        }

        /// <summary>
        /// lightning close
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="volume"></param>
        /// <param name="direction"></param>
        /// <param name="contractType"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="orderPriceType"></param>
        /// <returns></returns>
        public async Task<LightningCloseResponse> LightningCloseAsync(string symbol, double volume, string direction, string contractType = null,
                                                                      string contractCode = null, long? clientOrderId = null, string orderPriceType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/api/v1/lightning_close_position");

            // content
            string content = $",\"symbol\": \"{symbol}\",\"volume\": {volume},\"direction\": \"{direction}\"";
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\": {clientOrderId}";
            }
            if (orderPriceType != null)
            {
                content += $",\"order_price_type\": \"{orderPriceType}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<LightningCloseResponse>(url, content);
        }
        
    }
}
