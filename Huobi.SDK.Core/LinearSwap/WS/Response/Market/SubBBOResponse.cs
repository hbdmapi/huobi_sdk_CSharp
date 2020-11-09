using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Market
{
    public class SubBBOResponse
    {
        public string ch { get; set; }

        public long ts { get; set; }

        public Tick tick;

        public class Tick
        {
            public string ch { get; set; }

            public long mrid { get; set; }

            public long id { get; set; }

            public double[] ask { get; set; }

            public double[] bid { get; set; }

            public long version { get; set; }

            public long ts { get; set; }
        }
    }
}
