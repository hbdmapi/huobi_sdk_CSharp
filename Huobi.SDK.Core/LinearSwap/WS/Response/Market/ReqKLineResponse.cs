using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Market
{
    public class ReqKLineResponse
    {
        public string rep { get; set; }

        public string status { get; set; }

        public string id { get; set; }

        public long wsid { get; set; }

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

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }
        }
    }
}
