using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase
{
    public class WSAuthData
    {
        public string op { get { return "auth"; } }

        public string type { get { return "api"; } }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string cid { get; set; }

        [JsonProperty("AccessKeyId")]
        public string accessKeyId { get; set; }

        [JsonProperty("SignatureMethod")]
        public string signatureMethod { get { return "HmacSHA256"; } }

        [JsonProperty("SignatureVersion")]
        public string signatureVersion { get { return "2"; } }

        [JsonProperty("Timestamp")]
        public string timestamp { get; set; }

        [JsonProperty("Signature")]
        public string signature { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ticket { get; set; }
    }
}
