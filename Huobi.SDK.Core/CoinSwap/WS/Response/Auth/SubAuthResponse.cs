using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.WS.Response.Auth
{
    public class SubAuthResponse
    {
        public string op { get; set; }

        public string type { get; set; }

        public string cid { get; set; }

        [JsonProperty("err-code")]
        public int errorCode { get; set; }

        [JsonProperty("err-msg")]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty("user-id")]
        public long userId { get; set; }
    }
}
