using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using System;
using Huobi.SDK.Core.CoinSwap.RESTful.Request.Order;
using Huobi.SDK.Core.CoinSwap.RESTful.Response.Order;

namespace Huobi.SDK.Core.CoinSwap.RESTful
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
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_order");

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
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_batchorder");

            // content
            string content = JsonConvert.SerializeObject(requests);
            content = $"{{ \"orders_data\":{content} }}";
            return await HttpRequest.PostAsync<PlaceBatchOrderResponse>(url, content);
        }

        /// <summary>
        /// cancel all order if orderId and clientOrderId are null <br/>
        /// place set one of orderId/clientOrderId value when cancel one order. orderId is valid if orderId and clientOrderId are set value both.
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CancelOrderAsync(string contractCode, string orderId = null, string clientOrderId = null,
                                                                        string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_cancel");
            if (orderId == null && clientOrderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\": {clientOrderId}";
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
        /// <param name="contractCode"></param>
        /// <param name="leverRate"></param>
        /// <returns></returns>
        public async Task<SwitchLeverRateResponse> SwitchLeverRateAsync(string contractCode, int leverRate)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_switch_lever_rate");

            // content
            string content = $"{{\"contract_code\": \"{contractCode}\", \"lever_rate\": {leverRate}}}";

            return await HttpRequest.PostAsync<SwitchLeverRateResponse>(url, content);
        }
        
        /// <summary>
        /// get order information
        /// just and must one of orderId/clientOrderId has value
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId">multi orders split with,</param>
        /// <param name="clientOrderId">multi orders split with,</param>
        /// <returns></returns>
        public async Task<GetOrderInfoResponse> GetOrderInfoAsync(string contractCode, string orderId = null, string clientOrderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_order_info");

            // content
            string content = $",\"contract_code\":\"{contractCode}\"";
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
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="createdAt"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOrderDetailResponse> GetOrderDetailAsync(string contractCode, long orderId, long? createdAt = null,
                                                                int? orderType = null, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_order_detail");

            // content
            string content = $",\"contract_code\": \"{contractCode}\", \"order_id\": {orderId}";
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
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> GetOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null,
                                                                          string sortBy = null, int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_openorders");

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
        public async Task<GetHisOrderResponse> GetHisOrderAsync(string contractCode, int tradeType, int type, string status,
                                                                int createDate, int? pageIndex = null, int? pageSize = null,
                                                                string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_hisorders");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": \"{tradeType}\",\"type\": \"{type}\",\"status\": \"{status}\",\"create_date\": \"{createDate}\"";
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
        /// isoated margin hisorders exact
        /// </summary>
        /// <param name="contractCode"></param>
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
        public async Task<GetHisOrderExactResponse> GetHisOrderExactAsync(string contractCode, int tradeType, int type, string status,
                                                                string order_price_type = null, long? start_time = null, long? end_time = null,
                                                                long? from_id = null, int size = 200, string direct = "prev")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_hisorders_exact");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": \"{tradeType}\",\"type\": \"{type}\",\"status\": \"{status}\",\"size\": {size},\"direct\": \"{direct}\"";
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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderExactResponse>(url, content);
        }
        
        /// <summary>
        /// get his match record
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisMatchResponse> GetHisMatchAsync(string contractCode, int tradeType, int createDate,
                                                                int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_matchresults");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": {tradeType},\"create_date\": \"{createDate}\"";
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
        /// lightning close
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="volume"></param>
        /// <param name="direction"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="orderPriceType"></param>
        /// <returns></returns>
        public async Task<LightningCloseResponse> LightningCloseAsync(string contractCode, double volume, string direction,
                                                                      long? clientOrderId = null, string orderPriceType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_lightning_close_position");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"volume\": {volume},\"direction\": \"{direction}\"";
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
        public async Task<GetHisMatchExactResponse> GetHisMatchExactAsync(string contractCode, int tradeType,
                                                                        long? start_time = null, long? end_time = null,
                                                                        long? from_id = null, int size = 200, string direct = "prev")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/swap-api/v1/swap_matchresults_exact");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": {tradeType},\"size\": {size},\"direct\": \"{direct}\"";
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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisMatchExactResponse>(url, content);
        }
        
    }
}
