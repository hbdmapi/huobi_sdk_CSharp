
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetMergedResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

        public string status { get; set; }

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Tick tick { get; set; }

        public long ts { get; set; }

        public class Tick
        {
            public long id { get; set; }

            public string amount { get; set; }

            public double[][] asks { get; set; }

            public double[][] bids { get; set; }

            public string open { get; set; }

            public string close { get; set; }

            public double count { get; set; }

            public string high { get; set; }

            public string low { get; set; }

            public string vol { get; set; }

            [JsonProperty("trade_turnover")]
            public string tradeTurnover { get; set; }

            public long ts { get; set; }
        }
    }
}
