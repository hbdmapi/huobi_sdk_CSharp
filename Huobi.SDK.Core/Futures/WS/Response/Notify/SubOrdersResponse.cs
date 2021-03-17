using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS.Response.Notify
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

        [JsonProperty("contract_type")]
        public string contractType { get; set; }

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
        public long? clientOrderId { get; set; }

        [JsonProperty("order_source")]
        public string orderSource { get; set; }

        [JsonProperty("order_type")]
        public int orderType { get; set; }

        [JsonProperty("created_at")]
        public long createdAt { get; set; }

        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? canceledAt { get; set; }

        [JsonProperty("trade_volume")]
        public double tradeVolume { get; set; }

        [JsonProperty("trade_turnover", NullValueHandling = NullValueHandling.Ignore)]
        public double? tradeTurnover { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? fee { get; set; }

        [JsonProperty("fee_asset", NullValueHandling = NullValueHandling.Ignore)]
        public string feeAsset { get; set; }

        [JsonProperty("trade_avg_price")]
        public double tradeAvgPrice { get; set; }

        [JsonProperty("margin_frozen", NullValueHandling = NullValueHandling.Ignore)]
        public double? marginFrozen { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? profit { get; set; }

        [JsonProperty("liquidation_type", NullValueHandling = NullValueHandling.Ignore)]
        public double? liquidationType { get; set; }

        [JsonProperty("is_tpsl")]
        public int isTpsl { get; set; }

        [JsonProperty("real_profit", NullValueHandling = NullValueHandling.Ignore)]
        public double? realProfit { get; set; }

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

            [JsonProperty("trade_fee", NullValueHandling = NullValueHandling.Ignore)]
            public double tradeFee { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            public string role { get; set; }

            [JsonProperty("real_profit", NullValueHandling = NullValueHandling.Ignore)]
            public double? realProfit { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double? profit { get; set; }

            [JsonProperty("fee_asset", NullValueHandling = NullValueHandling.Ignore)]
            public string feeAsset { get; set; }
        }
    }
}
