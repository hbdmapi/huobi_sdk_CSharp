
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Market
{
    public class GetIndexResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("index_price")]
            public double indexPrice { get; set; }

            [JsonProperty("index_ts")]
            public long indexTs { get; set; }
        }
    }
}
