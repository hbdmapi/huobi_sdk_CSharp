using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestTransferTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TransferClient client = new TransferClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        //[InlineData("linear-swap", "spot", 1, "BTC-USDT")]
        [InlineData("spot", "linear-swap", 1, "BTC-USDT")]
        public void RESTfulTransferTest(string from, string to, double amount, string marginAccount)
        {
            var result = client.TransferAsync(from, to, amount, marginAccount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.True(result.success);
        }
    }
}