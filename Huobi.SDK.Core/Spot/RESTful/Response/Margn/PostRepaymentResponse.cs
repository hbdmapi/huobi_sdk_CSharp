namespace Huobi.SDK.Core.Spot.RESTful.Response.Margin
{
    public class PostRepaymentResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        public string message;

        /// <summary>
        /// Response body
        /// </summary>
        public Data[] data;

        public class Data
        {
            public string repayId;

            public long repayTime;
        }
    }
}
