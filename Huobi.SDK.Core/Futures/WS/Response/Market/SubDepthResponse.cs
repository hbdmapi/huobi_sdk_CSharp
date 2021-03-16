using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS.Response.Market
{
    /// <summary>
    /// response for sub depth and increamental depth two sub request
    /// </summary>
    public class SubDepthResponse
    {
        public string ch { get; set; }

        public long ts { get; set; }

        public Tick tick;

        public class Tick
        {
            public long mrid { get; set; }

            public long id { get; set; }

            public double[][] asks { get; set; }

            public double[][] bids { get; set; }

            public long ts { get; set; }

            public long version { get; set; }

            public string ch { get; set; }

            [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
            public string tickEvent { get; set; }
        }
    }
}
