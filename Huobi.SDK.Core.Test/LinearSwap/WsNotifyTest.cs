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
        [InlineData("*")]
        public void OrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 20);
            client.IsolatedUnsubOrders(contractCode);

            client.CrossSubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 20);
            client.CrossUnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*", "USDT")]
        public void AccountsTest(string contractCode, string marginAccount)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.IsolatedSubAcounts(contractCode, delegate (IsolatedSubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 20);
            client.IsolatedUnsubAccounts(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);

            client.CrossSubAcounts(marginAccount, delegate (CrossSubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 20);
            client.CrossUnsubAccounts(marginAccount);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*")]
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
        [InlineData("*")]
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
        [InlineData("*", "swap")]
        [InlineData("*", "futures")]
        //[InlineData("*")]
        public void WSLiquidationOrdersTest(string contractCode, string businessType)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubLiquidationOrders(contractCode, delegate (SubLiquidationOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, null, businessType);
            System.Threading.Thread.Sleep(1000 * 60);
            client.UnsubLiquidationOrders(contractCode, null, businessType);
            System.Threading.Thread.Sleep(1000 * 5);

            Console.WriteLine("------------");
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
        [InlineData("BTC-USDT", "swap")]
        public void ContractInfoTest(string contractCode, string businessType)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubContractInfo(contractCode, delegate (SubContractInfoResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, null, businessType);
            System.Threading.Thread.Sleep(1000 * 60);
            client.UnsubContractInfo(contractCode, null);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*")]
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
