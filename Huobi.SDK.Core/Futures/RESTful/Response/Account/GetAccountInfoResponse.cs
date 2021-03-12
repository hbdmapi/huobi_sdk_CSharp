
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Account
{

    /// <summary>
    /// response for account and sub account two class info
    /// POST linear-swap-api/v1/swap_account_info
    /// POST linear-swap-api/v1/swap_sub_account_info
    /// </summary>
    public class GetAccountInfoResponse
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
            public string symbol { get; set; }

            [JsonProperty("margin_balance")]
            public double marginBalance { get; set; }

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

            [JsonProperty("risk_rate", NullValueHandling = NullValueHandling.Ignore)]
            public double riskRate { get; set; }

            [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
            public double liquidationPrice { get; set; }

            [JsonProperty("withdraw_available")]
            public double withdrawAvailable;

            [JsonProperty("lever_rate")]
            public double leverRate { get; set; }

            [JsonProperty("adjust_factor")]
            public double adjustFactor { get; set; }

            [JsonProperty("margin_static")]
            public string marginStatic { get; set; }
        }
    }
}
