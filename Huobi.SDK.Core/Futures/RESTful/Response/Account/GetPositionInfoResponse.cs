using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Account
{
    /// <summary>
    /// position response for account and sub account two request
    /// POST linear-swap-api/v1/swap_position_info
    /// POST linear-swap-api/v1/swap_sub_position_info
    /// </summary>
    public class GetPositionInfoResponse
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

            [JsonProperty("position_margin")]
            public double positionMargin { get; set; }

            [JsonProperty("lever_rate")]
            public int leverRate { get; set; }

            public string direction { get; set; }

            [JsonProperty("last_price")]
            public double lastPrice { get; set; }
        }
    }
}