using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Order
{
    /// <summary>
    /// response for cancel order and cancel all order
    /// </summary>
    public class CancelOrderResponse
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
            public class Error
            {
                [JsonProperty("order_id")]
                public long orderId { get; set; }
                
                [JsonProperty("err_code")]
                public long errorCode { get; set; }

                [JsonProperty("err_msg")]
                public long errorMessage { get; set; }
            }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Error> errors { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string success { get; set; }
        }
    }
}
