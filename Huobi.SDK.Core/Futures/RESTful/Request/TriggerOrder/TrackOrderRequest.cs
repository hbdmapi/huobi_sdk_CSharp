using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Request.TriggerOrder
{
    public class TrackOrderRequest 
    {
        public string symbol { get; set; }

        [JsonProperty("contract_type")]
        public string contractType { get; set; }

        [JsonProperty("contract_code")]
        public string contractCode { get; set; }

        public string direction { get; set; }

        public string offset { get; set; }

        [JsonProperty("lever_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int leverRate { get; set; }

        public double volume { get; set; }

        [JsonProperty("callback_rate")]
        public double callbackRate { get; set; }
        
        [JsonProperty("active_price")]
        public double activePrice { get; set; }

        [JsonProperty("order_price_type")]
        public string orderPriceType { get; set; }
    }
}
