using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase
{
    public class WSSubData
    {
        public string sub { get; set; }

        public string id { get; set; }

        [JsonProperty("data_type", NullValueHandling = NullValueHandling.Ignore)]
        public string dataType { get; set; }
    }
}

