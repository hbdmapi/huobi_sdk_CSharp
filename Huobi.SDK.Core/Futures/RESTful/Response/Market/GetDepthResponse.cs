
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    public class GetDepthResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Tick tick { get; set; }

        public long ts { get; set; }

        public class Tick
        {
            public double[][] asks { get; set; }
            
            public double[][] bids { get; set; }

            public string ch { get; set; }

            public long id { get; set; }

            public long mrid { get; set; }

            public long ts { get; set; }

            public long version { get; set; }
        }
    }
}
