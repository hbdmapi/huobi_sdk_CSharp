using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    /// <summary>
    /// transfer response for Inner and MasterSub two request
    /// post linear-swap-api/v1/swap_master_sub_transfer
    /// post linear-swap-api/v1/swap_transfer_inner
    /// </summary>
    public class AccountTransferResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public class Data
        {
            [JsonProperty("order_id")]
            public string orderId { get; set; }
        }
    }
}
