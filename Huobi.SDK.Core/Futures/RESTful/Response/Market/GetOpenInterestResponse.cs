
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    public class GetOpenInterestResponse
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

            [JsonProperty("contract_type")]
            public string contractType { get; set; }

            public double amount { get; set; }

            public double volume { get; set; }

            [JsonProperty("trade_amount")]
            public double tradeAmount { get; set; }

            [JsonProperty("trade_volume")]
            public double tradeVolume	 { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }
        }
    }
}
