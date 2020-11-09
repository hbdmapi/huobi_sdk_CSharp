using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase
{
    public class WSReqData
    {
        public string req { get; set; }

        public string id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long? from { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long? to { get; set; }
    }
}

