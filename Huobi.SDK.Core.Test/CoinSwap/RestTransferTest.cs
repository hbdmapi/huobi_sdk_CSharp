using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.CoinSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class RestTransferTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TransferClient client = new TransferClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData("spot", "swap", "trx", 10)]
        public void RESTfulTransferTest(string from, string to, string currency, double amount)
        {
            var result = client.TransferAsync(from, to, currency, amount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.True(result.success);
        }
    }
}