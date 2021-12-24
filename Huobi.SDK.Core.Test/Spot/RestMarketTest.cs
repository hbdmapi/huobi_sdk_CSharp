using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Spot.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Spot.RESTful.Response.Market;

namespace Huobi.SDK.Core.Test.Spot
{
    public class RestMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient();

        [Theory]
        [InlineData("btcusdt", "1min")]
        public void GetSystemStatusTest(string symbol, string period)
        {
            GetRequest request = new GetRequest();
            request.AddParam("symbol", symbol);
            request.AddParam("period", period);

            GetKlineResponse result = client.GetKlineAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void GetMergedTest(string symbol)
        {
            GetMergedResponse result = client.GetMergedAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void GetTicksTest()
        {
            GetTickersResponse result = client.GetTicksAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btcusdt", "5", "step0")]
        public void GetDepthTest(string symbol, string depth, string type)
        {
            GetRequest request = new GetRequest();
            request.AddParam("symbol", symbol);
            request.AddParam("depth", depth);
            request.AddParam("type", type);

            GetDepthResponse result = client.GetDepthAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void GetTradeTest(string symbol)
        {
            GetTradeResponse result = client.GetTradeAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btcusdt", 10)]
        public void GetHisTradeTest(string symbol, int size)
        {
            GetHisTradesResponse result = client.GetHisTradesAsync(symbol, size).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btcusdt")]
        public void GetDetailTest(string symbol)
        {
            GetDetailResponse result = client.GetDetailAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}