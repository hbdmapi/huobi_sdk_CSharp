using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Spot.WS;
using Huobi.SDK.Core.Spot.WS.Response.AccountOrder;

namespace Huobi.SDK.Core.Test.Spot
{
    public class WsAccountOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSAccountOrderClient client = new WSAccountOrderClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData("shibusdt")]
        public void WSSubOrdersTest(string symbol)
        {
            client.SubOrders(symbol, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 600);
        }

        [Theory]
        [InlineData("shibusdt", 1)]
        public void WSSubTradeClearingTest(string symbol, int mode)
        {
            client.SubTradeClearing(symbol, mode, delegate (SubTradeClearingResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 600);
        }

        [Theory]
        [InlineData("1")]
        public void WSSubMatchOrdersTest(string mode)
        {
            client.SubMatchOrders(mode, delegate (SubAccountResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 600);
        }
    }
}