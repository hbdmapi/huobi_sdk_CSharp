using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder
{
    public class TrackOrderRequest 
    {
        public string direction { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string offset { get; set; }

        [JsonProperty("lever_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int leverRate { get; set; }

        public int volume { get; set; }

        [JsonProperty("callback_rate")]
        public double callbackRate { get; set; }
        
        [JsonProperty("active_price")]
        public double activePrice { get; set; }

        [JsonProperty("order_price_type")]
        public string orderPriceType { get; set; }

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
