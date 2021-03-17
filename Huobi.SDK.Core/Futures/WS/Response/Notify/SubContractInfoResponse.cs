using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS.Response.Notify
{
    public class SubContractInfoResponse
    {
        public string op { get; set; }

        public string topic { get; set; }
        
        public long ts { get; set; }
        
        [JsonProperty("event")]
        public string eventSender { get; set; }
        
        public List<Data> data { get; set; }

        public class Data
        {
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("contract_type")]
            public string contractType { get; set; }

            [JsonProperty("contract_size")]
            public double contractSize { get; set; }

            [JsonProperty("price_tick")]
            public double priceTick { get; set; }

            [JsonProperty("delivery_date")]
            public string deliveryDate { get; set; }

            [JsonProperty("create_date")]
            public string createDate { get; set; }

            [JsonProperty("settlement_time", NullValueHandling = NullValueHandling.Ignore)]
            public string settlementTime { get; set; }

            [JsonProperty("delivery_time", NullValueHandling = NullValueHandling.Ignore)]
            public string deliveryTime { get; set; }

            [JsonProperty("contract_status")]
            public int contractStatus { get; set; }
        }
    }
}