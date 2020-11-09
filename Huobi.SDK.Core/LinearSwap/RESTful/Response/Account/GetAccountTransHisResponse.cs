using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    /// <summary>
    /// financial record response for account and sub account two request
    /// POST linear-swap-api/v1/swap_financial_record
    /// post linear-swap-api/v1/swap_master_sub_transfer_record
    /// </summary>
    public class GetAccountTransHisResponse
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
            public class FinancialRecord
            {
                public long id { get; set; }
                public long ts { get; set; }
                public string asset { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }

                public double amount { get; set; }

                #region only for account
                [JsonProperty("face_margin_account", NullValueHandling = NullValueHandling.Ignore)]
                public string faceMarginAccount { get; set; }

                [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
                public int type { get; set; }
                #endregion

                #region only for sub account
                [JsonProperty("from_margin_account", NullValueHandling = NullValueHandling.Ignore)]
                public string fromMarginAccount { get; set; }

                [JsonProperty("to_margin_account", NullValueHandling = NullValueHandling.Ignore)]
                public string toMarginAccount { get; set; }

                [JsonProperty("sub_uid", NullValueHandling = NullValueHandling.Ignore)]
                public string subUid { get; set; }

                [JsonProperty("sub_account_name", NullValueHandling = NullValueHandling.Ignore)]
                public string subAccountName { get; set; }

                [JsonProperty("transfer_type", NullValueHandling = NullValueHandling.Ignore)]
                public int transferType { get; set; }
                #endregion
            }

            [JsonProperty("financial_record")]
            public List<FinancialRecord> financialRecord { get; set; }

            [JsonProperty("total_page")]
            public long totalPage { get; set; }

            [JsonProperty("current_page")]
            public long currentPage { get; set; }

            [JsonProperty("total_size")]
            public long totalSize { get; set; }
        }
    }
}
