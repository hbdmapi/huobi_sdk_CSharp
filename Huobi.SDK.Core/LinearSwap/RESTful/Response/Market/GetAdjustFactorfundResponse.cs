
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetAdjustFactorFundResponse
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

            public List<AdjustFactor> list { get; set; }
            public class AdjustFactor
            {
                [JsonProperty("lever_rate")]
                public double leverRate { get; set; }

                public List<Ladder> ladders { get; set; }

                public class Ladder
                {
                    [JsonProperty("min_size")]
                    public double minSize { get; set; }

                    [JsonProperty("max_size", NullValueHandling = NullValueHandling.Ignore)]
                    public double maxSize { get; set; }

                    public int ladder { get; set; }

                    [JsonProperty("adjust_factor")]
                    public double adjustFactor { get; set; }
                }
            }
            [JsonProperty("contract_type")]
            public string contractType { get; set; }

            [JsonProperty("pair")]
            public string pair { get; set; }

            [JsonProperty("business_type")]
            public string businessType { get; set; }

            [JsonProperty("trade_partition")]
            public string tradePartition { get; set; }
        }
    }
}
