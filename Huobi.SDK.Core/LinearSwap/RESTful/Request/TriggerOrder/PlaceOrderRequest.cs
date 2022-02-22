using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder
{
    public class PlaceOrderRequest 
    {
        [JsonProperty("trigger_type")]
        public string triggerType { get; set; }

        [JsonProperty("trigger_price")]
        public double triggerPrice { get; set; }

        [JsonProperty("order_price")]
        public double? orderPrice { get; set; }

        [JsonProperty("order_price_type")]
        public string orderPriceType { get; set; }

        public long volume { get; set; }

        public string direction { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string offset { get; set; }

        [JsonProperty("lever_rate")]
        public int? leverRate { get; set; }

        [JsonProperty("contract_code", NullValueHandling = NullValueHandling.Ignore)]
        public string contractCode { get; set; }

        [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
        public string contractType { get; set; }

        [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
        public string pair { get; set; }

        [JsonProperty("reduce_only", NullValueHandling = NullValueHandling.Ignore)]
        public int? reduceOnly { get; set; }
    }
}
