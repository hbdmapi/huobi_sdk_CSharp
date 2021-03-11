
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    public class GetEstimatedSettlementPriceResponse
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

            public List<Settlement> list { get; set; }

            public class Settlement
            {
                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("contract_type")]
                public string contractType { get; set; }

                [JsonProperty("estimated_settlement_price")]
                public string estimatedSettlementPrice { get; set; }

                [JsonProperty("settlement_type")]
                public string settlementType { get; set; }
            }
        }
    }
}
