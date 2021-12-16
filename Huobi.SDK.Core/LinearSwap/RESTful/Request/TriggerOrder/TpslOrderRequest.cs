﻿using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder
{
    public class TpslOrderRequest
    {
        public string direction { get; set; }

        public long volume { get; set; }

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

        [JsonProperty("contract_code", NullValueHandling = NullValueHandling.Ignore)]
        public string contractCode { get; set; }

        [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
        public string contractType { get; set; }

        [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
        public string pair { get; set; }
    }
}
