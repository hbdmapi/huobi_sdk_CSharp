using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Order
{
    public class GetHisMatchExactResponse
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
            public List<Trades> trades { get; set; }

            public class Trades
            {
                public string id { get; set; }

                [JsonProperty("query_id")]
                public long queryId { get; set; }

                [JsonProperty("match_id")]
                public long matchId { get; set; }

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

                public string direction { get; set; }

                public string offset { get; set; }

                [JsonProperty("trade_volume")]
                public double tradeVolume { get; set; }

                [JsonProperty("trade_price")]
                public double tradePrice { get; set; }

                [JsonProperty("trade_turnover")]
                public double tradeTurnover { get; set; }

                [JsonProperty("create_date")]
                public long createDate { get; set; }

                [JsonProperty("offset_profitloss")]
                public double offsetProfitloss { get; set; }

                [JsonProperty("real_profit")]
                public double realProfit { get; set; }

                [JsonProperty("trade_fee")]
                public double trade_fee { get; set; }

                public string role { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset { get; set; }

                [JsonProperty("order_source")]
                public string orderSource { get; set; }

                [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
                public string contractType { get; set; }

                [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
                public string pair { get; set; }

                [JsonProperty("business_type", NullValueHandling = NullValueHandling.Ignore)]
                public string businessType { get; set; }

                [JsonProperty("trade_partition")]
                public string tradePartition { get; set; }

                [JsonProperty("reduce_only")]
                public int reduceOnly { get; set; }
            }

            [JsonProperty("remain_size")]
            public int remainSize { get; set; }

            [JsonProperty("next_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? nextId { get; set; }
        }
    }
}
