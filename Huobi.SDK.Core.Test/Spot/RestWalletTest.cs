using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Spot.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Spot.RESTful.Response.Wallet;
using Huobi.SDK.Core.Spot.RESTful.Request.Wallet;

namespace Huobi.SDK.Core.Test.Spot
{
    public class RestWalletTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WalletClient client = new WalletClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData("usdt")]
        public void GetDepositAddressTest(string currency)
        {
            GetRequest request = new GetRequest();
            request.AddParam("currency", currency);

            GetDepositAddressResponse result=client.GetDepositAddressAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Theory]
        [InlineData("usdt")]
        public void GetWithdrawQuotaTest(string currency)
        {
            GetRequest request = new GetRequest();
            request.AddParam("currency", currency);

            GetWithdrawQuotaResponse result=client.GetWithdrawQuotaAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }
        
        [Theory]
        [InlineData("usdt")]
        public void GetWithdrawAddressTest(string currency)
        {
            GetRequest request = new GetRequest();
            request.AddParam("currency", currency);

            GetDepositAddressResponse result=client.GetWithdrawAddressAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal(200, result.code);
        }

        [Theory]
        [InlineData("xxx", "1", "btc", "0.01")]
        public void WithdrawCurrencyTest(string address, string amount, string currency, string fee)
        {
            WithdrawRequest request = new WithdrawRequest()
            {
                address = address,
                amount = amount,
                currency = currency,
                fee = fee
            };

            WithdrawCurrencyResponse result=client.WithdrawCurrencyAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(123)]
        public void CancelWithdrawCurrencyTest(long withdrawId)
        {
            CancelWithdrawCurrencyResponse result=client.CancelWithdrawCurrencyAsync(withdrawId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("deposit")]
        public void GetDepositWithdrawHistoryTest(string type)
        {
            GetRequest request = new GetRequest();
            request.AddParam("type", type);

            GetDepositWithdrawHistoryResponse result=client.GetDepositWithdrawHistoryAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}