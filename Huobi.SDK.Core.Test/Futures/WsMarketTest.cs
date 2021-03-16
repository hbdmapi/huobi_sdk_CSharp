using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Futures.WS;
using Huobi.SDK.Core.Futures.WS.Response.Market;

namespace Huobi.SDK.Core.Test.Futures
{
    public class WsMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSMarketClient client = new WSMarketClient();

        [Theory]
        [InlineData("btc_cw", "1min")]
        public void WSSubKLineTest(string symbol, string period)
        {
            client.SubKLine(symbol, period, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btc_cw", "1min", 1604395758, 1604396758)]
        public void WSReqKLineTest(string symbol, string period, long from, long to)
        {
            client.ReqKLine(symbol, period, delegate (ReqKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("bch_cw", "step0")]
        public void WSSubDepthTest(string symbol, string type)
        {
            client.SubDepth(symbol, type, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("bch_cw", "20")]
        public void WSIncrementalDepthTest(string symbol, string size)
        {
            client.SubIncrementalDepth(symbol, size, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btc_cw")]
        public void WSBBOTest(string symbol)
        {
            client.SubBBO(symbol, delegate (SubBBOResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("btc_cw")]
        public void WSDetailTest(string symbol)
        {
            client.SubDetail(symbol, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("btc_cq")]
        public void WSSubTradeDetailTest(string symbol)
        {
            client.SubTradeDetail(symbol, delegate (SubTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("btc_cq", 1)]
        public void WSReqTradeDetailTest(string symbol, int size)
        {
            client.ReqTradeDetail(symbol, delegate (ReqTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, size);
            System.Threading.Thread.Sleep(1000 * 50);
        }
    }
}