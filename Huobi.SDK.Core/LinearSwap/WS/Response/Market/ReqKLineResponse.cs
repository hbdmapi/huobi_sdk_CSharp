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

            public double vol { get; set; }

            public double count { get; set; }

            public double open { get; set; }

            public double close { get; set; }

            public double low { get; set; }

            public double high { get; set; }

            public double amount { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }
        }
    }
}
