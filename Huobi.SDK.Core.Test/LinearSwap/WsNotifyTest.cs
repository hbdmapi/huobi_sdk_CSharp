using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.Notify;

namespace Huobi.SDK.Core.Test
{
    public class WsNotifyTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSOrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 30);
            client.UnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSAccountsTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubAcounts(contractCode, delegate (SubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubAccounts(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSPositionsTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubPositions(contractCode, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubPositions(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("UNI-USDT")]
        [InlineData("*")]
        public void WSMatchOrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubMatchOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("ETH-USDT")]
        //[InlineData("*")]
        public void WSLiquidationOrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubLiquidationOrders(contractCode, delegate (SubLiquidationOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 1200);
            client.UnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSFundingRateTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubFundingRate(contractCode, delegate (SubFundingRateResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubFundingRate(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSContractInfoTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubContractInfo(contractCode, delegate (SubContractInfoResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubContractInfo(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSTriggerOrderTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubTriggerOrder(contractCode, delegate (SubTriggerOrderResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }
    }
}
