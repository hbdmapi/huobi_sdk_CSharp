using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Spot.WS;
using Huobi.SDK.Core.Spot.WS.Response.Market;

namespace Huobi.SDK.Core.Test.Spot
{
    public class WsMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSMarketClient client = new WSMarketClient();

        [Theory]
        [InlineData("btcusdt", "1min")]
        public void WSSubKLineTest(string symbol, string period)
        {
            client.SubKLine(symbol, period, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void WSSubTickerTest(string symbol)
        {
            client.SubTicker(symbol, delegate (SubTickerResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btcusdt", "step0")]
        public void WSSubDepthTest(string symbol, string type)
        {
            client.SubDepth(symbol, type, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btcusdt", 5, false)]
        public void WSSubMBPTest(string symbol, int levels, bool beRefresh)
        {
            client.SubMBP(symbol, levels, beRefresh, delegate (SubMBPResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void WSSubBBOTest(string symbol)
        {
            client.SubBBO(symbol, delegate (SubBBOResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void WSSubTradeDetailTest(string symbol)
        {
            client.SubTradeDetail(symbol, delegate (SubTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void WSSubDetailTest(string symbol)
        {
            client.SubDetail(symbol, delegate (SubDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
        }
    }
}