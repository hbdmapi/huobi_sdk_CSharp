using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Futures.WS;
using Huobi.SDK.Core.Futures.WS.Response.Notify;

namespace Huobi.SDK.Core.Test.Futures
{
    public class WsNotifyTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Theory]
        //[InlineData("trx")]
        [InlineData("*")]
        public void OrdersTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubOrders(symbol, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 2);
            client.UnsubOrders(symbol);
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        //[InlineData("trx")]
        [InlineData("*")]
        public void MatchOrdersTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubMatchOrders(symbol, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 2);
            client.UnsubMathOrders(symbol);
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("trx")]
        //[InlineData("*")]
        public void AccountsTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubAcounts(symbol, delegate (SubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 2);
            client.UnsubAccounts(symbol);
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        //[InlineData("trx")]
        [InlineData("*")]
        public void PositionsTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubPositions(symbol, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
            client.UnsubPositions(symbol);
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("ada")]
        //[InlineData("*")]
        public void WSLiquidationOrdersTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubLiquidationOrders(symbol, delegate (SubLiquidationOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 1200);
            client.UnsubLiquidationOrders(symbol);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("ada")]
        //[InlineData("*")]
        public void ContractInfoTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubContractInfo(symbol, delegate (SubContractInfoResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.UnsubContractInfo(symbol);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        //[InlineData("trx")]
        [InlineData("*")]
        public void TriggerOrderTest(string symbol)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubTriggerOrder(symbol, delegate (SubTriggerOrderResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 *6);
            client.UnsubTriggerOrder(symbol);
            System.Threading.Thread.Sleep(1000 * 60);
        }
    }
}
