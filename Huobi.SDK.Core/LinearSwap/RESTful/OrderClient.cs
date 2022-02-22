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

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public OrderClient(string accessKey, string secretKey, string host = Host.FUTURES)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// isolated switch position mode
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="positionMode"></param>
        /// <returns></returns>
        public async Task<PositionModeResponse> IsolatedSwitchPositionModeAsync(string marginAccount, string positionMode)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_switch_position_mode");

            // content
            string content = "";
            if (marginAccount != null)
            {
                content += $",\"margin_account\": \"{marginAccount}\"";
            }
            if (positionMode != null)
            {
                content += $",\"position_mode\": \"{positionMode}\"";
            }

            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<PositionModeResponse>(url, content);
        }

        /// <summary>
        /// cross switch position mode
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="positionMode"></param>
        /// <returns></returns>
        public async Task<PositionModeResponse> CrossSwitchPositionModeAsync(string marginAccount, string positionMode)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_switch_position_mode");

            // content
            string content = "";
            if (marginAccount != null)
            {
                content += $",\"margin_account\": \"{marginAccount}\"";
            }
            if (positionMode != null)
            {
                content += $",\"position_mode\": \"{positionMode}\"";
            }

            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<PositionModeResponse>(url, content);
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
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> IsolatedCancelOrderAsync(string orderId = null, string clientOrderId = null,
                                                                        string contractCode = null)
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
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="contractCode"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CrossCancelOrderAsync(string orderId = null, string clientOrderId = null,
                                                                     string contractCode = null, string contractType = null,
                                                                     string pair = null)
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
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
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
        /// <param name="leverRate"></param>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public async Task<SwitchLeverRateResponse> IsolatedSwitchLeverRateAsync(int leverRate, string contractCode)
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
        /// <param name="leverRate"></param>
        /// <param name="contractCode"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<SwitchLeverRateResponse> CrossSwitchLeverRateAsync(int leverRate, string contractCode = null,
                                                                             string contractType = null, string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_switch_lever_rate");

            // content
            string content = null;
            content +=  $",\"lever_rate\": {leverRate}";
            if (contractCode != null)
            {
                content +=  $",\"contract_code\": \"{contractCode}\"";
            }
            if (contractType != null)
            {
                content +=  $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                 content +=  $",\"pair\": \"{pair}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

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
        /// <param name="orderId"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<GetOrderInfoResponse> CrossGetOrderInfoAsync(string orderId = null, string clientOrderId = null,
                                                                       string contractCode = null, string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_order_info");

            // content
            string content = null;
            if (orderId != null)
            {
                content += $",\"order_id\":\"{orderId}\"";
            }
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\":\"{clientOrderId}\"";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\":\"{contractCode}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\":\"{pair}\"";
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
        /// <param name="orderId"></param>
        /// <param name="createdAt"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<GetOrderDetailResponse> CrossGetOrderDetailAsync(long orderId, long? createdAt = null,
                                                                           int? orderType = null, int? pageIndex = null, int? pageSize = null,
                                                                           string contractCode = null, string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_order_detail");

            // content
            string content = $",\"order_id\": {orderId}";
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
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
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
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="tradeType"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <param name="tradePartition"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> CrossGetOpenOrderAsync(int? pageIndex = null, int? pageSize = null,
                                                                       string sortBy = null, int? tradeType = null,
                                                                       string contractCode = null, string pair = null,
                                                                       string tradePartition = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_openorders");

            // content
            string content = null;
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
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
            }
            if (tradePartition != null)
            {
                content += $",\"trade_partition\": \"{tradePartition}\"";
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
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> CrossGetHisOrderAsync(int tradeType, int type, string status,
                                                                     int createDate, int? pageIndex = null, int? pageSize = null,
                                                                     string sortBy = null, string contractCode = null, string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_hisorders");

            // content
            string content = $",\"trade_type\": \"{tradeType}\",\"type\": \"{type}\",\"status\": \"{status}\",\"create_date\": \"{createDate}\"";
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
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
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
        public async Task<GetHisOrderExactResponse> IsolatedGetHisOrderExactAsync(string contractCode, int tradeType, int type, string status,
                                                                                  string order_price_type = null, long? start_time = null, long? end_time = null,
                                                                                  long? from_id = null, int size = 200, string direct = "prev")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_hisorders_exact");

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
        /// cross margin hisorders exact
        /// </summary>
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="order_price_type"></param>
        /// <param name="start_time"></param>
        /// <param name="end_time"></param>
        /// <param name="from_id"></param>
        /// <param name="size"></param>
        /// <param name="direct"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<GetHisOrderExactResponse> CrossGetHisOrderExactAsync(int tradeType, int type, string status,
                                                                               string order_price_type = null, long? start_time = null, long? end_time = null,
                                                                               long? from_id = null, int size = 200, string direct = "prev",
                                                                               string contractCode = null, string pair = null )
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_hisorders_exact");

            // content
            string content = $",\"trade_type\": \"{tradeType}\",\"type\": \"{type}\",\"status\": \"{status}\",\"size\": {size},\"direct\": \"{direct}\"";
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
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderExactResponse>(url, content);
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
        /// cross margin get his match record
        /// </summary>
        /// <param name="tradeType"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<GetHisMatchResponse> CrossGetHisMatchAsync(int tradeType, int createDate,
                                                                     int? pageIndex = null, int? pageSize = null,
                                                                     string contractCode = null, string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_matchresults");

            // content
            string content = $",\"trade_type\": {tradeType},\"create_date\": \"{createDate}\"";
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
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
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
        /// isolate margin, matchresults exact
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="start_time"></param>
        /// <param name="end_time"></param>
        /// <param name="from_id"></param>
        /// <param name="size"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public async Task<GetHisMatchExactResponse> IsolatedGetHisMatchExactAsync(string contractCode, int tradeType,
                                                                                  long? start_time = null, long? end_time = null,
                                                                                  long? from_id = null, int size = 200, string direct = "prev")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_matchresults_exact");

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

        /// <summary>
        /// isolate margin, matchresults exact
        /// </summary>
        /// <param name="tradeType"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="order_price_type"></param>
        /// <param name="start_time"></param>
        /// <param name="end_time"></param>
        /// <param name="from_id"></param>
        /// <param name="size"></param>
        /// <param name="direct"></param>
        /// <param name="contractCode"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<GetHisMatchExactResponse> CrossGetHisMatchExactAsync(int tradeType, long? start_time = null, long? end_time = null,
                                                                               long? from_id = null, int size = 200, string direct = "prev",
                                                                               string contractCode = null, string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_matchresults_exact");

            // content
            string content = $",\"trade_type\": {tradeType},\"size\": {size},\"direct\": \"{direct}\"";
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
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisMatchExactResponse>(url, content);
        }

        /// <summary>
        /// cross margin lightning close
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="direction"></param>
        /// <param name="clientOrderId"></param>
        /// <param name="orderPriceType"></param>
        /// <param name="contractCode"></param>
        /// <param name="contractType"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<LightningCloseResponse> CrossLightningCloseAsync(double volume, string direction,
                                                                           long? clientOrderId = null, string orderPriceType = null,
                                                                           string contractCode = null, string contractType = null,
                                                                           string pair = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_lightning_close_position");

            // content
            string content = $",\"volume\": {volume},\"direction\": \"{direction}\"";
            if (clientOrderId != null)
            {
                content += $",\"client_order_id\": {clientOrderId}";
            }
            if (orderPriceType != null)
            {
                content += $",\"order_price_type\": \"{orderPriceType}\"";
            }
            if (contractCode != null)
            {
                content += $",\"contract_code\": \"{contractCode}\"";
            }
            if (contractType != null)
            {
                content += $",\"contract_type\": \"{contractType}\"";
            }
            if (pair != null)
            {
                content += $",\"pair\": \"{pair}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<LightningCloseResponse>(url, content);
        }
        
    }
}
