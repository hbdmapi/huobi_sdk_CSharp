using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Request.TriggerOrder
{
    public class TpslOrderRequest 
    {
        public string symbol { get; set; }

        [JsonProperty("contract_type")]
        public string contractType { get; set; }

        [JsonProperty("contract_code")]
        public string contractCode { get; set; }

        public string direction { get; set; }

        public long volume { get; set; }

        [JsonProperty("tp_trigger_price")]
        public double tpTriggerPrice { get; set; }

        [JsonProperty("tp_order_price")]
        public double tpOrderPrice { get; set; }
        
        [JsonProperty("tp_order_price_type")]
        public string tpOrderPriceType { get; set; }

        [JsonProperty("sl_trigger_price")]
        public double slTriggerPrice { get; set; }

        [JsonProperty("sl_order_price")]
        public double slOrderPrice { get; set; }
        
        [JsonProperty("sl_order_price_type")]
        public string slOrderPriceType { get; set; }
    }
}
