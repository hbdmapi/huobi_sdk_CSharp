using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Account
{
    public class GetTransferLimitResponse
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
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string symbol { get; set; }

            [JsonProperty("contract_code", NullValueHandling = NullValueHandling.Ignore)]
            public string contractCode { get; set; }

            [JsonProperty("transfer_in_max_each")]
            public double transferInMaxEach { get; set; }

            [JsonProperty("transfer_in_min_each")]
            public double transferInMinEach { get; set; }

            [JsonProperty("transfer_out_max_each")]
            public double transferOutMaxEach { get; set; }

            [JsonProperty("transfer_out_min_each")]
            public double transferOutMinEach { get; set; }

            [JsonProperty("transfer_in_max_daily")]
            public double transferInMaxDaily { get; set; }

            [JsonProperty("transfer_out_max_daily")]
            public double transferOutMaxDaily { get; set; }

            [JsonProperty("net_transfer_in_max_daily")]
            public double netTransferInMaxDaily { get; set; }

            [JsonProperty("net_transfer_out_max_daily")]
            public double netTransferOutMaxDaily { get; set; }
        }
    }
}
