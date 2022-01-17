using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    public class GetFinancialRecordExactResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public class Data
        {
            [JsonProperty("financial_record")]
            public List<FinancialRecord> financialRecord { get; set; }

            public class FinancialRecord
            {
                public long id { get; set; }
                
                public long ts { get; set; }
                
                public string asset { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }

                [JsonProperty("face_margin_account", NullValueHandling = NullValueHandling.Ignore)]
                public string faceMarginAccount { get; set; }

                public int type { get; set; }

                public double amount { get; set; }

                [JsonProperty("trade_partition")]
                public string tradePartition { get; set; }
            }

            [JsonProperty("remain_size")]
            public int remainSize { get; set; }

            [JsonProperty("next_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? nextId { get; set; }
        }
    }
}
