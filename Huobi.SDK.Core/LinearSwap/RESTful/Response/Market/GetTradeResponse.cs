
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetTradeResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Tick tick { get; set; }

        public long ts { get; set; }

        public class Tick
        {
            public long id { get; set; }

            public List<Data> data { get; set; }
            public class Data
            {
                public string amount { get; set; }

                public string direction { get; set; }

                public long id { get; set; }

                public string price { get; set; }

                public long ts { get; set; }

                public string quantity { get; set; }

                [JsonProperty("trade_turnover")]
                public string tradeTurnover { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("business_type")]
                public string businessType { get; set; }
            }

            public long ts { get; set; }
        }
    }
}
