
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetLadderMarginResponse
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

            [JsonProperty("margin_mode")]
            public string marginMode { get; set; }

            [JsonProperty("margin_account")]
            public string marginAccount { get; set; }

            public List<LeverRate> list { get; set; }
            public class LeverRate
            {
                [JsonProperty("lever_rate")]
                public int leverRate { get; set; }

                public List<Ladders> ladders { get; set; }
                public class Ladders
                {
                    [JsonProperty("min_margin_balance", NullValueHandling = NullValueHandling.Ignore)]
                    public double? minMarginBalance { get; set; }

                    [JsonProperty("max_margin_balance", NullValueHandling = NullValueHandling.Ignore)]
                    public double? maxMarginBalance { get; set; }

                    [JsonProperty("min_margin_available", NullValueHandling = NullValueHandling.Ignore)]
                    public double? minMarginAvailable { get; set; }

                    [JsonProperty("max_margin_available", NullValueHandling = NullValueHandling.Ignore)]
                    public double? maxMarginAvailable { get; set; }

                }
            }
        }
    }
}
