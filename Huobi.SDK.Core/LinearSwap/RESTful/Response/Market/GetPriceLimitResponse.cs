
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetPriceLimitResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("high_limit")]
            public double highLimit { get; set; }

            [JsonProperty("low_limit")]
            public double lowLimit { get; set; }

            [JsonProperty("contract_type")]
            public string contractType { get; set; }

            [JsonProperty("pair")]
            public string pair { get; set; }

            [JsonProperty("business_type")]
            public string businessType { get; set; }

            [JsonProperty("trade_partition")]
            public string tradePartition { get; set; }
        }
    }
}
