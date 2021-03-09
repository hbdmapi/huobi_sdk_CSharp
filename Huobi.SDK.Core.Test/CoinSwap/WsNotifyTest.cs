using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.CoinSwap.WS;
using Huobi.SDK.Core.CoinSwap.WS.Response.Notify;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class WsNotifyTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Theory]
        //[InlineData("trx-usd")]
        [InlineData("*")]
        public void OrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 1);

            client.UnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 60*1);
        }

        [Theory]
        //[InlineData("trx-usd")]
        [InlineData("*")]
        public void AccountsTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubAcounts(contractCode, delegate (SubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 1);

            client.UnsubAccounts(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        //[InlineData("trx-usd")]
        [InlineData("*")]
        public void PositionsTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubPositions(contractCode, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60*2);
            client.UnsubPositions(contractCode);
            System.Threading.Thread.Sleep(1000 * 60*1);
        }

        [Theory]
        //[InlineData("trx-usd")]
        [InlineData("*")]
        public void MatchOrdersTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubMatchOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60*1);
            client.UnsubMathOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 60);
        }

        [Theory]
        [InlineData("doge-usd")]
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
        [InlineData("trx-usd")]
        //[InlineData("*")]
        public void FundingRateTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubFundingRate(contractCode, delegate (SubFundingRateResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
            client.UnsubFundingRate(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("trx-usd")]
        //[InlineData("*")]
        public void ContractInfoTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient();
            client.SubContractInfo(contractCode, delegate (SubContractInfoResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60);
            client.UnsubContractInfo(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        //[InlineData("trx-usd")]
        [InlineData("*")]
        public void TriggerOrderTest(string contractCode)
        {
            WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);
            client.SubTriggerOrder(contractCode, delegate (SubTriggerOrderResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60*2);
            client.UnsubTriggerOrder(contractCode);
            System.Threading.Thread.Sleep(1000 * 60);
        }
    }
}
