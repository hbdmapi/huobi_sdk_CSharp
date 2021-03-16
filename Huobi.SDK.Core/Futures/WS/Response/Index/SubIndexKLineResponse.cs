using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS.Response.Index
{
    /// <summary>
    /// response for premium_index kline and estimated_rate kline two sub
    /// </summary>
    public class SubIndexKLineResponse
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
        }
    }
}
