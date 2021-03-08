using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.RESTful.Response.TriggerOrder
{
    /// <summary>
    /// responce for trigger cancel/cancel all
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
            public List<Error> errors { get; set; }
            public class Error
            {
                [JsonProperty("order_id")]
                public string orderId { get; set; }

                [JsonProperty("err_code")]
                public int errorCode { get; set; }

                [JsonProperty("err_msg")]
                public string errorMessage { get; set; }
            }

            public string successes { get; set; }
        }
    }
}
