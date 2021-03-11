
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    /// <summary>
    /// response for kline request<br/>
    /// GET linear-swap-ex/market/history/kline<br/>
    /// </summary>
    public class GetKLineResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

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
            public long id { get; set; }

            public double vol { get; set; }

            public double count { get; set; }

            public double open { get; set; }

            public double close { get; set; }

            public double low { get; set; }

            public double high { get; set; }

            public double amount { get; set; }
        }
    }
}
