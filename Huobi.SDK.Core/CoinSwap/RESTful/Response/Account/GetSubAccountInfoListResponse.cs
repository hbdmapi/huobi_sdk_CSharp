
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.Account
{
    public class GetSubAccountInfoListResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            [JsonProperty("sub_list")]
            public List<SubList> subList { get; set; }

            public class SubList
            {
                [JsonProperty("sub_uid")]
                public string subUid { get; set; }

                [JsonProperty("account_info_list")]
                public List<AccountInfoList> accountInfoList { get; set; }
                public class AccountInfoList
                {
                    public string symbol { get; set; }

                    [JsonProperty("contract_code")]
                    public string contractCode { get; set; }

                    [JsonProperty("margin_balance")]
                    public double marginBalance { get; set; }

                    [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
                    public double liquidationPrice { get; set; }

                    [JsonProperty("risk_rate", NullValueHandling = NullValueHandling.Ignore)]
                    public double riskRate { get; set; }
                }
            }

            [JsonProperty("total_page")]
            public long totalPage { get; set; }

            [JsonProperty("current_page")]
            public long currentPage { get; set; }

            [JsonProperty("total_size")]
            public long totalSize { get; set; }
        }
    }
}
