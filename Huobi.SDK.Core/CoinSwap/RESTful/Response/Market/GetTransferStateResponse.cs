
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Market
{
    /// <summary>
    /// response for transfer state
    /// </summary>
    public class GetTransferStateResponse
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

            [JsonProperty("transfer_in")]
            public int transferIn { get; set; }

            [JsonProperty("transfer_out")]
            public int transferOut { get; set; }

            [JsonProperty("master_transfer_sub")]
            public int masterTransferSub { get; set; }

            [JsonProperty("sub_transfer_master")]
            public int subTransferMaster { get; set; }

            [JsonProperty("master_transfer_sub_inner_in")]
            public int masterTransferSubInnerIn { get; set; }

            [JsonProperty("master_transfer_sub_inner_out")]
            public int masterTransferSubInnerOut { get; set; }

            [JsonProperty("sub_transfer_master_inner_in")]
            public int subTransferMasterInnerIn { get; set; }

            [JsonProperty("sub_transfer_master_inner_out")]
            public int subTransferMasterInnerOut { get; set; }

            [JsonProperty("transfer_inner_in")]
            public int transferInnerIn { get; set; }

            [JsonProperty("transfer_inner_out")]
            public int transferInnerOut { get; set; }


        }
    }
}
