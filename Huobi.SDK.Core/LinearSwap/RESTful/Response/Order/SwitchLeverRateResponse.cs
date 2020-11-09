using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Order
{
    /// <summary>
    /// response for switch level rate
    /// </summary>
    public class SwitchLeverRateResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public int? errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public class Data
        {
            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("lever_rate")]
            public int leverRate { get; set; }
        }
    }
}
