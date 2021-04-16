using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Futures.WS;
using Huobi.SDK.Core.Futures.WS.Response.Index;

namespace Huobi.SDK.Core.Test.Futures
{
    public class WsIndexTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSIndexClient client = new WSIndexClient();

        [Theory]
        [InlineData("btc-usd", "1min")]
        public void WSSubIndexKLineTest(string symbol, string period)
        {
            client.SubIndexKLine(symbol, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("btc-usd", "1min", 1604395758, 1604396758)]
        public void WSReqIndexKLineTest(string symbol, string period, long from, long to)
        {
            client.ReqIndexKLine(symbol, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USD", "1min")]
        public void WSSubBasisTest(string symbol, string period)
        {
            client.SubBasis(symbol, period, delegate (SubBasiesResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USD", "1min", 1604395758, 1604396758)]
        public void WSReqBasisTest(string symbol, string period, long from, long to)
        {
            client.ReqBasis(symbol, period, delegate (ReqBasisResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        //[InlineData("BTC-USD", "1min", null)]
        [InlineData("BTC210416", "1min", null)]
        public void WSSubMarkPriceKLineTest(string symbol, string period, string id)
        {
            client.SubMarkPriceKLine(symbol, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, id);
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        //[InlineData("BTC-USD", "1min", 1612409065, 1612409165, null)]
        [InlineData("BTC210416", "1min", 1618550421, 1618553421, null)]
        public void WSReqMarkPriceKLineTest(string symbol, string period, long from, long to, string id)
        {
            client.ReqMarkPriceKLine(symbol, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to, id);
            System.Threading.Thread.Sleep(1000 * 80);
        }
    }
}