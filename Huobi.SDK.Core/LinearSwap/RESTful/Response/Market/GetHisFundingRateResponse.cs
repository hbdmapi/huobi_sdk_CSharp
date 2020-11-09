
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    /// <summary>
    /// response for his funding rate request
    /// </summary>
    public class GetHisFundingRateResponse
    {
        public string status { get; set; }

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            public List<InnerDate> data { get; set; }

            public class InnerDate
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset { get; set; }

                public List<InnerDate> data { get; set; }
                [JsonProperty("funding_time")]
                public string fundingTime { get; set; }

                [JsonProperty("funding_rate")]
                public string fundingRate { get; set; }

                [JsonProperty("realized_rate")]
                public string realizedRate { get; set; }

                [JsonProperty("avg_premium_index")]
                public string avgPremiumIndex { get; set; }
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
