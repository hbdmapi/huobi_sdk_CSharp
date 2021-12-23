namespace Huobi.SDK.Core.Spot.WS.Response.Market
{
    /// <summary>
    /// SubTickerResponse response
    /// </summary>
    public class SubTickerResponse
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
        /// tick
        /// </summary>
        public Tick tick;

        /// <summary>
        /// Candlestick
        /// </summary>
        public class Tick
        {
            /// <summary>
            /// Opening price during the interval
            /// </summary>
            public float open;

            /// <summary>
            /// High price during the interval
            /// </summary>
            public float high;

            /// <summary>
            /// Low price during the interval
            /// </summary>
            public float low;

            /// <summary>
            /// Closing price during the interval
            /// </summary>
            public float close;

            /// <summary>
            /// Aggregated trading volume during the interval (in base currency)
            /// </summary>
            public float amount;

            /// <summary>
            /// Aggregated trading value during the interval (in quote currency)
            /// </summary>
            public float vol;

            /// <summary>
            /// Number of trades during the interval
            /// </summary>
            public int count;

            /// <summary>
            /// bid
            /// </summary>
            public float bid;

            /// <summary>
            /// bidSize
            /// </summary>
            public float bidSize;

            /// <summary>
            /// ask
            /// </summary>
            public float ask;

            /// <summary>
            /// askSize
            /// </summary>
            public float askSize;

            /// <summary>
            /// lastPrice
            /// </summary>
            public float lastPrice;

            /// <summary>
            /// lastSize
            /// </summary>
            public float lastSize;
        }
    }
}
