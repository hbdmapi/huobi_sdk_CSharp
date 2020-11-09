
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetHisTradeResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

        public string status { get; set; }

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<HisTrade> data { get; set; }

        public long ts { get; set; }

        public class HisTrade
        {
            public long id { get; set; }

            public List<Data> data { get; set; }
            public class Data
            {
                public double amount { get; set; }

                public string direction { get; set; }

                public long id { get; set; }

                public double price { get; set; }

                public long ts { get; set; }
            }

            public long ts { get; set; }
        }
    }
}
