﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS.Response.Notify
{
    public class SubLiquidationOrdersResponse
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

            public string direction { get; set; }

            public string offset { get; set; }

            public double volume { get; set; }

            public double amount { get; set; }

            [JsonProperty("trade_turnover")]
            public string tradeTurnover { get; set; }

            public double price { get; set; }

            [JsonProperty("created_at")]
            public long createdAt { get; set; }

            [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
            public string contractType { get; set; }

            [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
            public string pair { get; set; }

            [JsonProperty("business_type", NullValueHandling = NullValueHandling.Ignore)]
            public string businessType { get; set; }
        }
    }
}