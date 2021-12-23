using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Account;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"], Host.FUTURES);

        [Theory]
        [InlineData(null)]
        [InlineData("btc")]
        public void GetBalanceValuationTest(string valuationAsset)
        {
            GetBalanceValuationResponse result=client.GetBalanceValuationAsync(valuationAsset).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("XRP-USDT", false)]
        [InlineData(null, true)]
        [InlineData("XRP-USDT", true)]
        public void IsolatedGetAccountInfoTest(string contractCode, bool beSubUid)
        {
            IsolatedGetAccountInfoResponse result;
            if (beSubUid)
            {
                result = client.IsolatedGetAccountInfoAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            else
            {
                result = client.IsolatedGetAccountInfoAsync(contractCode).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false, "swap", "shib-usdt")]
        [InlineData("USDT", false, null, null)]
        [InlineData(null, true, null, null)]
        [InlineData("USDT", true, "swap", "shib-usdt")]
        public void CrossGetAccountInfoTest(string marginAccount, bool beSubUid,
                                            string contractType, string pair)
        {
            CrossGetAccountInfoResponse result;
            if (beSubUid)
            {
                result = client.CrossGetAccountInfoAsync(marginAccount, long.Parse(config["SubUid"]), contractType, pair).Result;
            }
            else
            {
                result = client.CrossGetAccountInfoAsync(marginAccount).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("ETH-USDT", false)]
        [InlineData(null, true)]
        [InlineData("ETH-USDT", true)]
        public void IsolatedGetPositionInfoTest(string contractCode, bool beSubUid)
        {
            GetPositionInfoResponse result;
            if (beSubUid)
            {
                result = client.IsolatedGetPositionInfoAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            else
            {
                result = client.IsolatedGetPositionInfoAsync(contractCode).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false, null, null)]
        [InlineData("shib-usdt", false, null, null)]
        [InlineData(null, true, null, null)]
        [InlineData("shib-usdt", true, null, null)]
        public void CrossGetPositionInfoTest(string contractCode, bool beSubUid,
                                             string contractType, string pair)
        {
            GetPositionInfoResponse result;
            if (beSubUid)
            {
                result = client.CrossGetPositionInfoAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            else
            {
                result = client.CrossGetPositionInfoAsync(contractCode).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void IsolatedGetAllSubAssetsTest(string contractCode)
        {
            var result = client.IsolatedGetAllSubAssetsAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("USDT")]
        public void CrossGetAllSubAssetsTest(string marginAccount)
        {
            var result = client.CrossGetAllSubAssetsAsync(marginAccount).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USDT", 1, 20)]
        [InlineData("USDT", 1, 20)]
        public void GetSubAccountInfoListTest(string contractCode, int pageIndex, int pageSize)
        {
            var result = client.IsolatedGetSubAccountInfoListAsync(contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.IsolatedGetSubAccountInfoListAsync(contractCode, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("ETH-USDT")]
        public void IsolatedGetAccountPositionTest(string contractCode)
        {
            var result = client.IsolatedGetAccountPositionAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("USDT")]
        public void CrossGetAccountPositionTest(string marginAccount)
        {
            var result = client.CrossGetAccountPositionAsync(marginAccount).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("100000", 0)]
        public void SetSubAuthTest(string subUid, int subAuth)
        {
            var result = client.SetSubAuthAsync(subUid, subAuth).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", false, null, null, null)]
        [InlineData("BTC-USDT", false, 10, 1, 30)]
        [InlineData("BTC-USDT", true, null, null, null)]
        [InlineData("BTC-USDT", true, 10, 1, 30)]
        public void AccountTransHisTest(string marginAccount, bool beMasterSub = false, int? createDate = null,
                                               int? pageIndex = null, int? pageSize = null)
        {
            var result = client.GetAccountTransHisAsync(marginAccount, beMasterSub, "3,4,5,6", createDate,
                                                            pageIndex, pageSize).Result;
            if (beMasterSub)
            {
                result = client.GetAccountTransHisAsync(marginAccount, beMasterSub, "34,35", createDate,
                                                            pageIndex, pageSize).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", null, null, null, null, null)]
        //[InlineData("USDT", null, null, null, null, null)]
        public void AccountFinancialRecordExactTest(string marginAccount, string contractCode = null, string type = null,
                                                    long? startTime = null, long? endTime = null, long? fromId = null)
        {
            var result = client.GetFinancialRecordExactAsync(marginAccount, contractCode, type, startTime, endTime, fromId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", null, null, 1, 10)]
        public void AccountIsolatedGetUserSettlementRecordsTest(string contractCode, long? startTime, long? endTime,
                                                             int? pageIndex = null, int? pageSize = null)
        {
            var result = client.IsolatedGetUserSettlementRecordsAsync(contractCode, startTime, endTime, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("USDT", null, null, 1, 10)]
        public void AccountCrossGetUserSettlementRecordsTest(string marginAccount, long? startTime, long? endTime,
                                                             int? pageIndex = null, int? pageSize = null)
        {
            var result = client.CrossGetUserSettlementRecordsAsync(marginAccount, startTime, endTime, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("USDT", "BTC-USDT", "ETH-USDT", 1, false, null)]
        //[InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "master_to_sub")]
        [InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "sub_to_master")]
        public void AccountTransTest(string asset, string fromMarginAccount, string toMarginAccount, double amount,
                                            bool beMasterSub, string type = null)
        {
            var result = client.AccountTransferAsync(asset, fromMarginAccount, toMarginAccount, amount).Result;
            if (beMasterSub)
            {
                result = client.AccountTransferAsync(asset, fromMarginAccount, toMarginAccount, amount, long.Parse(config["SubUid"]), type).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void IsolatedGetValidLeverRateTest(string contractCode)
        {
            var result = client.IsolatedGetValidLeverRateAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc-usdt", null, null, null)]
        [InlineData("ETH-USDT", "swap", "swap", "LTC-USDT")]
        public void CrossGetValidLeverRateTest(string contractCode, string businessType, 
                                               string contractType, string pair)
        {
            var result = client.CrossGetValidLeverRateAsync(contractCode, businessType, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("limit", "btc-usdt", null, null, null)]
        [InlineData("limit", null, "swap", "swap", "eth-usdt")]
        [InlineData("limit", "ltc-usdt", "swap", "swap", "eth-usdt")]
        public void GetOrderLimitTest(string orderPriceType, string contractCode,
                                      string businessType, string contractType,
                                      string pair)
        {
            var result = client.GetOrderLimitAsync(orderPriceType, contractCode, businessType, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc-usdt", null, null, null)]
        [InlineData("ETH-USDT", "swap", "swap", "ltc-usdt")]
        public void GetFeeTest(string contractCode, string businessType, string contractType, string pair)
        {
            var result = client.GetFeeAsync(contractCode, businessType, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void IsolatedGetTransferLimitTest(string contractCode)
        {
            var result = client.IsolatedGetTransferLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("USDT")]
        public void CrossGetTransferLimitTest(string marginAccount)
        {
            var result = client.CrossGetTransferLimitAsync(marginAccount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void IsolatedGetPositionLimitTest(string contractCode)
        {
            var result = client.IsolatedGetPositionLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("btc-usdt", null, null, null)]
        [InlineData("ETH-USDT", "swap", "swap", "ltc-usdt")]
        public void CrossGetPositionLimitTest(string contractCode, string businessType,
                                              string contractType, string pair)
        {
            var result = client.CrossGetPositionLimitAsync(contractCode, businessType, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Console.WriteLine("------------");
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