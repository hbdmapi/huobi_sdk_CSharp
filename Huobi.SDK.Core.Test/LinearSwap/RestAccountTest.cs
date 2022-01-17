using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Account;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData(null)]
        [InlineData("btc")]
        [InlineData("husd")]
        public void GetBalanceValuationTest(string valuationAsset)
        {
            GetBalanceValuationResponse result=client.GetBalanceValuationAsync(valuationAsset).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData(null, false, null)]
        // [InlineData("BTC-USDT", false, null)]
        // [InlineData("BTC-HUSD", false, "husd")]
        // [InlineData("BTC-HUSD", false, "all")]
        [InlineData(null, true, null)]
        [InlineData("BTC-USDT", true, null)]
        [InlineData("BTC-HUSD", true, "husd")]
        [InlineData("BTC-HUSD", true, "all")]
        public void IsolatedGetAccountInfoTest(string contractCode, bool beSubUid, string tradePartition)
        {
            IsolatedGetAccountInfoResponse result;
            if (beSubUid)
            {
                result = client.IsolatedGetAccountInfoAsync(contractCode, long.Parse(config["SubUid"]), tradePartition).Result;
            }
            else
            {
                result = client.IsolatedGetAccountInfoAsync(contractCode, null, tradePartition).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data)
            {
                if (contractCode != null)
                {
                    string type = contractCode.Split("-")[1].ToUpper();
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("USDT", false, null, null, null)]
        // [InlineData("HUSD", false, null, null, "husd")]
        // [InlineData("HUSD", false, null, null, "all")]
        [InlineData("USDT", true, null, null, null)]
        [InlineData("HUSD", true, null, null, "husd")]
        [InlineData("HUSD", true, null, null, "all")]
        public void CrossGetAccountInfoTest(string marginAccount, bool beSubUid,
                                            string contractType, string pair,
                                            string tradePartition)
        {
            CrossGetAccountInfoResponse result;
            if (beSubUid)
            {
                result = client.CrossGetAccountInfoAsync(marginAccount, long.Parse(config["SubUid"]), contractType, pair, tradePartition).Result;
            }
            else
            {
                result = client.CrossGetAccountInfoAsync(marginAccount, null, null, null, tradePartition).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var d in result.data)
            {
                foreach (var item in d.contractDetails)
                {
                    Assert.Equal(marginAccount, item.tradePartition);
                }
                foreach (var item in d.futuresContractDetail)
                {
                    Assert.Equal(marginAccount, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData(null, false, null)]
        // [InlineData("BTC-USDT", false, null)]
        // [InlineData("BTC-HUSD", false, "husd")]
        // [InlineData("BTC-HUSD", false, "all")]
        [InlineData(null, true, null)]
        [InlineData("BTC-USDT", true, null)]
        [InlineData("BTC-HUSD", true, "husd")]
        [InlineData("BTC-HUSD", true, "all")]
        public void IsolatedGetPositionInfoTest(string contractCode, bool beSubUid,
                                                string tradePartition)
        {
            GetPositionInfoResponse result;
            if (beSubUid)
            {
                result = client.IsolatedGetPositionInfoAsync(contractCode, long.Parse(config["SubUid"]), tradePartition).Result;
            }
            else
            {
                result = client.IsolatedGetPositionInfoAsync(contractCode, null, tradePartition).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData(null, false, null, null, null)]
        // [InlineData(null, false, "swap", "btc-usdt", null)]
        // [InlineData(null, false, "swap", "btc-husd", "husd")]
        // [InlineData("BTC-USDT", false, null, null, null)]
        // [InlineData("BTC-HUSD", false, null, null, "HUSD")]
        // [InlineData("BTC-HUSD", false, null, null, "ALL")]
        [InlineData(null, true, null, null, null)]
        [InlineData(null, true, "swap", "btc-usdt", null)]
        [InlineData(null, true, "swap", "btc-husd", "husd")]
        [InlineData("BTC-USDT", true, null, null, null)]
        [InlineData("BTC-HUSD", true, null, null, "HUSD")]
        [InlineData("BTC-HUSD", true, null, null, "all")]
        public void CrossGetPositionInfoTest(string contractCode, bool beSubUid,
                                             string contractType, string pair,
                                             string tradePartition)
        {
            GetPositionInfoResponse result;
            if (beSubUid)
            {
                result = client.CrossGetPositionInfoAsync(contractCode, long.Parse(config["SubUid"]), contractType, pair, tradePartition).Result;
            }
            else
            {
                result = client.CrossGetPositionInfoAsync(contractCode, null, contractType, pair, tradePartition).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void IsolatedGetAllSubAssetsTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetAllSubAssetsAsync(contractCode, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var d in result.data)
                {
                    foreach(var item in d.list)
                    {
                        Assert.Equal(type, item.tradePartition);
                    }
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData(null, null)]
        // [InlineData("USDT", null)]
        // [InlineData("husd", "husd")]
        [InlineData("husd", "")]
        public void CrossGetAllSubAssetsTest(string marginAccount, string tradePartition)
        {
            var result = client.CrossGetAllSubAssetsAsync(marginAccount, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (marginAccount != null)
            {
                string type = marginAccount.ToUpper();
                foreach (var d in result.data)
                {
                    foreach (var item in d.list)
                    {
                        Assert.Equal(type, item.tradePartition);
                    }
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", 1, 20, null)]
        [InlineData("BTC-HUSD", 1, 20, "husd")]
        [InlineData("BTC-HUSD", 1, 20, "all")]
        public void IsolatedGetSubAccountInfoListTest(string contractCode, int pageIndex, int pageSize,
                                                      string tradePartition)
        {
            var result = client.IsolatedGetSubAccountInfoListAsync(contractCode, pageIndex, pageSize, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach (var d in result.data.subList)
                {
                    foreach (var item in d.accountInfoList)
                    {
                        Assert.Equal("USDT", item.tradePartition);
                    }
                }
            }
            else if (tradePartition.ToLower() == "husd")
            {
                foreach (var d in result.data.subList)
                {
                    foreach (var item in d.accountInfoList)
                    {
                        Assert.Equal("HUSD", item.tradePartition);
                    }
                }
            }
            else if (tradePartition.ToLower() == "all" && contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach (var d in result.data.subList)
                {
                    foreach (var item in d.accountInfoList)
                    {
                        Assert.Equal(type, item.tradePartition);
                    }
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("USDT", 1, 20, null)]
        [InlineData("HUSD", 1, 20, "husd")]
        [InlineData("HUSD", 1, 20, "all")]
        public void CrossGetSubAccountInfoListTest(string marginAccount, int pageIndex, int pageSize,
                                                   string tradePartition)
        {
            var result = client.CrossGetSubAccountInfoListAsync(marginAccount, pageIndex, pageSize, tradePartition).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach (var d in result.data.subList)
                {
                    foreach (var item in d.accountInfoList)
                    {
                        Assert.Equal("USDT", item.tradePartition);
                    }
                }
            }
            else if (tradePartition.ToLower() == "husd")
            {
                foreach (var d in result.data.subList)
                {
                    foreach (var item in d.accountInfoList)
                    {
                        Assert.Equal("HUSD", item.tradePartition);
                    }
                }
            }
            else if (tradePartition.ToLower() == "all" && marginAccount != null)
            {
                string type = marginAccount.ToUpper();
                foreach (var d in result.data.subList)
                {
                    foreach (var item in d.accountInfoList)
                    {
                        Assert.Equal(type, item.tradePartition);
                    }
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void IsolatedGetAccountPositionTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetAccountPositionAsync(contractCode, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = null;
            if (tradePartition != null && tradePartition.ToUpper() != "all")
            {
                type = tradePartition.ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data)
            {
                Assert.Equal(type, item.tradePartition);
                foreach(var p in item.positions)
                {
                    Assert.Equal(type, p.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("USDT")]
        [InlineData("HUSD")]
        public void CrossGetAccountPositionTest(string marginAccount)
        {
            var result = client.CrossGetAccountPositionAsync(marginAccount).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = marginAccount.ToUpper();
            foreach (var item in result.data.contractDetail)
            {
                Assert.Equal(type, item.tradePartition);
            }
            foreach (var item in result.data.futuresContractDetail)
            {
                Assert.Equal(type, item.tradePartition);
            }
            foreach (var item in result.data.positions)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("100000", 0)]
        public void SetSubAuthTest(string subUid, int subAuth)
        {
            var result = client.SetSubAuthAsync(subUid, subAuth).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", false, null, null, null)]
        [InlineData("BTC-HUSD", false, null, null, null)]
        [InlineData("BTC-USDT", false, 10, 1, 30)]
        [InlineData("BTC-HUSD", false, 10, 1, 30)]
        [InlineData("USDT", false, null, null, null)]
        [InlineData("HUSD", false, 10, 1, 30)]
        [InlineData("BTC-USDT", true, null, null, null)]
        [InlineData("BTC-HUSD", true, null, null, null)]
        [InlineData("BTC-USDT", true, 10, 1, 30)]
        [InlineData("BTC-HUSD", true, 10, 1, 30)]
        [InlineData("USDT", true, null, null, null)]
        [InlineData("HUSD", true, 10, 1, 30)]
        public void AccountTransHisTest(string marginAccount, bool beMasterSub = false, int? createDate = null,
                                        int? pageIndex = null, int? pageSize = null)
        {
            var result = client.GetAccountTransHisAsync(marginAccount, beMasterSub, "3,4,5,6", createDate,
                                                        pageIndex, pageSize).Result;
            if (beMasterSub)
            {
                result = client.GetAccountTransHisAsync(marginAccount, beMasterSub, "34,35", createDate,
                                                        pageIndex, pageSize).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(result.data != null && result.data.financialRecord != null)
            {
                foreach (var item in result.data.financialRecord)
                {
                    string type = marginAccount.ToUpper();
                    if (marginAccount.IndexOf("-") != -1)
                    {
                        type = marginAccount.Split("-")[1].ToUpper();
                    }
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null, null, null, null, null)]
        [InlineData("BTC-HUSD", null, null, null, null, null)]
        [InlineData("USDT", null, null, null, null, null)]
        [InlineData("HUSD", null, null, null, null, null)]
        public void AccountFinancialRecordExactTest(string marginAccount, string contractCode = null, string type = null,
                                                    long? startTime = null, long? endTime = null, long? fromId = null)
        {
            var result = client.GetFinancialRecordExactAsync(marginAccount, contractCode, type, startTime, endTime, fromId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data.financialRecord)
            {
                string tp = marginAccount.ToUpper();
                if (marginAccount.IndexOf("-") != -1)
                {
                    tp = marginAccount.Split("-")[1].ToUpper();
                }
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null, null, 1, 10)]
        [InlineData("BTC-HUSD", null, null, 1, 10)]
        public void AccountIsolatedGetUserSettlementRecordsTest(string contractCode, long? startTime, long? endTime,
                                                                int? pageIndex = null, int? pageSize = null)
        {
            var result = client.IsolatedGetUserSettlementRecordsAsync(contractCode, startTime, endTime, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = contractCode.Split("-")[1].ToUpper();
            foreach(var item in result.data.settlementRecords)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("USDT", null, null, 1, 10)]
        [InlineData("HUSD", null, null, 1, 10)]
        public void AccountCrossGetUserSettlementRecordsTest(string marginAccount, long? startTime, long? endTime,
                                                             int? pageIndex = null, int? pageSize = null)
        {
            var result = client.CrossGetUserSettlementRecordsAsync(marginAccount, startTime, endTime, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = marginAccount.ToUpper();
            foreach(var d in result.data.settlementRecords)
            {
                foreach(var item in d.contractDetail)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "master_to_sub")]
        // [InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "sub_to_master")]
        // [InlineData("HUSD", "ETH-HUSD", "ETH-HUSD", 1, true, "master_to_sub")]
        // [InlineData("HUSD", "ETH-HUSD", "ETH-HUSD", 1, true, "sub_to_master")]
        [InlineData("USDT", "BTC-USDT", "ETH-USDT", 1, false, null)]
        [InlineData("HUSD", "BTC-HUSD", "ETH-HUSD", 1, false, null)]
        public void AccountTransTest(string asset, string fromMarginAccount, string toMarginAccount, double amount,
                                     bool beMasterSub, string type = null)
        {
            var result = client.AccountTransferAsync(asset, fromMarginAccount, toMarginAccount, amount).Result;
            if (beMasterSub)
            {
                result = client.AccountTransferAsync(asset, fromMarginAccount, toMarginAccount, amount, long.Parse(config["SubUid"]), type).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("ETH-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void IsolatedGetValidLeverRateTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetValidLeverRateAsync(contractCode, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("btc-usdt", null, null, null, null)]
        [InlineData(null, "swap", "swap", "BTC-USDT", null)]
        [InlineData("btc-husd", null, null, null, "husd")]
        [InlineData("btc-husd", null, null, null, "all")]
        public void CrossGetValidLeverRateTest(string contractCode, string businessType, 
                                               string contractType, string pair,
                                               string tradePartition)
        {
            var result = client.CrossGetValidLeverRateAsync(contractCode, businessType, contractType, pair, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = null;
            if (pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            if(type != null)
            {
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("limit", "btc-usdt", null, null, null, null)]
        [InlineData("limit", null, "swap", "swap", "btc-usdt", null)]
        [InlineData("limit", "btc-usdt", "swap", "swap", "eth-usdt", null)]
        [InlineData("limit", "btc-husd", null, null, null, "husd")]
        [InlineData("limit", null, "swap", "swap", "btc-husd", "husd")]
        [InlineData("limit", "btc-husd", "swap", "swap", "eth-husd", "all")]
        public void GetOrderLimitTest(string orderPriceType, string contractCode,
                                      string businessType, string contractType,
                                      string pair, string tradePartition)
        {
            var result = client.GetOrderLimitAsync(orderPriceType, contractCode, businessType, contractType, pair, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if (pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.list)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("btc-usdt", null, null, null, null)]
        [InlineData("btc-USDT", "swap", "swap", "ltc-usdt", null)]
        [InlineData("btc-husd", null, null, null, "husd")]
        [InlineData("btc-husd", "swap", "swap", "ltc-usdt", "")]
        public void GetFeeTest(string contractCode, string businessType, string contractType, string pair,
                               string tradePartition)
        {
            var result = client.GetFeeAsync(contractCode, businessType, contractType, pair, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = null;
            if (pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void IsolatedGetTransferLimitTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetTransferLimitAsync(contractCode, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            if(contractCode != null)
            {
                string type = null;
                if (contractCode.IndexOf("-") != -1)
                {
                    type = contractCode.Split("-")[1].ToUpper();
                }
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("USDT", null)]
        [InlineData("HUSD", "husd")]
        [InlineData("husd", "all")]
        public void CrossGetTransferLimitTest(string marginAccount, string tradePartition)
        {
            var result = client.CrossGetTransferLimitAsync(marginAccount, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(marginAccount != null)
            {
                string type = marginAccount.ToUpper();
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void IsolatedGetPositionLimitTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetPositionLimitAsync(contractCode, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("btc-usdt", null, null, null, null)]
        [InlineData(null, "swap", "swap", "btc-usdt", null)]
        [InlineData("btc-husd", null, null, null, "husd")]
        [InlineData("BTC-husd", "swap", "swap", "ltc-usdt", "all")]
        public void CrossGetPositionLimitTest(string contractCode, string businessType,
                                              string contractType, string pair,
                                              string tradePartition)
        {
            var result = client.CrossGetPositionLimitAsync(contractCode, businessType, contractType, pair, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if (pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            if (type != null)
            {
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("btc-usdt", null, null)]
        [InlineData("btc-husd", null, "husd")]
        [InlineData("btc-husd", null, "all")]
        public void IsolatedGetLeverPositionLimitTest(string contractCode, int? leverRate, string tradePartition)
        {
            var result = client.IsolatedGetLeverPositionLimitAsync(contractCode, leverRate, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            if (type != null)
            {
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData("btc-usdt", 5, null, null, null, null)]
        [InlineData(null, null, "swap", "btc-usdt", "swap", null)]
        [InlineData(null, null, "quarter", "btc-usdt", "futures", null)]
        [InlineData("btc-husd", 5, null, null, null, "husd")]
        [InlineData("btc-husd", 5, null, null, null, "all")]
        public void CrossGetLeverPositionLimitTest(string contractCode, int? leverRate,
                                                   string contractType, string pair,
                                                   string businessType, string tradePartition)
        {
            var result = client.CrossGetLeverPositionLimitAsync(contractCode, leverRate, contractType, pair, businessType, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if(pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            if (type != null)
            {
                foreach (var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Fact]
        public void GetApiTradingStatusTest()
        {
            var result = client.GetApiTradingStatusAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}