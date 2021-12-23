namespace Huobi.SDK.Core.Spot.RESTful.Response.Account
{
    /// <summary>
    /// GetAccountInfo response
    /// </summary>
    public class GetAccountInfoResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        public Data[] data;

        /// <summary>
        /// Account info
        /// </summary>
        public class Data
        {
            /// <summary>
            /// Unique account id
            /// </summary>
            public int id;

            /// <summary>
            /// The type of this account
            /// Possible values: [spot, margin, otc, point, super-margin]
            /// </summary>
            public string type;

            /// <summary>
            /// The type of sub account (applicable only for isolated margin accout)
            /// </summary>
            public string subtype;

            /// <summary>
            /// Account state
            /// Possible values: [working, lock]
            /// </summary>
            public string state;
        }
    }
}
