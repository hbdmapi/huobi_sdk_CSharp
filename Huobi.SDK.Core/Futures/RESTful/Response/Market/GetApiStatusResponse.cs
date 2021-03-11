
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    /// <summary>
    /// response for api status request
    /// </summary>
    public class GetApiStatusResponse
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
            public string symbol { get; set; }
            
            public int open {get;set;}

            public int close{get;set;}

            public int cancel{get;set;}

            [JsonProperty("transfer_in")]
            public int transferIn { get; set; }

            [JsonProperty("transfer_out")]
            public int transferOut { get; set; }

            [JsonProperty("master_transfer_sub")]
            public int masterTransferSub { get; set; }

            [JsonProperty("sub_transfer_master")]
            public int subTransferMaster { get; set; }


        }
    }
}
