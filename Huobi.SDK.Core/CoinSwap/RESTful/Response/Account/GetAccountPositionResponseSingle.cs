
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Account
{
    /// <summary>
    /// get account_position_info
    /// </summary>
    public class GetAccountPositionResponseSingle
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string symbol { get; set; }

            [JsonProperty("contract_code", NullValueHandling = NullValueHandling.Ignore)]
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

            [JsonProperty("margin_available", NullValueHandling = NullValueHandling.Ignore)]
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

            [JsonProperty("lever_rate", NullValueHandling = NullValueHandling.Ignore)]
            public double leverRate { get; set; }

            [JsonProperty("adjust_factor", NullValueHandling = NullValueHandling.Ignore)]
            public double adjustFactor { get; set; }

            [JsonProperty("margin_mode")]
            public string marginMode { get; set; }

            [JsonProperty("margin_account")]
            public string marginAccount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Positions> positions { get; set; }
            
            public class Positions
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

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

                [JsonProperty("margin_asset")]
                public string marginAsset { get; set; }

                [JsonProperty("position_margin")]
                public double positionMargin { get; set; }

                [JsonProperty("lever_rate")]
                public int leverRate { get; set; }

                public string direction { get; set; }

                [JsonProperty("last_price")]
                public double lastPrice { get; set; }

                [JsonProperty("margin_mode")]
                public string marginMode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }
            }

            [JsonProperty("contract_detail", NullValueHandling = NullValueHandling.Ignore)]
            public List<ContractDetail> contractDetail { get; set; }

            public class ContractDetail
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("margin_position")]
                public double marginPosition { get; set; }

                [JsonProperty("margin_frozen")]
                public double marginFrozen { get; set; }

                [JsonProperty("margin_available")]
                public double marginAvailable { get; set; }

                [JsonProperty("profit_unreal")]
                public double profitUnreal { get; set; }

                [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
                public double liquidationPrice { get; set; }

                [JsonProperty("lever_rate")]
                public double leverRate { get; set; }

                [JsonProperty("adjust_factor")]
                public double adjustFactor { get; set; }
            }
        }
    }
}
