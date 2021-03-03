using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.Market;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class WsMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSMarketClient client = new WSMarketClient();

        [Theory]
        [InlineData("[BTC-USDT,EOS-USDT]", "1min")]
        //[InlineData("*", "1min")]
        public void WSSubKLineTest(string contractCode, string period)
        {
            client.SubKLine(contractCode, period, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqKLine(contractCode, period, delegate (ReqKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BCH-USDT", "step0")]
        //[InlineData("*", "step0")]
        public void WSSubDepthTest(string contractCode, string type)
        {
            client.SubDepth(contractCode, type, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "20")]
        [InlineData("*", "20")]
        public void WSIncrementalDepthTest(string contractCode, string size)
        {
            client.SubIncrementalDepth(contractCode, size, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSDetailTest(string contractCode)
        {
            client.SubDetail(contractCode, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSBBOTest(string contractCode)
        {
            client.SubBBO(contractCode, delegate (SubBBOResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void WSSubTradeDetailTest(string contractCode)
        {
            client.SubTradeDetail(contractCode, delegate (SubTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT")]
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