using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.Index;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class WsIndexTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSIndexClient client = new WSIndexClient();

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        public void WSSubIndexKLineTest(string contractCode, string period)
        {
            client.SubIndexKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        public void WSReqIndexKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqIndexKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubPreiumIndexKLineTest(string contractCode, string period)
        {
            client.SubPremiumIndexKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqPremiumIndexKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqPremiumIndexKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubEstimatedRateKLineTest(string contractCode, string period)
        {
            client.SubEstimatedRateKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqEstimatedRateKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqEstimatedRateKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubBasisTest(string contractCode, string period)
        {
            client.SubBasis(contractCode, period, delegate (SubBasiesResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqBasisTest(string contractCode, string period, long from, long to)
        {
            client.ReqBasis(contractCode, period, delegate (ReqBasisResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", null)]
        public void WSSubMarkPriceKLineTest(string contractCode, string period, string id)
        {
            client.SubMarkPriceKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, id);
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1612409065, 1612409165, null)]
        public void WSReqMarkPriceKLineTest(string contractCode, string period, long from, long to, string id)
        {
            client.ReqMarkPriceKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to, id);
            System.Threading.Thread.Sleep(1000 * 80);
        }
    }
}