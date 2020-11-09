using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase
{
    public class WSOpData
    {
        public string op { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string cid { get; set; }

        public string topic { get; set; }
    }
}

