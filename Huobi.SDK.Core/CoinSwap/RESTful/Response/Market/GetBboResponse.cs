
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Market
{
    public class GetBboResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Tick> ticks { get; set; }

        public long ts { get; set; }

        public class Tick
        {
            [JsonProperty("contract_code")]
            public string contractCode { get; set; }
            
            public long mrid { get; set; }

            public float[] ask { get; set; }

            public float[] bid { get; set; }

            public long ts { get; set; }
        }
    }
}
