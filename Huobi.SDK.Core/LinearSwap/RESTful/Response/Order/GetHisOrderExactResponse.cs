using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Order
{
    public class GetHisOrderExactResponse
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
            public List<Orders> orders { get; set; }

            public class Orders
            {

                [JsonProperty("query_id")]
                public long queryId { get; set; }

                [JsonProperty("order_id")]
                public long orderId { get; set; }

                [JsonProperty("order_id_str")]
                public string orderIdStr { get; set; }

                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("margin_mode")]
                public string marginMode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }

                [JsonProperty("lever_rate")]
                public int leverRate { get; set; }

                public string direction { get; set; }

                public string offset { get; set; }

                public double volume { get; set; }

                public double price { get; set; }

                [JsonProperty("create_date")]
                public long createDate { get; set; }

                [JsonProperty("order_source")]
                public string orderSource { get; set; }

                [JsonProperty("order_price_type")]
                public string orderPriceType { get; set; }

                [JsonProperty("margin_frozen")]
                public double marginFrozen { get; set; }

                public double profit { get; set; }

                [JsonProperty("real_profit")]
                public double realProfit { get; set; }

                [JsonProperty("trade_volume")]
                public double tradeVolume { get; set; }

                [JsonProperty("trade_turnover")]
                public double tradeTurnover { get; set; }

                public double fee { get; set; }

                [JsonProperty("trade_avg_price")]
                public double tradeAvgPrice { get; set; }

                public int status { get; set; }

                [JsonProperty("order_type")]
                public int orderType { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset { get; set; }

                [JsonProperty("liquidation_type")]
                public string liquidationType { get; set; }

                [JsonProperty("is_tpsl")]
                public int isTpsl { get; set; }

                [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
                public string contractType { get; set; }

                [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
                public string pair { get; set; }

                [JsonProperty("business_type", NullValueHandling = NullValueHandling.Ignore)]
                public string businessType { get; set; }
            }

            [JsonProperty("remain_size")]
            public int remainSize { get; set; }

            [JsonProperty("next_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? nextId { get; set; }
        }
    }
}
