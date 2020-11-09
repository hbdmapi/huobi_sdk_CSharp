using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Index
{
    public class SubBasiesResponse
    {
        public string ch { get; set; }

        public long ts { get; set; }

        public Tick tick;

        public class Tick
        {
            public long id { get; set; }

            [JsonProperty("contract_price")]
            public double contractPrice { get; set; }

            [JsonProperty("index_price")]
            public double indexPrice { get; set; }

            public double basis { get; set; }

            [JsonProperty("basis_rate")]
            public double basisRate { get; set; }
        }
    }
}
