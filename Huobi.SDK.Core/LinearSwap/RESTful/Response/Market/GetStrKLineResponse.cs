
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Market
{
    /// <summary>
    /// response for premium index kline/estimated rate kline two request<br/>
    /// GET /index/market/history/linear_swap_premium_index_kline<br/>
    /// GET /index/market/history/linear_swap_estimated_rate_kline<br/>
    /// </summary>
    public class GetStrKLineResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ch { get; set; }

        public string status { get; set; }

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            public long id { get; set; }

            public string vol { get; set; }

            public string count { get; set; }

            public string open { get; set; }

            public string close { get; set; }

            public string low { get; set; }

            public string high { get; set; }

            public string amount { get; set; }

            [JsonProperty("trade_turnover")]
            public double tradeTurnover { get; set; }
        }
    }
}
