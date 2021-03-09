using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.WS.Response.Index
{
    public class ReqBasisResponse
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

            [JsonProperty("contract_price")]
            public string contract_price { get; set; }

            [JsonProperty("index_price")]
            public string index_price { get; set; }

            public string basis { get; set; }

            [JsonProperty("basis_rate")]
            public string basis_rate { get; set; }
        }
    }
}
