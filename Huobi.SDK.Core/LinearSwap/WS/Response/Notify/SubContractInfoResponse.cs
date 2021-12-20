﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Notify
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

            [JsonProperty("contract_size")]
            public double contractSize { get; set; }

            [JsonProperty("price_tick")]
            public double priceTick { get; set; }

            [JsonProperty("settlement_date")]
            public string settlementDate { get; set; }

            [JsonProperty("delivery_time", NullValueHandling = NullValueHandling.Ignore)]
            public string deliveryTime { get; set; }

            [JsonProperty("create_date")]
            public string createDate { get; set; }

            [JsonProperty("contract_status")]
            public int contractStatus { get; set; }

            [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
            public string contractType { get; set; }

            [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
            public string pair { get; set; }

            [JsonProperty("business_type", NullValueHandling = NullValueHandling.Ignore)]
            public string businessType { get; set; }

            [JsonProperty("delivery_date", NullValueHandling = NullValueHandling.Ignore)]
            public string deliveryDate { get; set; }
        }
    }
}