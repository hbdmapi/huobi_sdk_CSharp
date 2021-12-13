using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient(config["Host"]);
        
        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("BTC-USDT", null, null, null)]
        [InlineData("BTC-USDT", "all", "swap", "btc-usdt")]
        [InlineData(null, "futures", "quarter", "btc-usdt")]
        public void RESTfulMarketContractInfoTest(string contractCode, string businessType, 
                                                  string contractType, string pair)
        {
            var result = client.GetContractInfoAsync(contractCode, businessType, contractType, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
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
        [InlineData(null, null, null, null)]
        [InlineData("btc-usdt", null, null, null)]
        [InlineData("btc-usdt", "all", "quarter", "btc-usdt")]
        [InlineData(null, "all", "quarter", "btc-usdt")]
        public void RESTfulMarketPriceLimitTest(string contractCode, string businessType, 
                                                string contractType, string pair)
        {
            var result = client.GetPriceLimitAsync(contractCode, businessType, contractType, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("BTC-USDT", null, null, null)]
        [InlineData("btc-usdt", "all", "quarter", "btc-usdt")]
        [InlineData(null, "all", "quarter", "btc-usdt")]
        public void RESTfulMarketOpenInterestTest(string contractCode, string businessType, 
                                                  string contractType, string pair)
        {
            var result = client.GetOpenInterestAsync(contractCode, businessType, contractType, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "step10")]
        [InlineData("BTC-USDT-CQ", "step10")]
        [InlineData("btc-usdt-211231", "step10")]
        public void RESTfulMarketDepthTest(string contractCode, string type)
        {
            var result = client.GetDepthAsync(contractCode, type).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData(null, "futures")]
        [InlineData(null, "all")]
        public void RESTfulMarketBboTest(string contractCode, string businessType)
        {
            var result = client.GetBboAsync(contractCode, businessType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1, null, null)]
        [InlineData("BTC-USDT", "1min", null, 1604048907, 1604049205)]
        [InlineData("btc-usdt-cq", "1min", 1, null, null)]
        [InlineData("btc-usdt-211231", "1min", 1, null, null)]
        public void RESTfulMarketHisKLineTest(string contractCode, string period, int? size, int? from, int? to)
        {
            var result = client.GetKLineAsync(contractCode, period, size, from, to).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("BTC-USDT", "15min", 1)]
        [InlineData("BTC-usdt-CQ", "15min", 1)]
        [InlineData("BTC-USDT-211231", "15min", 1)]
        public void RESTfulMarketMarkKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetMarkPriceKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("BTC-USDT-CQ")]
        [InlineData("btc-usdt-211231")]
        public void RESTfulMarketMergedTest(string contractCode)
        {
            var result = client.GetMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-USDT-CQ", null)]
        [InlineData("BTC-USDT-211231", null)]
        public void RESTfulMarketBatchMergedTest(string contractCode, string businessType)
        {
            var result = client.GetBatchMergedAsync(contractCode, businessType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("btc-usdt", null)]
        [InlineData("btc-usdt-cq", null)]
        [InlineData("btc-usdt-211231", null)]
        public void RESTfulMarketTradeTest(string contractCode, string businessType)
        {
            var result = client.GetTradeAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("BTC-USDT", 5)]
        [InlineData("BTC-USDT-CQ", 5)]
        [InlineData("BTC-USDT-211231", 5)]
        public void RESTfulMarketHisTradeTest(string contractCode, int size)
        {
            var result = client.GetHisTradeAsync(contractCode, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-USDT-FUTURES", "all")]
        public void RESTfulMarketRiskInfoTest(string contractCode, string businessType)
        {
            var result = client.GetRiskInfoAsync(contractCode, businessType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
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
        public void RESTfulMarketIsolatedAdjustFactorTest(string contractCode)
        {
            var result = client.IsolatedGetAdjustFactorFundAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", null, null, null)]
        [InlineData("BTC-USDT", "futures", "quarter", "btc-usdt")]
        [InlineData(null, "futures", "quarter", "btc-usdt")]
        public void RESTfulMarketCrossAdjustFactorTest(string contractCode, string businessType, 
                                                       string contractType, string pair)
        {

            var result = client.CrossGetAdjustFactorFundAsync(contractCode, businessType, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("60min", 1, null, null, null, null)]
        [InlineData("60min", 1, null, "btc-usdt", null, null)]
        [InlineData("60min", 1, null, null, "quarter", "btc-usdt")]
        public void RESTfulMarketHisOpenInterestTest(string period, int amountType, int? size,
                                                     string contractCode, string contractType, string pair)
        {
            var result = client.GetHisOpenInterestAsync(period, amountType, size, contractCode, contractType, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketGetLadderMarginTest(string contractCode)
        {
            var result = client.IsolatedGetLadderMarginAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetLadderMarginAsync(contractCode).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        [InlineData("BTC-USDT-FUTURES", "60min")]
        public void RESTfulMarketEliteAccountRatioTest(string contractCode, string period)
        {
            var result = client.GetEliteAccountRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        [InlineData("BTC-USDT-FUTURES", "60min")]
        public void RESTfulMarketElitePositionRatioTest(string contractCode, string period)
        {
            var result = client.GetElitePositionRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
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
        [InlineData(null, null, null, null)]
        [InlineData("BTC-USDT", "all", null, null)]
        [InlineData(null, "futures", "quarter", "eth-usdt")]
        public void RESTfulMarketTradeStatusTest(string contractCode, string businessType, 
                                                 string contractType, string pair)
        {
            var result = client.CrossGetTradeStateAsync(contractCode, businessType, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
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
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketBatchFundingRateTest(string contractCode)
        {
            var result = client.GetBatchFundingRateAsync(contractCode).Result;

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
        [InlineData(0, 7, null, null, "BTC-USDT", null)]
        [InlineData(0, 90, 1, 2, null, "eth-usdt")]
        public void RESTfulMarketLiquidationOrdersTest(int tradeType, int createDate, 
                                                       int? pageIndex, int? pageSize,
                                                       string contractCode, string pair)
        {
            var result = client.GetLiquidationOrdersAsync(tradeType, createDate, pageIndex, pageSize, contractCode, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 1639300007924, 1639378937924, null, null)]
        [InlineData("BTC-USDT", 1639300007924, 1639378937924, 1, 2)]
        [InlineData("BTC-USDT-211231", 1639300007924, 1639378937924, 1, 2)]
        public void RESTfulMarketSettlementRecordsTest(string contractCode, long? startTime, long? endTime, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetSettlementRecordsAsync(contractCode, startTime, endTime, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
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
        [InlineData("BTC-USDT-CQ", "5min", 5, "open")]
        [InlineData("btc-usdt-211231", "5min", 5, "open")]
        public void RESTfulMarketBasisTest(string contractCode, string period, int size, string basisPriceType)
        {
            var result = client.GetBasisAsync(contractCode, period, size, basisPriceType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("BTC-USDT", "all", null, null)]
        [InlineData(null, "futures", "eth-usdt", "quarter")]
        public void RESTfulMarketEstimatedSettlementPriceTest(string contractCode, string businessType, 
                                                              string contractType, string pair)
        {
            var result = client.GetEstimatedSettlementPriceAsync(contractCode, businessType, contractType, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", "ok");
        }

    }
}