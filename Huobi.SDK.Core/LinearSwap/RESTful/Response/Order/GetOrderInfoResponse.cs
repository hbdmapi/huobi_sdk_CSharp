using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Order
{
    /// <summary>
    /// The response for order info request
    /// </summary>
    public class GetOrderInfoResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public class Data
        {
            public long symbol { get; set; }

            [JsonProperty("contract_code")]
            public long contractCode { get; set; }

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

            [JsonProperty("client_order_id", NullValueHandling = NullValueHandling.Ignore)]
            public long clientOrderId { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            [JsonProperty("trade_volume")]
            public double tradeVolume { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }

            public double fee { get; set; }

            [JsonProperty("trade_avg_price")]
            public double tradeAvgPrice { get; set; }

            [JsonProperty("margin_asset")]
            public string marginAsset { get; set; }

            [JsonProperty("margin_frozen")]
            public double marginFrozen { get; set; }

            public double profit { get; set; }

            public int status { get; set; }

            [JsonProperty("order_type")]
            public int orderType { get; set; }

            [JsonProperty("order_source")]
            public string orderSource { get; set; }

            [JsonProperty("fee_asset")]
            public string feeAsset { get; set; }

            [JsonProperty("liquidation_type")]
            public string liquidationType { get; set; }

            [JsonProperty("canceled_at")]
            public long canceledAt { get; set; }
        }
    }
}
