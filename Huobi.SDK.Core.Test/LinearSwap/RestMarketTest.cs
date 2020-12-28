using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test
{
    public class RestMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient(config["Host"]);
        
        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketContractInfoTest(string contractCode)
        {
            var result = client.GetContractInfoAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketIndexTest(string contractCode)
        {
            var result = client.GetIndexAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketPriceLimitTest(string contractCode)
        {
            var result = client.GetPriceLimitAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketOpenInterestTest(string contractCode)
        {
            var result = client.GetOpenInterestAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "step10")]
        public void RESTfulMarketDepthTest(string contractCode, string type)
        {
            var result = client.GetDepthAsync(contractCode, type).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1, null, null)]
        [InlineData("BTC-USDT", "1min", null, 1604048907, 1604049205)]
        public void RESTfulMarketHisKLineTest(string contractCode, string period, int? size, int? from, int? to)
        {
            var result = client.GetKLineAsync(contractCode, period, size, from, to).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketMergedTest(string contractCode)
        {
            var result = client.GetGetMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketTradeTest(string contractCode)
        {
            var result = client.GetTradeAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 5)]
        public void RESTfulMarketHisTradeTest(string contractCode, int size)
        {
            var result = client.GetHisTradeAsync(contractCode, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketRiskInfoTest(string contractCode)
        {
            var result = client.GetRiskInfoAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 10)]
        public void RESTfulMarketInsuranceFundTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetInsuranceFundAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketAdjustFactorTest(string contractCode)
        {
            var result = client.IsolatedGetAdjustFactorFundAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetAdjustFactorFundAsync(contractCode).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min", 1, null)]
        [InlineData("BTC-USDT", "60min", 1, 5)]
        public void RESTfulMarketHisOpenInterestTest(string contractCode, string period, int amountType, int? size)
        {
            var result = client.GetHisOpenInterestAsync(contractCode, period, amountType, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        public void RESTfulMarketEliteAccountRatioTest(string contractCode, string period)
        {
            var result = client.GetEliteAccountRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        public void RESTfulMarketElitePositionRatioTest(string contractCode, string period)
        {
            var result = client.GetElitePositionRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketApiStatusTest(string contractCode)
        {
            var result = client.IsolatedGetApiStatusAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("USDT")]
        public void RESTfulMarketTransferStatusTest(string marginAccount)
        {
            var result = client.CrossGetTransferStateAsync(marginAccount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketTradeStatusTest(string contractCode)
        {
            var result = client.CrossGetTradeStateAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketFundingRateTest(string contractCode)
        {
            var result = client.GetFundingRateAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 2)]
        public void RESTfulMarketHisFundingRateTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisFundingRateAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 0, 7, null, null)]
        [InlineData("BTC-USDT", 0, 90, 1, 2)]
        public void RESTfulMarketLiquidationOrdersTest(string contractCode, int tradeType, int createDate, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetLiquidationOrdersAsync(contractCode, tradeType, createDate, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5)]
        public void RESTfulMarketPremiumIndexKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetPremiumIndexKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5)]
        public void RESTfulMarketEstimatedRateKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetEstimatedRateKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5, null)]
        [InlineData("BTC-USDT", "5min", 5, "open")]
        public void RESTfulMarketBasisTest(string contractCode, string period, int size, string basisPriceType)
        {
            var result = client.GetBasisAsync(contractCode, period, size, basisPriceType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}