using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Futures.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.Futures
{
    public class RestMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient();
        
        [Theory]
        //[InlineData("BTC", "this_week", null)]
        //[InlineData(null, null, "BTC210312")]
        [InlineData(null, null, null)]
        public void RESTfulMarketContractInfoTest(string symbol, string contractType, string contractCode)
        {
            var result = client.GetContractInfoAsync(symbol, contractType, contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData(null)]
        [InlineData("btc")]
        public void RESTfulMarketIndexTest(string symbol)
        {
            var result = client.GetIndexAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC", "this_week", null)]
        [InlineData(null, null, "BTC210312")]
        //[InlineData(null, null, null)]
        public void RESTfulMarketPriceLimitTest(string symbol, string contractType, string contractCode)
        {
            var result = client.GetPriceLimitAsync(symbol, contractType, contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC", "this_week", null)]
        //[InlineData(null, null, "BTC210312")]
        //[InlineData(null, null, null)]
        public void RESTfulMarketOpenInterestTest(string symbol, string contractType, string contractCode)
        {
            var result = client.GetOpenInterestAsync(symbol, contractType, contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC")]
        public void RESTfulMarketDeliveryPricePriceTest(string symbol)
        {
            var result = client.GetDeliveryPriceAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        //[InlineData("BTC")]
        public void RESTfulMarketEstimatedSettlementPriceTest(string symbol)
        {
            var result = client.GetEstimatedSettlementPriceAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData(null)]
        [InlineData("BTC")]
        public void RESTfulMarketApiStatusTest(string symbol)
        {
            var result = client.GetApiStatusAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc_cw", "step10")]
        public void RESTfulMarketDepthTest(string symbol, string type)
        {
            var result = client.GetDepthAsync(symbol, type).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("btc_cw", "1min", 1, null, null)]
        [InlineData("btc_cw", "1min", null, 1604048907, 1604049205)]
        public void RESTfulMarketHisKLineTest(string symbol, string period, int? size, int? from, int? to)
        {
            var result = client.GetKLineAsync(symbol, period, size, from, to).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc_cw", "1min", 1)]
        [InlineData("btc210416", "1min", 1)]
        public void RESTfulMarketMarkKLineTest(string symbol, string period, int size)
        {
            var result = client.GetMarkPriceKLineAsync(symbol, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc_cw")]
        public void RESTfulMarketMergedTest(string symbol)
        {
            var result = client.GetMergedAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("btc_cw")]
        [InlineData(null)]
        public void RESTfulMarketBatchMergedTest(string contractCode)
        {
            var result = client.GetBatchMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc_cw")]
        //[InlineData(null)]
        public void RESTfulMarketTradeTest(string symbol)
        {
            var result = client.GetTradeAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc_cw", 100)]
        public void RESTfulMarketHisTradeTest(string symbol, int size)
        {
            var result = client.GetHisTradeAsync(symbol, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData(null)]
        [InlineData("btc")]
        public void RESTfulMarketRiskInfoTest(string symbol)
        {
            var result = client.GetRiskInfoAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc")]
        public void RESTfulMarketInsuranceFundTest(string symbol)
        {
            var result = client.GetInsuranceFundAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData(null)]
        [InlineData("btc")]
        public void RESTfulMarketAdjustFactorTest(string symbol)
        {
            var result = client.GetAdjustFactorFundAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc", "this_week", "60min", 1, 100)]
        public void RESTfulMarketHisOpenInterestTest(string symbol, string contractType, string period, int amountType, int size)
        {
            var result = client.GetHisOpenInterestAsync(symbol, contractType, period, amountType, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("btc")]
        [InlineData(null)]
        public void RESTfulMarketGetLadderMarginTest(string symbol)
        {
            var result = client.GetLadderMarginAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc", "60min")]
        public void RESTfulMarketEliteAccountRatioTest(string symbol, string period)
        {
            var result = client.GetEliteAccountRatioAsync(symbol, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("eth", "60min")]
        public void RESTfulMarketElitePositionRatioTest(string symbol, string period)
        {
            var result = client.GetElitePositionRatioAsync(symbol, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("btc", 0, 7, null, null)]
        [InlineData("btc", 0, 90, 1, 2)]
        public void RESTfulMarketLiquidationOrdersTest(string symbol, int tradeType, int createDate, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetLiquidationOrdersAsync(symbol, tradeType, createDate, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("btc", 1613757720120, 1614757720120, null, null)]
        [InlineData("btc", 1613757720120, 1614757720120, 1, 2)]
        public void RESTfulMarketSettlementRecordsTest(string symbol, long? startTime, long? endTime, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetSettlementRecordsAsync(symbol, startTime, endTime, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc-usd", "1min", 1)]
        public void RESTfulMarketIndexKLineTest(string symbol, string period, int size)
        {
            var result = client.GetIndexKLineAsync(symbol, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5, null)]
        //[InlineData("BTC-USDT", "5min", 5, "close")]
        public void RESTfulMarketBasisTest(string contractCode, string period, int size, string basisPriceType)
        {
            var result = client.GetBasisAsync(contractCode, period, size, basisPriceType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC_CW")]
        [InlineData("BTC210416")]
        [InlineData(null)]
        public void RESTfulMarketBboTest(string symbol)
        {
            var result = client.GetBboAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }


    }
}