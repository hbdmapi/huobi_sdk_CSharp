using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS.Response.Index
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
            public string contractPrice { get; set; }

            [JsonProperty("index_price")]
            public string indexPrice { get; set; }

            public string basis { get; set; }

            [JsonProperty("basis_rate")]
            public string basisRate { get; set; }
        }
    }
}
