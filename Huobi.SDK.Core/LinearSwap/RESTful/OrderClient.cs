using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using System;
using Huobi.SDK.Core.LinearSwap.RESTful.Request.Order;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Order;

namespace Huobi.SDK.Core.LinearSwap.RESTful
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
        /// isolated margin Place a new order and send to the exchange to be matched.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> IsolatedPlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// cross margin Place a new order and send to the exchange to be matched.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> CrossPlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// isolated margin Place multipler orders (at most 10 orders)
        /// </summary>
        /// <param name="requests"></param>
        /// <returns>PlaceOrdersResponse</returns>
        public async Task<PlaceBatchOrderResponse> IsolatedPlaceBatchOrderAsync(PlaceOrderRequest[] requests)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_batchorder");

            // content
            string content = JsonConvert.SerializeObject(requests);
            content = $"{{ \"orders_data\":{content} }}";
            return await HttpRequest.PostAsync<PlaceBatchOrderResponse>(url, content);
        }

        /// <summary>
        /// cross margin Place multipler orders (at most 10 orders)
        /// </summary>
        /// <param name="requests"></param>
        /// <returns>PlaceOrdersResponse</returns>
        public async Task<PlaceBatchOrderResponse> CrossPlaceBatchOrderAsync(PlaceOrderRequest[] requests)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_batchorder");

            // content
            string content = JsonConvert.SerializeObject(requests);
            content = $"{{ \"orders_data\":{content} }}";
            return await HttpRequest.PostAsync<PlaceBatchOrderResponse>(url, content);
        }

        /// <summary>
        /// isolated margin cancel all order if orderId and clientOrderId are null <br/>
        /// place set one of orderId/clientOrderId value when cancel one order. orderId is valid if orderId and clientOrderId are set value both.
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> IsolatedCancelOrderAsync(string contractCode, string orderId = null, string clientOrderId = null,
                                                                        string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cancel");
            if (orderId == null && clientOrderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cancelall");
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
        /// cross margin cancel all order if orderId and clientOrderId are null <br/>
        /// place set one of orderId/clientOrderId value when cancel one order. orderId is valid if orderId and clientOrderId are set value both.
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CrossCancelOrderAsync(string contractCode, string orderId = null, string clientOrderId = null,
                                                                     string offset = null, string direction = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_cancel");
            if (orderId == null && clientOrderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_cancelall");
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
        /// isolated margin switch contract code's lever rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="leverRate"></param>
        /// <returns></returns>
        public async Task<SwitchLeverRateResponse> IsolatedSwitchLeverRateAsync(string contractCode, int leverRate)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_switch_lever_rate");

            // content
            string content = $"{{\"contract_code\": \"{contractCode}\", \"lever_rate\": {leverRate}}}";

            return await HttpRequest.PostAsync<SwitchLeverRateResponse>(url, content);
        }

        /// <summary>
        /// cross margin switch contract code's lever rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="leverRate"></param>
        /// <returns></returns>
        public async Task<SwitchLeverRateResponse> CrossSwitchLeverRateAsync(string contractCode, int leverRate)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_switch_lever_rate");

            // content
            string content = $"{{\"contract_code\": \"{contractCode}\", \"lever_rate\": {leverRate}}}";

            return await HttpRequest.PostAsync<SwitchLeverRateResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get order information
        /// just and must one of orderId/clientOrderId has value
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId">multi orders split with,</param>
        /// <param name="clientOrderId">multi orders split with,</param>
        /// <returns></returns>
        public async Task<GetOrderInfoResponse> IsolatedGetOrderInfoAsync(string contractCode, string orderId = null, string clientOrderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_order_info");

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
        /// cross margin get order information
        /// just and must one of orderId/clientOrderId has value
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId">multi orders split with,</param>
        /// <param name="clientOrderId">multi orders split with,</param>
        /// <returns></returns>
        public async Task<GetOrderInfoResponse> CrossGetOrderInfoAsync(string contractCode, string orderId = null, string clientOrderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_order_info");

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
        /// isolated margin get order detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="createdAt"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOrderDetailResponse> IsolatedGetOrderDetailAsync(string contractCode, long orderId, long? createdAt = null,
                                                                int? orderType = null, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_order_detail");

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
        /// cross margin get order detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <param name="createdAt"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOrderDetailResponse> CrossGetOrderDetailAsync(string contractCode, long orderId, long? createdAt = null,
                                                                int? orderType = null, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_order_detail");

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
        /// isolated margin get open order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> IsolatedGetOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null,
                                                                          string sortBy = null, int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_openorders");

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
        /// cross margin get open order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> CrossGetOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null,
                                                                       string sortBy = null, int? tradeType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_openorders");

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
        /// isolated margin get his order info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> IsolatedGetHisOrderAsync(string contractCode, int tradeType, int type, string status,
                                                                int createDate, int? pageIndex = null, int? pageSize = null,
                                                                string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_hisorders");

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
        /// cross margin get his order info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> CrossGetHisOrderAsync(string contractCode, int tradeType, int type, string status,
                                                                int createDate, int? pageIndex = null, int? pageSize = null,
                                                                string sortBy = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_hisorders");

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
        /// isolated margin get his match record
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisMatchResponse> IsolatedGetHisMatchAsync(string contractCode, int tradeType, int createDate,
                                                                int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_matchresults");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": \"{tradeType}\",\"create_date\": \"{createDate}\"";
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
        /// cross margin get his match record
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisMatchResponse> CrossGetHisMatchAsync(string contractCode, int tradeType, int createDate,
                                                                int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_matchresults");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"trade_type\": \"{tradeType}\",\"create_date\": \"{createDate}\"";
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
        /// isolated margin lightning close
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="volume"></param>
        /// <param name="direction"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="orderPriceType"></param>
        /// <returns></returns>
        public async Task<LightningCloseResponse> IsolatedLightningCloseAsync(string contractCode, double volume, string direction,
                                                                      long? clientOrderId = null, string orderPriceType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_lightning_close_position");

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
        /// cross margin lightning close
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="volume"></param>
        /// <param name="direction"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="orderPriceType"></param>
        /// <returns></returns>
        public async Task<LightningCloseResponse> CrossLightningCloseAsync(string contractCode, double volume, string direction,
                                                                      long? clientOrderId = null, string orderPriceType = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_lightning_close_position");

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
        
    }
}
