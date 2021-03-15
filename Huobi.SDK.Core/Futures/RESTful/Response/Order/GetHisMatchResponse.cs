using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Order
{
    /// <summary>
    /// The response for his fill order request
    /// </summary>
    public class GetHisMatchResponse
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
            public List<Trade> trades { get; set; }

            public class Trade
            {
                public string id { get; set; }

                [JsonProperty("match_id")]
                public long matchId { get; set; }

                [JsonProperty("order_id")]
                public long orderId { get; set; }

                [JsonProperty("order_id_str")]
                public string orderIdStr { get; set; }

                public string symbol { get; set; }

                [JsonProperty("order_source")]
                public string orderSource { get; set; }

                [JsonProperty("contract_type")]
                public string contractType { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

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

                [JsonProperty("trade_fee")]
                public double tradeFee { get; set; }

                public string role { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset { get; set; }

                [JsonProperty("real_profit")]
                public double realProfit { get; set; }
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
