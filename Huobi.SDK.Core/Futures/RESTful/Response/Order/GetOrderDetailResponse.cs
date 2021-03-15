using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Order
{
    /// <summary>
    /// The response for order detail request
    /// </summary>
    public class GetOrderDetailResponse
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

            [JsonProperty("contract_type")]
            public string contractType { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("lever_rate")]
            public int leverRate { get; set; }

            public string direction { get; set; }

            public string offset { get; set; }

            public double volume { get; set; }

            public double price { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            [JsonProperty("canceled_at")]
            public long canceledAt { get; set; }

            [JsonProperty("order_source")]
            public string orderSource { get; set; }

            [JsonProperty("order_price_type")]
            public string orderPriceType { get; set; }

            [JsonProperty("margin_frozen")]
            public double marginFrozen { get; set; }

            public double profit { get; set; }

            [JsonProperty("instrument_price")]
            public double instrumentPrice { get; set; }

            [JsonProperty("final_interest")]
            public double finalInterest { get; set; }

            [JsonProperty("adjust_value")]
            public double adjustValue { get; set; }

            public double fee { get; set; }

            [JsonProperty("fee_asset")]
            public string feeAsset { get; set; }

            [JsonProperty("liquidation_type")]
            public string liquidationType { get; set; }

            [JsonProperty("order_id")]
            public long orderId { get; set; }

            [JsonProperty("order_id_str")]
            public string orderIdStr { get; set; }

            [JsonProperty("client_order_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? clientOrderId { get; set; }

            [JsonProperty("order_type")]
            public string orderType { get; set; }

            public int status { get; set; }

            [JsonProperty("trade_avg_price", NullValueHandling = NullValueHandling.Ignore)]
            public double? tradeAvgPrice { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }

            [JsonProperty("trade_volume")]
            public double tradeVolume { get; set; }

            [JsonProperty("total_page")]
            public int totalPage { get; set; }

            [JsonProperty("current_page")]
            public int currentPage { get; set; }

            [JsonProperty("total_size")]
            public int totalSize { get; set; }

            [JsonProperty("is_tpsl")]
            public int isTpsl { get; set; }

            [JsonProperty("real_profit")]
            public double realProfit { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Trade> trades { get; set; }

            public class Trade
            {
                public string id { get; set; }

                [JsonProperty("trade_id")]
                public long tradeId { get; set; }

                [JsonProperty("trade_price")]
                public double tradePrice { get; set; }

                [JsonProperty("trade_volume")]
                public double tradeVolume { get; set; }

                [JsonProperty("trade_turnover")]
                public double tradeTurnover { get; set; }

                [JsonProperty("trade_fee")]
                public double tradeFee { get; set; }

                public string role { get; set; }

                [JsonProperty("created_at")]
                public long createdAt { get; set; }

                public double profit { get; set; }

                [JsonProperty("real_profit")]
                public double realProfit { get; set; }
            }
        }
    }
}
