namespace Huobi.SDK.Core.Spot.WS.Response.Market
{
    /// <summary>
    /// SubETP Response
    /// </summary>
    public class SubETPResponse
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
            public float actualLeverage;

            public float nav;

            public float outstanding;

            public string symbol;

            public long navTime;

            public Basket[] basket;

            public class Basket
            {
                public float amount;

                public string currency;

            }

        }
    }
}
