using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Notify
{
    public class SubFundingRateResponse
    {
        public string op { get; set; }

        public string topic { get; set; }
        
        public long ts { get; set; }
        
        public List<Data> data { get; set; }

        public class Data
        {
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("fee_asset")]
            public string feeAsset { get; set; }

            [JsonProperty("funding_time")]
            public string fundingTime { get; set; }

            [JsonProperty("funding_rate")]
            public string fundingRate { get; set; }

            [JsonProperty("estimated_rate")]
            public string estimatedRate { get; set; }

            [JsonProperty("settlement_time")]
            public string settlementTime { get; set; }
        }
    }
}