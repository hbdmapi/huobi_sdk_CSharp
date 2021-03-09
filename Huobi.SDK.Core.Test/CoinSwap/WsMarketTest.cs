using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.CoinSwap.WS;
using Huobi.SDK.Core.CoinSwap.WS.Response.Market;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class WsMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSMarketClient client = new WSMarketClient();

        [Theory]
        [InlineData("btc-usd", "1min")]
        public void WSSubKLineTest(string contractCode, string period)
        {
            client.SubKLine(contractCode, period, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("btc-usd", "1min", 1604395758, 1604396758)]
        public void WSReqKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqKLine(contractCode, period, delegate (ReqKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("btc-usd", "step0")]
        public void WSSubDepthTest(string contractCode, string type)
        {
            client.SubDepth(contractCode, type, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("btc-usd", "20")]
        public void WSIncrementalDepthTest(string contractCode, string size)
        {
            client.SubIncrementalDepth(contractCode, size, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("btc-usd")]
        public void WSDetailTest(string contractCode)
        {
            client.SubDetail(contractCode, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("btc-usd")]
        public void WSBBOTest(string contractCode)
        {
            client.SubBBO(contractCode, delegate (SubBBOResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("btc-usd")]
        public void WSSubTradeDetailTest(string contractCode)
        {
            client.SubTradeDetail(contractCode, delegate (SubTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("btc-usd")]
        public void WSReqTradeDetailTest(string contractCode)
        {
            client.ReqTradeDetail(contractCode, delegate (ReqTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }
    }
}