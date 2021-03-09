using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.WS.Response.Market
{
    public class ReqTradeDetailResponse
    {
        public string rep { get; set; }

        public string status { get; set; }

        public string id { get; set; }

        public long ts { get; set; }

        public List<Data> data;

        public class Data
        {
            public long id { get; set; }

            public string price { get; set; }

            public string amount { get; set; }

            public string direction { get; set; }

            public long ts { get; set; }

            public string quantity { get; set; }
        }
    }
}
