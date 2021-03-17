
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.WS.Response.System
{
    public class SubHeartBeatResponse
    {
        public string op { get; set; }

        public string topic { get; set; }

        public long ts { get; set; }

        [JsonProperty("event")]
        public string eventSender { get; set; }

        public Data data { get; set; }

        public class Data
        {

            [JsonProperty("heartbeat")]
            public int heartBeat { get; set; }

            [JsonProperty("estimated_recovery_time")]
            public long? estimatedRecoveryTime { get; set; }
        }
    }
}
