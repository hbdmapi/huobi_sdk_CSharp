
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    public class GetBatchMergedResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

        public string status { get; set; }

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Tick> ticks { get; set; }

        public long ts { get; set; }

        public class Tick
        {
            public long id { get; set; }

            public string amount { get; set; }

            public double[] ask { get; set; }

            public double[] bid { get; set; }

            public string open { get; set; }

            public string close { get; set; }

            public double count { get; set; }

            public string high { get; set; }

            public string low { get; set; }

            public string vol { get; set; }

            public long ts { get; set; }
        }
    }
}
