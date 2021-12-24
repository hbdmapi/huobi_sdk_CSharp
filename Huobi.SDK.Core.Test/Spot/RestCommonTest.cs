using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Spot.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Spot.RESTful.Response.Common;

namespace Huobi.SDK.Core.Test.Spot
{
    public class RestCommonTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static CommonClient client = new CommonClient();

        [Fact]
        public void GetSystemStatusTest()
        {
            string result = client.GetSystemStatus().Result;
            Console.WriteLine(result);
        }

        [Fact]
        public void GetMarketStatusTest()
        {
            GetMarketStatusResponse result = client.GetMarketStatusAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Fact]
        public void GetSymbolsTest()
        {
            GetSymbolsResponse result = client.GetSymbolsAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void GetCurrencysTest()
        {
            GetCurrencysResponse result = client.GetCurrencysAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("usdt", null)]
        public void GetCurrencyTest(string currency, bool authorizedUser)
        {
            GetCurrencyResponse result=client.GetCurrencyAsync(currency, authorizedUser).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Fact]
        public void GetTimestampTest()
        {
            GetTimestampResponse result = client.GetTimestampAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}