using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.TriggerOrder
{
    /// <summary>
    /// The response for open order request
    /// </summary>
    public class GetOpenOrderResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public class Data
        {
            public List<Order> orders { get; set; }

            public class Order
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("trigger_type")]
                public string triggerType { get; set; }

                public double volume { get; set; }

                [JsonProperty("order_type")]
                public int orderType { get; set; }

                public string direction { get; set; }

                public string offset { get; set; }

                [JsonProperty("lever_rate")]
                public int leverRate { get; set; }

                [JsonProperty("order_id")]
                public long orderId { get; set; }

                [JsonProperty("order_id_str")]
                public string orderIdStr { get; set; }

                [JsonProperty("order_source")]
                public string orderSource { get; set; }

                [JsonProperty("trigger_price")]
                public double triggerPrice { get; set; }

                [JsonProperty("order_price")]
                public double orderPrice { get; set; }

                [JsonProperty("created_at")]
                public long createdAt { get; set; }

                [JsonProperty("order_price_type")]
                public string orderPriceType { get; set; }

                public int status { get; set; }

                [JsonProperty("margin_mode")]
                public string marginMode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }

                [JsonProperty("contract_type", NullValueHandling = NullValueHandling.Ignore)]
                public string contractType { get; set; }

                [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
                public string pair { get; set; }

                [JsonProperty("business_type", NullValueHandling = NullValueHandling.Ignore)]
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
