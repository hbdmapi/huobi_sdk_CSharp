using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.WS.Response.Market
{
    /// <summary>
    /// SubscribeDepth response
    /// </summary>
    public class SubMBPResponse
    {
        /// <summary>
        /// Data stream
        /// </summary>
        public string ch;

        /// <summary>
        /// Respond timestamp in millisecond
        /// </summary>
        public long ts;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public Tick tick;

        public class Tick
        {
            /// <summary>
            /// seqNum
            /// </summary>
            public long seqNum;

            /// <summary>
            /// prevSeqNum
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public long prevSeqNum;

            /// <summary>
            /// The current all bids in format [price, quote volume]
            /// </summary>
            public float[][] bids;

            /// <summary>
            /// The current all asks in format [price, quote volume]
            /// </summary>
            public float[][] asks;
        }
    }
}
