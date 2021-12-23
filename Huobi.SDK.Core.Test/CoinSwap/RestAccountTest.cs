using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.CoinSwap.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.CoinSwap.RESTful.Response.Account;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class RestAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"], Host.FUTURES);

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
        [InlineData("XRP-USD", true)]
        public void GetAccountInfoTest(string contractCode, bool beSubUid)
        {
            GetAccountInfoResponse result;
            if (beSubUid)
            {
                result = client.GetAccountInfoAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            else
            {
                result = client.GetAccountInfoAsync(contractCode).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("TRX-USD", true)]
        public void GetPositionInfoTest(string contractCode, bool beSubUid)
        {
            GetPositionInfoResponse result = client.GetPositionInfoAsync(contractCode).Result;
            if (beSubUid)
            {
                result = client.GetPositionInfoAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("TRX-USD")]
        public void GetAllSubAssetsTest(string contractCode)
        {
            var result = client.GetAllSubAssetsAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USDT", 1, 20)]
        [InlineData("TRX-USD", 1, 20)]
        public void GetSubAccountInfoListTest(string contractCode, int pageIndex, int pageSize)
        {
            var result = client.GetSubAccountInfoListAsync(contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD")]
        public void GetAccountPositionTest(string contractCode)
        {
            var result = client.GetAccountPositionAsync(contractCode).Result;

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
        [InlineData("TRX-USD", false, null, null, null)]
        //[InlineData("TRX-USD", true, 10, 1, 30)]
        public void AccountTransHisTest(string contractCode, bool beMasterSub = false, int? createDate = null,
                                               int? pageIndex = null, int? pageSize = null)
        {
            var result = client.GetAccountTransHisAsync(contractCode, beMasterSub, "3,4,5,6", createDate,
                                                            pageIndex, pageSize).Result;
            if (beMasterSub)
            {
                result = client.GetAccountTransHisAsync(contractCode, beMasterSub, "34,35", createDate,
                                                            pageIndex, pageSize).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", "5,6,7", null, null, null)]
        public void AccountFinancialRecordExactTest(string contractCode = null, string type = null,
                                                    long? startTime = null, long? endTime = null, long? fromId = null)
        {
            var result = client.GetFinancialRecordExactAsync(contractCode, type, startTime, endTime, fromId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XMR-USD", null, null, 1, 50)]
        public void AccountGetUserSettlementRecordsTest(string contractCode, long? startTime, long? endTime,
                                                             int? pageIndex = null, int? pageSize = null)
        {
            var result = client.GetUserSettlementRecordsAsync(contractCode, startTime, endTime, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 1, "sub_to_master")]
        public void AccountTransTest(string contractCode, double amount, string type)
        {
            var result = client.AccountTransferAsync(long.Parse(config["SubUid"]), contractCode, amount, type).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USD")]
        public void GetValidLeverRateTest(string contractCode)
        {
            var result = client.GetValidLeverRateAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("limit", null)]
        [InlineData("limit", "ETH-USD")]
        public void GetOrderLimitTest(string orderPriceType, string contractCode)
        {
            var result = client.GetOrderLimitAsync(orderPriceType, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USD")]
        public void GetFeeTest(string contractCode)
        {
            var result = client.GetFeeAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USD")]
        public void GetTransferLimitTest(string contractCode)
        {
            var result = client.GetTransferLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USD")]
        public void GetPositionLimitTest(string contractCode)
        {
            var result = client.GetPositionLimitAsync(contractCode).Result;
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

    }
}