
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Market
{
    /// <summary>
    /// response for Elite Position/Elite account two request
    /// </summary>
    public class GetElitePositionRatioResponse
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
            public string symbol { get; set; }

            public List<ShortLongRatio> list { get; set; }
            public class ShortLongRatio
            {
                [JsonProperty("buy_ratio")]
                public double buyRatio { get; set; }

                [JsonProperty("sell_ratio")]
                public double sellRatio { get; set; }

                [JsonProperty("locked_ratio", NullValueHandling=NullValueHandling.Ignore)]
                public double? lockedRatio { get; set; }

                public long ts { get; set; }
            }
        }
    }
}
