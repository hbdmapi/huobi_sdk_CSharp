using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.Notify;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class WsNotifyTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Theory]
        [InlineData("XRP-USDT")]
        public void OrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });

            client.CrossSubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 1);
            client.IsolatedUnsubOrders(contractCode);
            client.CrossUnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("XRP-USDT", "USDT")]
        public void AccountsTest(string contractCode, string marginAccount)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubAcounts(contractCode, delegate (SubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 1);
            client.IsolatedUnsubAccounts(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);

            client.CrossSubAcounts(marginAccount, delegate (SubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 1);
            client.CrossUnsubAccounts(marginAccount);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("XRP-USDT")]
        public void PositionsTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubPositions(contractCode, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.IsolatedUnsubPositions(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);

            client.CrossSubPositions(contractCode, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.CrossUnsubPositions(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("XRP-USDT")]
        public void MatchOrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubMatchOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.IsolatedUnsubMathOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 15);

            client.CrossSubMatchOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 15);
            client.CrossUnsubMathOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 15);
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
            client.UnsubLiquidationOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void FundingRateTest(string contractCode)
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
        public void ContractInfoTest(string contractCode)
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
        [InlineData("XRP-USDT")]
        public void TriggerOrderTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubTriggerOrder(contractCode, delegate (SubTriggerOrderResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 30);
            client.IsolatedUnsubTriggerOrder(contractCode);
            System.Threading.Thread.Sleep(1000 * 15);

            client.CrossSubTriggerOrder(contractCode, delegate (SubTriggerOrderResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 30);
            client.CrossUnsubTriggerOrder(contractCode);
            System.Threading.Thread.Sleep(1000 * 15);
        }
    }
}
