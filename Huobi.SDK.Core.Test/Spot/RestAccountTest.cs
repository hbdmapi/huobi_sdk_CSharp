using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Spot.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Spot.RESTful.Response.Account;
using Huobi.SDK.Core.Spot.RESTful.Request.Account;

namespace Huobi.SDK.Core.Test.Spot
{
    public class RestAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"], Host.SPOT);

        [Fact]
        public void GetAccountInfoTest()
        {
            GetAccountInfoResponse result = client.GetAccountInfoAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("38788389")]
        public void GetAccountBalanceTest(string accountId)
        {
            GetAccountBalanceResponse result=client.GetAccountBalanceAsync(accountId).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, null)]
        public void GetAccountValuationTest(string accountType, string valuationCurrency)
        {
            GetAccountValuationResponse result=client.GetAccountValuationAsync(accountType, valuationCurrency).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(true, result.success);
        }

        [Theory]
        [InlineData("spot", "BTC", null)]
        public void GetAccountAssetValuationTest(string accountType, string valuationCurrency, long? subUid)
        {
            GetAccountAssetValuationResponse result = client.GetAccountAssetValuationAsync(accountType, valuationCurrency, subUid).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Fact]
        public void TransferAccountAsyncTest()
        {
            TransferAccountRequest trans = new TransferAccountRequest()
            {
                fromUser = 0,
                fromAccountType = "spot",
                fromAccount = 0,
                toUser = 1,
                toAccountType = "spot",
                toAccount = 1,
                currency = "SHIB",
                amount = "1"
            };
            var result = client.TransferAccountAsync(trans).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("38788389")]
        public void GetAccountHistoryTest(string account_id)
        {
            GetRequest request = new GetRequest();
            request.AddParam("account-id", account_id);
            var result = client.GetAccountHistoryAsync(request).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("38788389")]
        public void GetAccountLedgerAsyncTest(string account_id)
        {
            GetRequest request = new GetRequest();
            request.AddParam("accountId", account_id);
            var result = client.GetAccountLedgerAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Theory]
        [InlineData("usdt", 1)]
        public void TransferFromSpotToFutureTest(string currency, decimal amount)
        {
            var result = client.TransferFromSpotToFutureAsync(currency, amount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("usdt", 1)]
        public void TransferFromFutureToSpotTest(string currency, decimal amount)
        {
            var result = client.TransferFromFutureToSpotAsync(currency, amount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        public void GetPointBalanceTest(string subUid)
        {
            var result = client.GetPointBalanceAsync(subUid).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Theory]
        [InlineData("38788389", "38788389", 0, "1")]
        public void TransferPointTest(string fromUid, string toUid, long groupId, string amount)
        {
            TransferPointRequest request = new TransferPointRequest()
            {
                fromUid = fromUid,
                toUid = toUid,
                groupId = groupId,
                amount = amount
            };
            var result = client.TransferPointAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

    }
}