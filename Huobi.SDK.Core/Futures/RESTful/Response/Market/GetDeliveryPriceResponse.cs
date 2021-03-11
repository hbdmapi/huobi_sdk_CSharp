
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    public class GetDeliveryPriceResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

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
            [JsonProperty("delivery_price")]
            public double deliveryPrice { get; set; }
        }
    }
}
