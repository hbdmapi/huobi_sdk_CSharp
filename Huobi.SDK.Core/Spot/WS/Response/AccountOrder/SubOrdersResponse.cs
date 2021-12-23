using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.WS.Response.AccountOrder
{
    /// <summary>
    /// SubOrders Response
    /// </summary>
    public class SubOrdersResponse
    {
        public string action;

        public string ch;

        public Data data;

        public class Data
        {
            /// <summary>
            /// Event type
            /// </summary>
            public string eventType;

            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Client order id
            /// </summary>
            public string clientOrderId;

            /// <summary>
            /// Order status
            /// Possible values for creation eventType: submitted
            /// </summary>
            public string orderStatus;

            #region for order trigger failed/order cancel
            /// <summary>
            /// Order side, buy or sell
            /// </summary>
            public string orderSide;

            /// <summary>
            /// Error code for triggering failure
            /// </summary>
            public int errCode;

            /// <summary>
            /// Error message for triggering failure
            /// </summary>
            public string errMessage;

            /// <summary>
            /// Last activity time, available for cancellation eventType
            /// </summary>
            public long lastActTime;
            #endregion

            #region for place order
            public long accountId;

            public long orderId;

            public string orderSource;

            public string orderPrice;

            public string orderSize;

            public string orderValue;

            public string type;

            public long orderCreateTime;

            #endregion

            #region for order traded
            public string tradePrice;

            public string tradeVolume;

            public long tradeId;

            public long tradeTime;

            public bool aggressor;

            public string remainAmt;

            public string execAmt;

            #endregion
        }
    }
}
