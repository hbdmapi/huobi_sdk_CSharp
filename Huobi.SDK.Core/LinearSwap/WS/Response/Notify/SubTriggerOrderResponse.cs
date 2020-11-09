using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Notify
{
    public class SubTriggerOrderResponse
    {
        public string op { get; set; }

        public string topic { get; set; }

        public long ts { get; set; }

        public string uid { get; set; }

        [JsonProperty("event")]
        public string eventSender { get; set; }

        public List<Data> data { get; set; }

        public class Data
        {
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("trigger_type")]
            public string triggerType { get; set; }

            public double volume { get; set; }

            [JsonProperty("order_type")]
            public int orderType { get; set; }

            public string direction { get; set; }

            public string offset { get; set; }

            [JsonProperty("lever_rate")]
            public int leverRate { get; set; }

            [JsonProperty("order_id")]
            public long orderId { get; set; }

            [JsonProperty("order_id_str")]
            public string orderIdStr { get; set; }

            [JsonProperty("relation_order_id")]
            public string relationOrderId { get; set; }

            [JsonProperty("order_price_type")]
            public string orderPriceType { get; set; }

            public int status { get; set; }

            [JsonProperty("order_source")]
            public string orderSource { get; set; }

            [JsonProperty("trigger_price")]
            public double triggerPrice { get; set; }

            [JsonProperty("triggered_price", NullValueHandling = NullValueHandling.Ignore)]
            public double triggeredPrice { get; set; }

            [JsonProperty("order_price")]
            public double orderPrice { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            [JsonProperty("triggered_at", NullValueHandling = NullValueHandling.Ignore)]
            public long triggeredAt { get; set; }

            [JsonProperty("order_insert_at")]
            public long orderInsertAt { get; set; }

            [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
            public long canceledAt { get; set; }

            [JsonProperty("fail_code", NullValueHandling = NullValueHandling.Ignore)]
            public int failCode { get; set; }

            [JsonProperty("fail_reason", NullValueHandling = NullValueHandling.Ignore)]
            public string failReason { get; set; }
        }
    }
}