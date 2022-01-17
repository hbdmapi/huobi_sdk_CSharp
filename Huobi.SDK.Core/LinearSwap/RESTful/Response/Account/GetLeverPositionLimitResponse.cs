
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    /// <summary>
    /// get account_position_info
    /// </summary>
    public class GetLeverPositionLimitResponse
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

            [JsonProperty("contract_code", NullValueHandling = NullValueHandling.Ignore)]
            public string contractCode { get; set; }

            [JsonProperty("margin_mode")]
            public string marginMode { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<LeverRate> list { get; set; }
            
            public class LeverRate
            {

                [JsonProperty("lever_rate")]
                public int leverRate { get; set; }

                [JsonProperty("buy_limit_value")]
                public double buyLimitValue { get; set; }

                [JsonProperty("sell_limit_value")]
                public double sellLimitValue { get; set; }
            }

            [JsonProperty("trade_partition")]
            public string tradePartition { get; set; }
        }
    }
}
