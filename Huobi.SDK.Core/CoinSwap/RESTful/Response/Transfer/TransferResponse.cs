using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Transfer
{
    /// <summary>
    /// Transfer response
    /// </summary>
    public class TransferResponse
    {
        public long code { get; set; }

        public long? data { get; set; }

        public string message { get; set; }

        public bool success { get; set; }

        [JsonProperty("print-log")]
        public bool printLog { get; set; }
    }
}
