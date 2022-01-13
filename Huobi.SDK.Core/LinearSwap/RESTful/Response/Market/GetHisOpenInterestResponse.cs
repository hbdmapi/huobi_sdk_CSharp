
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetHisOpenInterestResponse
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
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            public List<Tick> tick { get; set; }
            public class Tick
            {
                public double volume { get; set; }

                [JsonProperty("amount_type")]
                public int amountType { get; set; }

                public double value { get; set; }

                public long ts { get; set; }
            }
            
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
