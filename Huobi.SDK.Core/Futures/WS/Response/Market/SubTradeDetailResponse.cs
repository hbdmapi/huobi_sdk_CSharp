using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS.Response.Market
{
    public class SubTradeDetailResponse
    {
        public string ch { get; set; }

        public long ts { get; set; }

        public Tick tick;

        public class Tick
        {
            public long id { get; set; }

            public long ts { get; set; }

            public List<Data> data { get; set; }

            public class Data
            {
                public double amount { get; set; }

                public long ts { get; set; }

                public long id { get; set; }

                public double price { get; set; }

                public string direction { get; set; }

                public double quantity { get; set; }
            }
        }
    }
}
