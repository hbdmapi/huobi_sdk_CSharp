
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Notify
{
    public class SubAccountsResponse
    {
        public string op { get; set; }

        public string topic { get; set; }

        public long ts { get; set; }

        public string uid { get; set; }

        [JsonProperty("event")]
        public string eventSender { get; set; }

        public List<Data> data { get; set; }

        public class Data
        {
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("margin_asset")]
            public string marginAsset { get; set; }

            [JsonProperty("margin_balance")]
            public double marginBalance { get; set; }

            [JsonProperty("margin_static")]
            public double marginStatic { get; set; }

            [JsonProperty("margin_position")]
            public double marginPosition { get; set; }

            [JsonProperty("margin_frozen")]
            public double marginFrozen { get; set; }

            [JsonProperty("margin_available")]
            public double marginAvailable { get; set; }

            [JsonProperty("profit_real")]
            public double profitReal { get; set; }

            [JsonProperty("profit_unreal")]
            public double profitUnreal { get; set; }

            [JsonProperty("withdraw_available")]
            public double withdrawAvailable;

            [JsonProperty("risk_rate", NullValueHandling = NullValueHandling.Ignore)]
            public double riskRate { get; set; }

            [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
            public double liquidationPrice { get; set; }

            [JsonProperty("lever_rate")]
            public double leverRate { get; set; }

            [JsonProperty("adjust_factor")]
            public double adjustFactor { get; set; }

            [JsonProperty("margin_account")]
            public string marginAccount { get; set; }

            [JsonProperty("margin_mode")]
            public string marginMode { get; set; }
        }
    }
}
