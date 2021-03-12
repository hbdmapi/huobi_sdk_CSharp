
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Account
{
    /// <summary>
    /// get account_position_info
    /// </summary>
    public class GetAccountPositionResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string symbol { get; set; }

            [JsonProperty("margin_balance")]
            public double marginBalance { get; set; }

            [JsonProperty("margin_position")]
            public double marginPosition { get; set; }

            [JsonProperty("margin_frozen")]
            public double marginFrozen { get; set; }

            [JsonProperty("margin_available", NullValueHandling = NullValueHandling.Ignore)]
            public double marginAvailable { get; set; }

            [JsonProperty("profit_real")]
            public double profitReal { get; set; }

            [JsonProperty("profit_unreal")]
            public double profitUnreal { get; set; }

            [JsonProperty("risk_rate", NullValueHandling = NullValueHandling.Ignore)]
            public double riskRate { get; set; }

            [JsonProperty("withdraw_available")]
            public double withdrawAvailable;

            [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
            public double liquidationPrice { get; set; }

            [JsonProperty("lever_rate", NullValueHandling = NullValueHandling.Ignore)]
            public double leverRate { get; set; }

            [JsonProperty("adjust_factor", NullValueHandling = NullValueHandling.Ignore)]
            public double adjustFactor { get; set; }

            [JsonProperty("margin_static")]
            public double marginStatic { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Positions> positions { get; set; }
            
            public class Positions
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("contract_type")]
                public string contractType { get; set; }

                public double volume { get; set; }

                public double available { get; set; }

                public double frozen { get; set; }

                [JsonProperty("cost_open")]
                public double costOpen { get; set; }

                [JsonProperty("cost_hold")]
                public double costHold { get; set; }

                [JsonProperty("profit_unreal")]
                public double profitUnreal { get; set; }

                [JsonProperty("profit_rate")]
                public double profitRate { get; set; }

                public double profit { get; set; }

                [JsonProperty("lever_rate")]
                public int leverRate { get; set; }

                public string direction { get; set; }

                [JsonProperty("last_price")]
                public double lastPrice { get; set; }
            }
        }
    }
}
