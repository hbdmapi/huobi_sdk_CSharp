
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    /// <summary>
    /// response for trade state request
    /// </summary>
    public class GetTradeStatusResponse
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
            [JsonProperty("margin_mode")]
            public string margin_mode { get; set; }

            [JsonProperty("margin_account")]
            public string margin_account { get; set; }

            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }
            
            public int open {get;set;}

            public int close{get;set;}

            public int cancel{get;set;}

            [JsonProperty("contract_type")]
            public string contractType { get; set; }

            [JsonProperty("pair")]
            public string pair { get; set; }

            [JsonProperty("business_type")]
            public string businessType { get; set; }
        }
    }
}
