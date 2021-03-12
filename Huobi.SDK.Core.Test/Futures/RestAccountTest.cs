using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Futures.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Futures.RESTful.Response.Account;

namespace Huobi.SDK.Core.Test.Futures
{
    public class RestAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData(null)]
        [InlineData("cny")]
        public void GetBalanceValuationTest(string valuationAsset)
        {
            GetBalanceValuationResponse result=client.GetBalanceValuationAsync(valuationAsset).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(null, true)]
        [InlineData("btc", false)]
        [InlineData("btc", true)]
        public void GetAccountInfoTest(string symbol, bool beSubUid)
        {
            GetAccountInfoResponse result;
            if (beSubUid)
            {
                result = client.GetAccountInfoAsync(symbol, long.Parse(config["SubUid"])).Result;
            }
            else
            {
                result = client.GetAccountInfoAsync(symbol).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(null, true)]
        [InlineData("btc", false)]
        [InlineData("btc", true)]
        public void GetPositionInfoTest(string symbol, bool beSubUid)
        {
            GetPositionInfoResponse result;
            if (beSubUid)
            {
                result = client.GetPositionInfoAsync(symbol, long.Parse(config["SubUid"])).Result;
            }
            else
            {
                result = client.GetPositionInfoAsync(symbol).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(1)]
        public void SetSubAuthTest(int subAuth)
        {
            var result = client.SetSubAuthAsync(config["SubUid"], subAuth).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("eth")]
        public void GetAllSubAssetsTest(string symbol)
        {
            var result = client.GetAllSubAssetsAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc", 1, 20)]
        public void GetSubAccountInfoListTest(string symbol, int pageIndex, int pageSize)
        {
            var result = client.GetSubAccountInfoListAsync(symbol, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", false, null, null, null)]
        //[InlineData("bch", true, 10, 1, 30)]
        public void AccountTransHisTest(string symbol, bool beMasterSub = false, int? createDate = null,
                                               int? pageIndex = null, int? pageSize = null)
        {
            var result = client.GetAccountTransHisAsync(symbol, beMasterSub, "3,4,5,6", createDate,
                                                            pageIndex, pageSize).Result;
            if (beMasterSub)
            {
                result = client.GetAccountTransHisAsync(symbol, beMasterSub, "34,35", createDate,
                                                            pageIndex, pageSize).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", null, null, null, null)]
        public void AccountFinancialRecordExactTest(string symbol, string type = null,
                                                    long? startTime = null, long? endTime = null, long? fromId = null)
        {
            var result = client.GetFinancialRecordExactAsync(symbol, type, startTime, endTime, fromId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("eth", null, null, 1, 10)]
        public void AccountGetUserSettlementRecordsTest(string symbol, long? startTime, long? endTime,
                                                             int? pageIndex = null, int? pageSize = null)
        {
            var result = client.GetUserSettlementRecordsAsync(symbol, startTime, endTime, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("limit", null)]
        [InlineData("limit", "eth")]
        public void GetOrderLimitTest(string orderPriceType, string symbol)
        {
            var result = client.GetOrderLimitAsync(orderPriceType, symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("trx")]
        public void GetFeeTest(string symbol)
        {
            var result = client.GetFeeAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("eth")]
        public void GetTransferLimitTest(string symbol)
        {
            var result = client.GetTransferLimitAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("btc")]
        public void GetPositionLimitTest(string symbol)
        {
            var result = client.GetPositionLimitAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch")]
        public void GetAccountPositionTest(string symbol)
        {
            var result = client.GetAccountPositionAsync(symbol).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 0.01, "sub_to_master")]
        public void AccountTransTest(string symbol, double amount, string type)
        {
            var result = client.AccountTransferAsync(symbol, amount, long.Parse(config["SubUid"]), type).Result;
            
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void GetApiTradingStatusTest()
        {
            var result = client.GetApiTradingStatusAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("bch")]
        public void GetValidLeverRateTest(string symbol)
        {
            var result = client.GetValidLeverRateAsync(symbol).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}