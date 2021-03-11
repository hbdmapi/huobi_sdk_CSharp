
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
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
        }
    }
}
