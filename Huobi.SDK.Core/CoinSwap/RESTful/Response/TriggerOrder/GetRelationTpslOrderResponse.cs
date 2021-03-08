using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.TriggerOrder
{
    /// <summary>
    /// The response for open order request
    /// </summary>
    public class GetRelationTpslOrderResponse
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
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            public double volume { get; set; }

            public double price { get; set; }

            [JsonProperty("order_price_type")]
            public string orderPriceType { get; set; }

            public string direction { get; set; }

            public string offset { get; set; }

            [JsonProperty("lever_rate")]
            public int leverRate { get; set; }

            [JsonProperty("order_id")]
            public long orderId { get; set; }

            [JsonProperty("order_id_str")]
            public string orderIdStr { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            [JsonProperty("trade_volume")]
            public double tradeVolume { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }

            public double fee { get; set; }

            [JsonProperty("trade_avg_price")]
            public double tradeAvgPrice { get; set; }

            [JsonProperty("marginFrozen")]
            public double margin_frozen { get; set; }

            public double profit { get; set; }

            public int status { get; set; }

            [JsonProperty("order_type")]
            public int orderType { get; set; }

            [JsonProperty("order_source")]
            public string orderSource { get; set; }

            [JsonProperty("fee_asset")]
            public string feeAsset { get; set; }

            [JsonProperty("canceled_at")]
            public long canceledAt { get; set; }

            public List<TpslOrderInfo> tpsl_order_info { get; set; }

            public class TpslOrderInfo
            {

                public double volume { get; set; }

                [JsonProperty("tpsl_order_type")]
                public string tpslOrderType { get; set; }

                public string direction { get; set; }

                [JsonProperty("order_id")]
                public long orderId { get; set; }

                [JsonProperty("order_id_str")]
                public string orderIdStr { get; set; }

                [JsonProperty("trigger_type")]
                public string triggerType { get; set; }

                [JsonProperty("trigger_price")]
                public double triggerPrice { get; set; }

                [JsonProperty("order_price")]
                public double orderPrice { get; set; }

                [JsonProperty("created_at")]
                public long createdAt { get; set; }

                [JsonProperty("order_price_type")]
                public string orderPriceType { get; set; }

                public int status { get; set; }

                [JsonProperty("relation_tpsl_order_id")]
                public string relationTpslOrderId { get; set; }

                [JsonProperty("canceled_at")]
                public long canceledAt { get; set; }

                [JsonProperty("fail_code")]
                public int failCode { get; set; }

                [JsonProperty("fail_reason")]
                public string failReason { get; set; }

                [JsonProperty("triggered_price")]
                public double triggeredPrice { get; set; }

                [JsonProperty("relation_order_id")]
                public string relationOrderId { get; set; }

            }
        }
    }
}
