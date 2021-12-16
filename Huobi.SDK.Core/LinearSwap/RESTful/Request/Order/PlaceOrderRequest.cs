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

        [JsonProperty("tp_trigger_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? tpTriggerPrice { get; set; }

        [JsonProperty("tp_order_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? tpOrderPrice { get; set; }

        [JsonProperty("tp_order_price_type", NullValueHandling = NullValueHandling.Ignore)]
        public string tpOrderPriceType { get; set; }

        [JsonProperty("sl_trigger_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? slTriggerPrice { get; set; }

        [JsonProperty("sl_order_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? slOrderPrice { get; set; }

        [JsonProperty("sl_order_price_type", NullValueHandling = NullValueHandling.Ignore)]
        public string slOrderPriceType { get; set; }

        [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
        public string contractType { get; set; }

        [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
        public string pair { get; set; }
    }
}
