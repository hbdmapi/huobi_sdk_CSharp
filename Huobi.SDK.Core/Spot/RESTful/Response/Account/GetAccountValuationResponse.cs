using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Response.Account
{
    /// <summary>
    /// GetAccountBalance response
    /// </summary>
    public class GetAccountValuationResponse
    {
        public int code;

        public bool success;

        public Data data;

        public class Data
        {
            public Updated updated;

            public class Updated
            {
                public bool success;

                public long time;

            }

            public string todayProfitRate;

            public string totalBalance;

            public string todayProfit;

            public PAB[] profitAccountBalanceList;

            public class PAB
            {
                public string distributionType;

                public float balance;

                public bool success;

                public string accountBalance;
            }
        }
    }
}
