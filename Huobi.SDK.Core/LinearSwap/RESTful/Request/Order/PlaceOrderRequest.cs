using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Request.Order
{
    public class PlaceOrderRequest
    {
        [JsonProperty("contract_code")]
        public string contractCode { get; set; }

        [JsonProperty("client_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? clientOrderId { get; set; }

        public double price { get; set; }

        public long volume { get; set; }

        public string direction { get; set; }

        public string offset { get; set; }

        [JsonProperty("lever_rate")]
        public int leverRate { get; set; }

        [JsonProperty("order_price_type")]
        public string orderPriceType { get; set; }
    }
}
