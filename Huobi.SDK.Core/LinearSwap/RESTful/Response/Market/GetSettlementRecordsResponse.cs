
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    /// <summary>
    /// response for settlement records
    /// </summary>
    public class GetSettlementRecordsResponse
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
            [JsonProperty("settlement_record")]
            public List<SettlementRecord> data { get; set; }

            public class SettlementRecord
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("settlement_time")]
                public long settlementTime { get; set; }

                [JsonProperty("clawback_ratio")]
                public double clawbackRatio { get; set; }

                [JsonProperty("settlement_price")]
                public double settlementPrice { get; set; }

                [JsonProperty("settlement_type")]
                public string settlementType { get; set; }
                
                [JsonProperty("pair")]
                public string pair { get; set; }

                [JsonProperty("business_type")]
                public string businessType { get; set; }
            }

            [JsonProperty("total_page")]
            public int totalPage { get; set; }

            [JsonProperty("current_page")]
            public int currentPage { get; set; }

            [JsonProperty("total_size")]
            public int totalSize { get; set; }
        }
    }
}
