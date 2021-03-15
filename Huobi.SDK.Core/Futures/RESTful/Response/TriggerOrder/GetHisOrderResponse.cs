using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.TriggerOrder
{
    /// <summary>
    /// The response for his order request
    /// </summary>
    public class GetHisOrderResponse
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
            public List<Order> orders { get; set; }

            public class Order
            {
                public string symbol { get; set; }

                [JsonProperty("contract_type")]
                public string contractType { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("trigger_type")]
                public string triggerType { get; set; }

                public double volume { get; set; }

                [JsonProperty("order_type")]
                public int orderType { get; set; }

                [JsonProperty("tpsl_order_type", NullValueHandling = NullValueHandling.Ignore)]
                public string tpslOrderType { get; set; }

                public string direction { get; set; }

                [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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

                [JsonProperty("update_time")]
                public long updateTime { get; set; }

                [JsonProperty("fail_code", NullValueHandling = NullValueHandling.Ignore)]
                public int failCode { get; set; }

                [JsonProperty("fail_reason", NullValueHandling = NullValueHandling.Ignore)]
                public string failReason { get; set; }

                [JsonProperty("source_order_id", NullValueHandling = NullValueHandling.Ignore)]
                public string sourceOrderId { get; set; }

                [JsonProperty("relation_tpsl_order_id", NullValueHandling = NullValueHandling.Ignore)]
                public string relationTpslOrderId { get; set; }
            }

            [JsonProperty("total_page")]
            public int totalPage { get; set; }

            [JsonProperty("current_page")]
            public int currentPage { get; set; }

            [JsonProperty("total_size")]
            public int totalSize { get; set; }
        }
    }
}
