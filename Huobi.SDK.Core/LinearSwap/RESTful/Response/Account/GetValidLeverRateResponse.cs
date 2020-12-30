using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    public class GetValidLeverRateResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public class Data
        {
            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("available_level_rate")]
            public string availableLeverRate { get; set; }

            [JsonProperty("margin_mode")]
            public string marginMode { get; set; }
        }
    }
}
