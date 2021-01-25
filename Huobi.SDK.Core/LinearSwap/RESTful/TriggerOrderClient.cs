using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using System;
using Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.TriggerOrder;

namespace Huobi.SDK.Core.LinearSwap.RESTful
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
        /// isolated margin Place a new order and send to the exchange to be matched.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> IsolatedPlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_trigger_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// cross margin Place a new order and send to the exchange to be matched.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> CrossPlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_trigger_order");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// isolated margin cancel all order if orderId is null, else cancel some orders what orderId set
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> IsolatedCancelOrderAsync(string contractCode, string orderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_trigger_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_trigger_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// cross margin cancel all order if orderId is null, else cancel some orders what orderId set
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CrossCancelOrderAsync(string contractCode, string orderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_trigger_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_trigger_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get open order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> IsolatedGetOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_trigger_openorders");

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
        public async Task<GetOpenOrderResponse> CrossGetOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_trigger_openorders");

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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetOpenOrderResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get his order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> IsolatedGetHisOrderAsync(string contractCode, int tradeType, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_trigger_hisorders");

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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderResponse>(url, content);
        }

        /// <summary>
        /// cross margin get his order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="tradeType"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> CrossGetHisOrderAsync(string contractCode, int tradeType, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_trigger_hisorders");

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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetHisOrderResponse>(url, content);
        }

        /// <summary>
        /// isolated margin tpsl order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TpslOrderResponse> IsolatedTpslOrderAsync(TpslOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_tpsl_order");

            return await HttpRequest.PostAsync<TpslOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// cross margin tpsl order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TpslOrderResponse> CrossTpslOrderAsync(TpslOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_tpsl_order");

            return await HttpRequest.PostAsync<TpslOrderResponse>(url, JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// isolated margin tpsl cancel
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> IsolatedTpslCancelAsync(string contractCode, string orderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_tpsl_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_tpsl_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// cross margin tpsl cancel 
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CancelOrderResponse> CrossTpslCancelAsync(string contractCode, string orderId = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_tpsl_cancel");
            if (orderId == null)
            {
                url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_tpsl_cancelall");
            }

            // content
            string content = $",\"contract_code\": \"{contractCode}\"";
            if (orderId != null)
            {
                content += $",\"order_id\": \"{orderId}\"";
            }
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<CancelOrderResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get tpsl open order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> IsolatedGetTpslOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_tpsl_openorders");

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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetOpenOrderResponse>(url, content);
        }

        /// <summary>
        /// cross margin get rpsl open order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<GetOpenOrderResponse> CrossGetTpslOpenOrderAsync(string contractCode, int? pageIndex = null, int? pageSize = null)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_tpsl_openorders");

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
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetOpenOrderResponse>(url, content);
        }

        /// <summary>
        /// isolated margin get tpsl his order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> IsolatedGetTpslHisOrderAsync(string contractCode, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = "created_at")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_tpsl_hisorders");

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
        /// cross margin get tpsl his order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="status"></param>
        /// <param name="createDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<GetHisOrderResponse> CrossGetTpslHisOrderAsync(string contractCode, string status, int createDate,
                                                                int? pageIndex = null, int? pageSize = null, string sortBy = "created_at")
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_tpsl_hisorders");

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
        /// isolated margin get relation tpsl order 
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<GetRelationTpslOrderResponse> IsolatedGetRelationTpslOrderAsync(string contractCode, long orderId)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_relation_tpsl_order");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"order_id\": {orderId}";
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetRelationTpslOrderResponse>(url, content);
        }

        /// <summary>
        /// cross margin relation tpsl order 
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<GetRelationTpslOrderResponse> CrossGetRelationTpslOrderAsync(string contractCode, long orderId)
        {
            // url
            string url = _urlBuilder.Build(POST_METHOD, "/linear-swap-api/v1/swap_cross_relation_tpsl_order");

            // content
            string content = $",\"contract_code\": \"{contractCode}\",\"order_id\": {orderId}";
            if (content != null)
            {
                content = $"{{ {content.Substring(1)} }}";
            }

            return await HttpRequest.PostAsync<GetRelationTpslOrderResponse>(url, content);
        }

    }
}
