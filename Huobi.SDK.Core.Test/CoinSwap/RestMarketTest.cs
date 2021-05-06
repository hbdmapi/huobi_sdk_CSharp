using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.CoinSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class RestMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient(config["Host"]);
        
        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketContractInfoTest(string contractCode)
        {
            var result = client.GetContractInfoAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketIndexTest(string contractCode)
        {
            var result = client.GetIndexAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        public void RESTfulMarketPriceLimitTest(string contractCode)
        {
            var result = client.GetPriceLimitAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketOpenInterestTest(string contractCode)
        {
            var result = client.GetOpenInterestAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "step10")]
        public void RESTfulMarketDepthTest(string contractCode, string type)
        {
            var result = client.GetDepthAsync(contractCode, type).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD")]
        [InlineData(null)]
        public void RESTfulMarketBboTest(string contractCode)
        {
            var result = client.GetBboAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "1min", 1, null, null)]
        [InlineData("BTC-USD", "1min", null, 1604048907, 1604049205)]
        public void RESTfulMarketHisKLineTest(string contractCode, string period, int? size, int? from, int? to)
        {
            var result = client.GetKLineAsync(contractCode, period, size, from, to).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "15min", 1)]
        public void RESTfulMarketMarkKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetMarkPriceKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD")]
        public void RESTfulMarketMergedTest(string contractCode)
        {
            var result = client.GetMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD")]
        //[InlineData(null)]
        public void RESTfulMarketBatchMergedTest(string contractCode)
        {
            var result = client.GetBatchMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD")]
        public void RESTfulMarketTradeTest(string contractCode)
        {
            var result = client.GetTradeAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", 5)]
        public void RESTfulMarketHisTradeTest(string contractCode, int size)
        {
            var result = client.GetHisTradeAsync(contractCode, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketRiskInfoTest(string contractCode)
        {
            var result = client.GetRiskInfoAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", null, null)]
        [InlineData("BTC-USD", 1, 10)]
        public void RESTfulMarketInsuranceFundTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetInsuranceFundAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketAdjustFactorTest(string contractCode)
        {
            var result = client.GetAdjustFactorFundAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "60min", 1, null)]
        [InlineData("BTC-USD", "60min", 1, 5)]
        public void RESTfulMarketHisOpenInterestTest(string contractCode, string period, int amountType, int? size)
        {
            var result = client.GetHisOpenInterestAsync(contractCode, period, amountType, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD")]
        public void RESTfulMarketGetLadderMarginTest(string contractCode)
        {
            var result = client.GetLadderMarginAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "60min")]
        public void RESTfulMarketEliteAccountRatioTest(string contractCode, string period)
        {
            var result = client.GetEliteAccountRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "60min")]
        public void RESTfulMarketElitePositionRatioTest(string contractCode, string period)
        {
            var result = client.GetElitePositionRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketApiStatusTest(string contractCode)
        {
            var result = client.GetApiStatusAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD")]
        public void RESTfulMarketFundingRateTest(string contractCode)
        {
            var result = client.GetFundingRateAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketBatchFundingRateTest(string contractCode)
        {
            var result = client.GetBatchFundingRateAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USD", null, null)]
        [InlineData("BTC-USD", 1, 2)]
        public void RESTfulMarketHisFundingRateTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisFundingRateAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", 0, 7, null, null)]
        [InlineData("BTC-USD", 0, 90, 1, 2)]
        public void RESTfulMarketLiquidationOrdersTest(string contractCode, int tradeType, int createDate, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetLiquidationOrdersAsync(contractCode, tradeType, createDate, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "5min", 5)]
        public void RESTfulMarketPremiumIndexKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetPremiumIndexKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "5min", 5)]
        public void RESTfulMarketEstimatedRateKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetEstimatedRateKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", 1613757720120, 1614757720120, null, null)]
        [InlineData("BTC-USD", 1613757720120, 1614757720120, 1, 2)]
        public void RESTfulMarketSettlementRecordsTest(string contractCode, long? startTime, long? endTime, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetSettlementRecordsAsync(contractCode, startTime, endTime, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USD", "5min", 5, null)]
        [InlineData("BTC-USD", "5min", 5, "open")]
        public void RESTfulMarketBasisTest(string contractCode, string period, int size, string basisPriceType)
        {
            var result = client.GetBasisAsync(contractCode, period, size, basisPriceType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USD")]
        public void RESTfulMarketEstimatedSettlementPriceTest(string contractCode)
        {
            var result = client.GetEstimatedSettlementPriceAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}