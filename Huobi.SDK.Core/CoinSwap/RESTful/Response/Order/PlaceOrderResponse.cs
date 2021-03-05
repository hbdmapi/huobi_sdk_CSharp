using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Order
{
    public class PlaceOrderResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public class Data
        {
            [JsonProperty("order_id")]
            public long orderId { get; set; }

            [JsonProperty("client_order_id", NullValueHandling = NullValueHandling.Ignore)]
            public long clientOrderId { get; set; }

            [JsonProperty("order_id_str")]
            public string orderIdStr { get; set; }
        }
    }
}
