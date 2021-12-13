
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    public class GetLiquidationOrdersResponse
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
            public List<Order> orders { get; set; }

            public class Order
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("created_at")]
                public long createdAt { get; set; }

                public string direction { get; set; }
                
                public string offset { get; set; }
                
                public double price { get; set; }
                
                public double volume { get; set; }

                public double amount { get; set; }

                [JsonProperty("pair")]
                public string pair { get; set; }

                [JsonProperty("business_type")]
                public string businessType { get; set; }
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

