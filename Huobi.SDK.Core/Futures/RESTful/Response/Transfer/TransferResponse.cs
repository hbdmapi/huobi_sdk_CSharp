using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Transfer
{
    /// <summary>
    /// Transfer response
    /// </summary>
    public class TransferResponse
    {
        public string status { get; set; }

        public long? data { get; set; }

        [JsonProperty("err-code")]
        public string errCode { get; set; }

        [JsonProperty("err-msg")]
        public string errMsg { get; set; }
    }
}
