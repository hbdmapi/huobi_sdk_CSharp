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
        [InlineData("btc-husd", "1min")]
        public void WSSubIndexKLineTest(string contractCode, string period)
        {
            bool has_data = false;
            client.SubIndexKLine(contractCode, period, delegate (SubIndexKLineResponse data)
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
        [InlineData("btc-husd", "1min", 1642640000, 1642645000)]
        public void WSReqIndexKLineTest(string contractCode, string period, long from, long to)
        {
            bool has_data = false;
            client.ReqIndexKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, from, to);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("btc-husd", "1min")]
        public void WSSubPreiumIndexKLineTest(string contractCode, string period)
        {
            bool has_data = false;
            client.SubPremiumIndexKLine(contractCode, period, delegate (SubIndexKLineResponse data)
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
        [InlineData("btc-husd", "1min", 1642640000, 1642645000)]
        public void WSReqPremiumIndexKLineTest(string contractCode, string period, long from, long to)
        {
            bool has_data = false;
            client.ReqPremiumIndexKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, from, to);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("btc-husd", "1min")]
        public void WSSubEstimatedRateKLineTest(string contractCode, string period)
        {
            bool has_data = false;
            client.SubEstimatedRateKLine(contractCode, period, delegate (SubIndexKLineResponse data)
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
        [InlineData("btc-husd", "1min", 1642640000, 1642645000)]
        public void WSReqEstimatedRateKLineTest(string contractCode, string period, long from, long to)
        {
            bool has_data = false;
            client.ReqEstimatedRateKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, from, to);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("btc-husd", "1min")]
        public void WSSubBasisTest(string contractCode, string period)
        {
            bool has_data = false;
            client.SubBasis(contractCode, period, delegate (SubBasiesResponse data)
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
        [InlineData("btc-husd", "1min", 1642640000, 1642645000)]
        public void WSReqBasisTest(string contractCode, string period, long from, long to)
        {
            bool has_data = false;
            client.ReqBasis(contractCode, period, delegate (ReqBasisResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, from, to);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", null)]
        [InlineData("btc-husd", "1min", null)]
        public void WSSubMarkPriceKLineTest(string contractCode, string period, string id)
        {
            bool has_data = false;
            client.SubMarkPriceKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, id);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1642640000, 1642645000, null)]
        [InlineData("btc-husd", "1min", 1642640000, 1642645000, null)]
        public void WSReqMarkPriceKLineTest(string contractCode, string period, long from, long to, string id)
        {
            bool has_data = false;
            client.ReqMarkPriceKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            }, from, to, id);
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }
    }
}