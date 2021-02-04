using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Market
{
    /// <summary>
    /// response for kline and detail sub
    /// </summary>
    public class SubKLineResponse
    {
        public string ch { get; set; }

        public long ts { get; set; }

        public Tick tick;

        public class Tick
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
            public string tradeTurnover { get; set; }
        }
    }
}