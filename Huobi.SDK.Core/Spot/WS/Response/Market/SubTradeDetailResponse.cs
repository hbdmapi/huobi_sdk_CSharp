namespace Huobi.SDK.Core.Spot.WS.Response.Market
{
    /// <summary>
    /// SubTradeDetail Response
    /// </summary>
    public class SubTradeDetailResponse
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
            public long id;

            public string ts;

            public Trade[] data;
        }

        public class Trade
        {
            public long id;

            public string ts;

            /// <summary>
            /// Unique trade id (NEW)
            /// </summary>
            public long tradeid;

            /// <summary>
            /// Last trade volume
            /// </summary>
            public float amount;

            /// <summary>
            /// Last trade price
            /// </summary>
            public float price;

            /// <summary>
            /// Aggressive order side (taker's order side) of the trade
            /// Possible values: [buy, sell]
            /// </summary>
            public string direction;
        }
    }
}
