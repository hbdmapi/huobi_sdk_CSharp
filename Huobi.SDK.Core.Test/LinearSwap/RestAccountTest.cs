using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test
{
    public class RestAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData(null, false)]
        [InlineData("BTC-USDT", false)]
        [InlineData(null, true)]
        [InlineData("BTC-USDT", true)]
        public void RESTfulAccountAssetsTest(string contractCode, bool beSubUid)
        {
            var result = client.GetAccountAssetsAsync(contractCode).Result;
            if (beSubUid)
            {
                result = client.GetAccountAssetsAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("BTC-USDT", false)]
        [InlineData(null, true)]
        [InlineData("BTC-USDT", true)]
        public void RESTfulAccountPositionTest(string contractCode, bool beSubUid)
        {
            var result = client.GetAccountPositionAsync(contractCode).Result;
            if (beSubUid)
            {
                result = client.GetAccountPositionAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", false, null, null, null)]
        [InlineData("BTC-USDT", false, 10, 1, 30)]
        [InlineData("BTC-USDT", true, null, null, null)]
        [InlineData("BTC-USDT", true, 10, 1, 30)]
        public void RESTfulAccountTransHisTest(string marginAccount, bool beMasterSub = false, int? createDate = null,
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
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulAllSubAssetsTest(string contractCode)
        {
            var result = client.GetAllSubAssetsAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("USDT", "BTC-USDT", "ETH-USDT", 1, false, null)]
        //[InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "master_to_sub")]
        [InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "sub_to_master")]
        public void RESTfulAccountTransTest(string asset, string fromMarginAccount, string toMarginAccount, double amount,
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
        public void RESTfulValidLeverRateTest(string contractCode)
        {
            var result = client.GetValidLeverRateAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("limit", null)]
        [InlineData("limit", "ETH-USDT")]
        public void RESTfulGetOrderLimitTest(string orderPriceType, string contractCode)
        {
            var result = client.GetOrderLimitAsync(orderPriceType, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulGetFeeTest(string contractCode)
        {
            var result = client.GetFeeAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulGetTransferLimitTest(string contractCode)
        {
            var result = client.GetTransferLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulGetPositionLimitTest(string contractCode)
        {
            var result = client.GetPositionLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void RESTfulGetApiTradingStatusTest()
        {
            var result = client.GetApiTradingStatusAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}