using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Index
{
    /// <summary>
    /// response for premium_index kline and estimated_rate kline two request
    /// </summary>
    public class ReqIndexKLineResponse
    {
        public string rep { get; set; }

        public string status { get; set; }

        public string id { get; set; }

        public long wsid { get; set; }

        public long ts { get; set; }

        public List<Data> data;

        public class Data
        {
            public long id { get; set; }

            public string vol { get; set; }

            public string count { get; set; }

            public string open { get; set; }

            public string close { get; set; }

            public string low { get; set; }

            public string high { get; set; }

            public string amount { get; set; }

            [JsonProperty("trade_turnover", NullValueHandling = NullValueHandling.Ignore)]
            public string tradeTurnover { get; set; }
        }
    }
}
