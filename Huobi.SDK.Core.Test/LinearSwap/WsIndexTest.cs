using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.Index;

namespace Huobi.SDK.Core.Test
{
    public class WsIndexTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSIndexClient client = new WSIndexClient();

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
            client.UnsubPremiumIndexKLine(contractCode, period);
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
            client.UnreqPremiumIndexKLine(contractCode, period, from, to);
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
            client.UnsubEstimatedRateKLine(contractCode, period);
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
            client.UnreqEstimatedRateKLine(contractCode, period, from, to);
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
            client.UnsubBasis(contractCode, period);
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
            client.UnreqBasis(contractCode, period, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }
    }
}