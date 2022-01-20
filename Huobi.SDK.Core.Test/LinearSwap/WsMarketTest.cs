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
        [InlineData("BTC-USDT", "1min")]
        [InlineData("BTC-HUSD", "1min")]
        public void WSSubKLineTest(string contractCode, string period)
        {
            bool has_data = false;
            client.SubKLine(contractCode, period, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1642640000, 1642645000)]
        [InlineData("BTC-HUSD", "1min", 1642640000, 1642645000)]
        public void WSReqKLineTest(string contractCode, string period, long from, long to)
        {
            bool has_data = false;
            client.ReqKLine(contractCode, period, delegate (ReqKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, from, to);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "step0")]
        [InlineData("BTC-HUSD", "step0")]
        public void WSSubDepthTest(string contractCode, string type)
        {
            bool has_data = false;
            client.SubDepth(contractCode, type, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "20")]
        [InlineData("BTC-HUSD", "20")]
        public void WSIncrementalDepthTest(string contractCode, string size)
        {
            bool has_data = false;
            client.SubIncrementalDepth(contractCode, size, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("BTC-HUSD")]
        public void WSDetailTest(string contractCode)
        {
            bool has_data = false;
            client.SubDetail(contractCode, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("BTC-HUSD")]
        public void WSBBOTest(string contractCode)
        {
            bool has_data = false;
            client.SubBBO(contractCode, delegate (SubBBOResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("btc-husd")]
        public void WSSubTradeDetailTest(string contractCode)
        {
            bool has_data = false;
            client.SubTradeDetail(contractCode, delegate (SubTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("btc-husd")]
        public void WSReqTradeDetailTest(string contractCode)
        {
            bool has_data = false;
            client.ReqTradeDetail(contractCode, delegate (ReqTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }
    }
}