namespace Huobi.SDK.Core.Spot.WS.Response.AccountOrder
{
    /// <summary>
    /// SubAccount Response
    /// </summary>
    public class SubAccountResponse
    {
        /// <summary>
        /// action
        /// </summary>
        public string action;

        /// <summary>
        /// ch
        /// </summary>
        public string ch;


        /// <summary>
        /// Response body from sub
        /// </summary>
        public Data data;

        public class Data
        {
            /// <summary>
            /// The crypto currency of this balance
            /// </summary>
            public string currency;

            /// <summary>
            /// The account id of this individual balance
            /// </summary>
            public int accountId;

            /// <summary>
            /// The account balance (only exists when account balance changed)
            /// </summary>
            public string balance;

            /// <summary>
            /// The available balance (only exists when available balance changed)
            /// </summary>
            public string available;

            /// <summary>
            /// Change type
            /// Possible values: [order-place,order-match,order-refund,order-cancel,order-fee-refund,
            /// margin-transfer,margin-loan,margin-interest,margin-repay,deposit, withdraw, other]
            /// </summary>
            public string changeType;

            /// <summary>
            /// Account type
            /// Possible values: [trade, frozen, loan, interest]
            /// </summary>
            public string accountType;

            /// <summary>
            /// Change timestamp in millisecond
            /// If it is null, then this message is account overview not update
            /// </summary>
            public long? changeTime;

            public long seqNum;
        }
    }
}
