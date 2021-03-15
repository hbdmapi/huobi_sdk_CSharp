using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Futures.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.Futures
{
    public class RestTransferTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TransferClient client = new TransferClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData("bch", 0.001, "futures-to-pro")]
        public void RESTfulTransferTest(string currency, double amount, string type)
        {
            var result = client.TransferAsync(currency, amount, type).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }
    }
}