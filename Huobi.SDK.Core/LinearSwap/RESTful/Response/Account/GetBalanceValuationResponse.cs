
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    /// <summary>
    /// get balance valuation
    /// </summary>
    public class GetBalanceValuationResponse
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
            [JsonProperty("valuation_asset")]
            public string valuationAsset { get; set; }

            [JsonProperty("balance")]
            public string balance { get; set; }
        }
    }
}
