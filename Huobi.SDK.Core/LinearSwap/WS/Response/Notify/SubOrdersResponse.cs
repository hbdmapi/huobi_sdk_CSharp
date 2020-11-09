using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Notify
{
    /// <summary>
    /// response for orders and match orders two sub
    /// </summary>
    public class SubOrdersResponse
    {
        public string op { get; set; }

        public string topic { get; set; }

        public long ts { get; set; }
        
        public string uid { get; set; }

        public string symbol { get; set; }

        [JsonProperty("contract_code")]
        public string contractCode { get; set; }

        public double volume { get; set; }

        public double price { get; set; }

        [JsonProperty("order_price_type")]
        public string orderPriceType { get; set; }

        public string direction { get; set; }

        public string offset { get; set; }

        public int status { get; set; }

        [JsonProperty("lever_rate")]
        public int leverRate { get; set; }

        [JsonProperty("order_id")]
        public long orderId { get; set; }

        [JsonProperty("order_id_str")]
        public string orderIdStr { get; set; }

        [JsonProperty("client_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public long clientOrderId { get; set; }

        [JsonProperty("order_source")]
        public string orderSource { get; set; }

        [JsonProperty("order_type")]
        public int orderType { get; set; }

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

        [JsonProperty("liquidation_type")]
        public double liquidationType { get; set; }

        [JsonProperty("canceled_at")]
        public long canceledAt { get; set; }

        [JsonProperty("fee_asset")]
        public string feeAsset { get; set; }

        public List<Trade> trade;

        public class Trade
        {
            public string id { get; set; }

            [JsonProperty("trade_id")]
            public long tradeId { get; set; }

            [JsonProperty("trade_volume")]
            public double tradeVolume { get; set; }

            [JsonProperty("trade_price")]
            public double tradePrice { get; set; }

            [JsonProperty("trade_fee")]
            public double tradeFee { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            public string role { get; set; }

            [JsonProperty("fee_asset")]
            public string feeAsset { get; set; }
        }
    }
}
