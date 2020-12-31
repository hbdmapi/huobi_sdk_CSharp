using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Order
{
    /// <summary>
    /// The response for open order request
    /// </summary>
    public class GetOpenOrderResponse
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

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                public double volume { get; set; }

                public double price { get; set; }

                [JsonProperty("order_price_type")]
                public string orderPriceType { get; set; }

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

                [JsonProperty("client_order_id", NullValueHandling = NullValueHandling.Ignore)]
                public long clientOrderId { get; set; }

                [JsonProperty("created_at")]
                public long createdAt { get; set; }

                [JsonProperty("trade_volume")]
                public double tradeVolume { get; set; }

                [JsonProperty("trade_turnover")]
                public double tradeTurnover { get; set; }

                public double fee { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset { get; set; }

                [JsonProperty("trade_avg_price", NullValueHandling = NullValueHandling.Ignore)]
                public double tradeAvgPrice { get; set; }

                [JsonProperty("margin_frozen")]
                public double marginFrozen { get; set; }

                [JsonProperty("margin_asset")]
                public string marginAsset { get; set; }

                public double profit { get; set; }

                public int status { get; set; }

                [JsonProperty("order_source")]
                public string orderSource { get; set; }

                [JsonProperty("liquidation_type")]
                public string liquidationType { get; set; }

                [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
                public long canceledAt { get; set; }

                [JsonProperty("margin_mode")]
                public string marginMode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }
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
