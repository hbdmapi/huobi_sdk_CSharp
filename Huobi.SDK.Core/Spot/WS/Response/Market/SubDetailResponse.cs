namespace Huobi.SDK.Core.Spot.WS.Response.Market
{
    /// <summary>
    /// SubDetail Response
    /// </summary>
    public class SubDetailResponse
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
            /// UNIX epoch timestamp in second as response id
            /// </summary>
            public long id;

            /// <summary>
            /// Low price during the interval
            /// </summary>
            public float low;

            /// <summary>
            /// High price during the interval
            /// </summary>
            public float high;

            /// <summary>
            /// Opening price during the interval
            /// </summary>
            public float open;

            /// <summary>
            /// Closing price during the interval
            /// </summary>
            public float close;

            /// <summary>
            /// Aggregated trading value during the interval (in quote currency)
            /// </summary>
            public float vol;

            /// <summary>
            /// Aggregated trading volume during the interval (in base currency)
            /// </summary>
            public float amount;

            /// <summary>
            /// version
            /// </summary>
            public long version;

            /// <summary>
            /// Number of trades during the interval
            /// </summary>
            public int count;
        }
    }
}
