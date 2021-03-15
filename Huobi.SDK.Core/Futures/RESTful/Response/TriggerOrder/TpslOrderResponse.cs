using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.TriggerOrder
{
    /// <summary>
    /// responce for place trigger order
    /// </summary>
    public class TpslOrderResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        public Data data { get; set; }

        public class Data
        {
            [JsonProperty("tp_order", NullValueHandling = NullValueHandling.Ignore)]
            public Order tpOrder { get; set; }

            [JsonProperty("sl_order", NullValueHandling = NullValueHandling.Ignore)]
            public Order slOrder { get; set; }

            public class Order
            {
                [JsonProperty("order_id")]
                public long orderId { get; set; }

                [JsonProperty("order_id_str")]
                public string orderIdStr { get; set; }
            }
        }
    }
}
