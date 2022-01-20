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

        static WSNotifyClient client = new WSNotifyClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        // [InlineData("BTC-USDT")]
        [InlineData("BTC-HUSD")]
        // [InlineData("*")]
        public void IsolatedOrdersTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.IsolatedSubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    Assert.Equal(tp, data.tradePartition);
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 30);
            Assert.Equal(true, has_data);
            client.IsolatedUnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        // [InlineData("BTC-HUSD")]
        // [InlineData("*")]
        public void CrossOrdersTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.CrossSubOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    Assert.Equal(tp, data.tradePartition);
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 30);
            Assert.Equal(true, has_data);
            client.CrossUnsubOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("BTC-HUSD")]
        [InlineData("*")]
        public void IsolatedAccountsTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.IsolatedSubAcounts(contractCode, delegate (IsolatedSubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if(tp != null)
                {
                    foreach (var item in data.data)
                    {
                        Assert.Equal(tp, item.tradePartition);
                    }
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 10);
            Assert.Equal(true, has_data);
            client.IsolatedUnsubAccounts(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*", null, null)]
        [InlineData("usdt", null, null)]
        [InlineData("husd", null, "husd")]
        [InlineData("husd", null, "all")]
        public void AccountsTest(string marginAccount, string cid, string tradePartition)
        {
            bool has_data = false;
            string tp = null;
            if (tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                tp = "USDT";
            }
            else
            {
                tp = "HUSD";
            }
            client.CrossSubAcounts(marginAccount, delegate (CrossSubAccountsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if(marginAccount != "*")
                {
                    foreach (var d in data.data)
                    {
                        foreach (var item in d.contractDetail)
                        {
                            Assert.Equal(tp, item.tradePartition);
                        }
                        foreach (var item in d.futuresContractDetail)
                        {
                            Assert.Equal(tp, item.tradePartition);
                        }
                    }
                }
                has_data = true;
            }, cid, tradePartition);
            System.Threading.Thread.Sleep(1000 * 20);
            Assert.Equal(true, has_data);
            client.CrossUnsubAccounts(marginAccount);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*")]
        [InlineData("btc-usdt")]
        [InlineData("btc-husd")]
        public void IsolatedPositionsTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.IsolatedSubPositions(contractCode, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    foreach (var item in data.data)
                    {
                        Assert.Equal(tp, item.tradePartition);
                    }
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 10);
            Assert.Equal(true, has_data);
            client.IsolatedUnsubPositions(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*")]
        [InlineData("btc-usdt")]
        [InlineData("btc-husd")]
        public void CrossPositionsTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.CrossSubPositions(contractCode, delegate (SubPositionsResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    foreach (var item in data.data)
                    {
                        Assert.Equal(tp, item.tradePartition);
                    }
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 10);
            Assert.Equal(true, has_data);
            client.CrossUnsubPositions(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        // [InlineData("*")]
        // [InlineData("btc-usdt")]
        [InlineData("btc-husd")]
        public void IsolatedMatchOrdersTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.IsolatedSubMatchOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    Assert.Equal(tp, data.tradePartition);
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 20);
            Assert.Equal(true, has_data);
            client.IsolatedUnsubMathOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        // [InlineData("*")]
        [InlineData("btc-usdt")]
        // [InlineData("btc-husd")]
        public void CrossMatchOrdersTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.CrossSubMatchOrders(contractCode, delegate (SubOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    Assert.Equal(tp, data.tradePartition);
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 15);
            Assert.Equal(true, has_data);
            client.CrossUnsubMathOrders(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("btc-usdt", "swap", null)]
        [InlineData("btc-husd", "swap", "husd")]
        [InlineData("btc-husd", "swap", "all")]
        public void WSLiquidationOrdersTest(string contractCode, string businessType, string tradePartition)
        {
            string tp = null;
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                tp = "USDT";
            }else
            {
                tp = "HUSD";
            }
            WSNotifyClient client = new WSNotifyClient();
            client.SubLiquidationOrders(contractCode, delegate (SubLiquidationOrdersResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                foreach(var item in data.data)
                {
                    Assert.Equal(tp, item.tradePartition);
                }
            }, null, businessType, tradePartition);
            System.Threading.Thread.Sleep(1000 * 10);
            client.UnsubLiquidationOrders(contractCode, null, businessType, tradePartition);
            System.Threading.Thread.Sleep(1000 * 5);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-HUSD", null, "husd")]
        [InlineData("BTC-HUSD", null, "all")]
        public void FundingRateTest(string contractCode, string cid, string tradePartition)
        {
            bool has_data = false;
            string tp = null;
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                tp = "USDT";
            }else
            {
                tp = "HUSD";
            }
            WSNotifyClient client = new WSNotifyClient();
            client.SubFundingRate(contractCode, delegate (SubFundingRateResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                foreach(var item in data.data)
                {
                    Assert.Equal(tp, item.tradePartition);
                }
                has_data = true;
            }, cid, tradePartition);
            System.Threading.Thread.Sleep(1000 * 10);
            Assert.Equal(true, has_data);
            client.UnsubFundingRate(contractCode, cid, tradePartition);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT", "swap", null)]
        [InlineData("btc-husd", "swap", "husd")]
        [InlineData("btc-husd", "swap", "all")]
        public void ContractInfoTest(string contractCode, string businessType, string tradePartition)
        {
            bool has_data = false;
            string tp = null;
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                tp = "USDT";
            }else
            {
                tp = "HUSD";
            }
            WSNotifyClient client = new WSNotifyClient();
            client.SubContractInfo(contractCode, delegate (SubContractInfoResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                foreach(var item in data.data)
                {
                    Assert.Equal(tp, item.tradePartition);
                }
                has_data = true;
            }, null, businessType, tradePartition);
            System.Threading.Thread.Sleep(1000 * 10);
            Assert.Equal(true, has_data);
            client.UnsubContractInfo(contractCode, null, businessType, tradePartition);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        // [InlineData("BTC-USDT")]
        [InlineData("BTC-HUSD")]
        // [InlineData("*")]
        public void IsolatedTriggerOrderTest(string contractCode)
        {
            bool has_data = false;
            string tp = null;
            if (contractCode != "*")
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            client.IsolatedSubTriggerOrder(contractCode, delegate (SubTriggerOrderResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                if (tp != null)
                {
                    foreach (var item in data.data)
                    {
                        Assert.Equal(tp, item.tradePartition);
                    }
                }
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000 * 15);
            Assert.Equal(true, has_data);
            client.IsolatedUnsubTriggerOrder(contractCode);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("*")]
        public void CrossTriggerOrderTest(string contractCode)
        {

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
