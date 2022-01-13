using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient();
        
        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("BTC-USDT", null, null, null, null)]
        [InlineData("BTC-USDT", "all", "swap", "btc-usdt", null)]
        [InlineData(null, "futures", "quarter", "btc-usdt", null)]
        [InlineData(null, "futures", "quarter", "btc-husd", "husd")]
        [InlineData(null, "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd-220325", "futures", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "all", "swap", "btc-husd", "all")]
        public void RESTfulMarketContractInfoTest(string contractCode, string businessType, 
                                                  string contractType, string pair,
                                                  string tradePartition)
        {
            var result = client.GetContractInfoAsync(contractCode, businessType, contractType, pair, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = pair.Split("-")[1].ToUpper();
                foreach(var item in result.data)
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
        public void RESTfulMarketIndexTest(string contractCode, string tradePartition)
        {
            var result = client.GetIndexAsync(contractCode, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("btc-usdt", null, null, null, null)]
        [InlineData("btc-usdt", "all", "quarter", "btc-usdt", null)]
        [InlineData(null, "all", "quarter", "btc-usdt", null)]
        [InlineData("btc-husd", "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd-220325", "futures", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "all", "swap", "btc-husd", "all")]
        public void RESTfulMarketPriceLimitTest(string contractCode, string businessType, 
                                                string contractType, string pair,
                                                string tradePartition = null)
        {
            var result = client.GetPriceLimitAsync(contractCode, businessType, contractType, pair, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = pair.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("BTC-USDT", null, null, null, null)]
        [InlineData("btc-usdt", "all", "quarter", "btc-usdt", null)]
        [InlineData(null, "all", "quarter", "btc-usdt", null)]
        [InlineData("btc-husd", "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd-220325", "futures", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "swap", "swap", "btc-husd", "husd")]
        [InlineData("btc-husd", "all", "swap", "btc-husd", "all")]
        public void RESTfulMarketOpenInterestTest(string contractCode, string businessType, 
                                                  string contractType, string pair,
                                                  string tradePartition)
        {
            var result = client.GetOpenInterestAsync(contractCode, businessType, contractType, pair, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = pair.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "step10")]
        [InlineData("BTC-USDT-CQ", "step10")]
        [InlineData("btc-usdt-220325", "step10")]
        [InlineData("btc-husd-220325", "step10")]
        [InlineData("btc-husd", "step10")]
        public void RESTfulMarketDepthTest(string contractCode, string type)
        {
            var result = client.GetDepthAsync(contractCode, type).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("BTC-USDT", null, null)]
        [InlineData(null, "futures", null)]
        [InlineData(null, "all", null)]
        [InlineData("BTC-HUSD", null, "husd")]
        [InlineData("BTC-HUSD", null, "all")]
        public void RESTfulMarketBboTest(string contractCode, string businessType,
                                         string tradePartition)
        {
            var result = client.GetBboAsync(contractCode, businessType, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.ticks)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.ticks)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.ticks)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1, null, null)]
        [InlineData("BTC-USDT", "1min", null, 1604048907, 1604049205)]
        [InlineData("btc-usdt-cq", "1min", 1, null, null)]
        [InlineData("btc-usdt-220325", "1min", 1, null, null)]
        [InlineData("BTC-HUSD", "1min", 1, null, null)]
        [InlineData("btc-husd-220325", "1min", 1, null, null)]
        public void RESTfulMarketHisKLineTest(string contractCode, string period, int? size, int? from, int? to)
        {
            var result = client.GetKLineAsync(contractCode, period, size, from, to).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "15min", 1)]
        [InlineData("BTC-usdt-CQ", "15min", 1)]
        [InlineData("BTC-USDT-220325", "15min", 1)]
        [InlineData("BTC-USDT-220325", "15min", 1)]
        [InlineData("BTC-HUSD", "15min", 1)]
        public void RESTfulMarketMarkKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetMarkPriceKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("BTC-USDT-CQ")]
        [InlineData("btc-usdt-220325")]
        [InlineData("BTC-HUSD")]
        [InlineData("BTC-HUSD-CQ")]
        [InlineData("btc-husd-220325")]
        public void RESTfulMarketMergedTest(string contractCode)
        {
            var result = client.GetMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT-CQ", "all", null)]
        [InlineData("BTC-USDT-220325", "futures", null)]
        [InlineData("BTC-husd", null, "husd")]
        [InlineData("BTC-husd", null, "all")]
        public void RESTfulMarketBatchMergedTest(string contractCode, string businessType,
                                                 string tradePartition)
        {
            var result = client.GetBatchMergedAsync(contractCode, businessType, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.ticks)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.ticks)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.ticks)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("btc-usdt", null, null)]
        [InlineData("btc-usdt-cq", "futures", null)]
        [InlineData("btc-usdt-220325", "futures", null)]
        [InlineData("btc-husd", "swap", "husd")]
        [InlineData("btc-husd", "swap", "all")]
        public void RESTfulMarketTradeTest(string contractCode, string businessType,
                                           string tradePartition)
        {
            var result = client.GetTradeAsync(contractCode, businessType, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.tick.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.tick.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.tick.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", 5)]
        [InlineData("BTC-USDT-CQ", 5)]
        [InlineData("BTC-USDT-220325", 5)]
        [InlineData("BTC-HUSD", 5)]
        [InlineData("BTC-HUSD-CQ", 5)]
        [InlineData("BTC-HUSD-220325", 5)]
        public void RESTfulMarketHisTradeTest(string contractCode, int size)
        {
            var result = client.GetHisTradeAsync(contractCode, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT-FUTURES", "all", null)]
        [InlineData("BTC-HUSD-FUTURES", "futures", "husd")]
        [InlineData("BTC-HUSD-FUTURES", "all", "all")]
        public void RESTfulMarketRiskInfoTest(string contractCode, string businessType,
                                              string tradePartition)
        {
            var result = client.GetRiskInfoAsync(contractCode, businessType, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 10)]
        [InlineData("BTC-HUSD", 1, 10)]
        public void RESTfulMarketInsuranceFundTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetInsuranceFundAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = contractCode.Split("-")[1].ToUpper();
            Assert.Equal(type, result.data.tradePartition);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData(null, "all")]
        [InlineData("BTC-HUSD", "husd")]
        public void RESTfulMarketIsolatedAdjustFactorTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetAdjustFactorFundAsync(contractCode, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all" && contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null, null, null, null)]
        [InlineData("BTC-USDT", "swap", "quarter", "btc-usdt", null)]
        [InlineData(null, "futures", "quarter", "btc-usdt", null)]
        [InlineData(null, "futures", "quarter", "btc-husd", "husd")]
        [InlineData(null, "futures", "quarter", "btc-husd", "all")]
        public void RESTfulMarketCrossAdjustFactorTest(string contractCode, string businessType, 
                                                       string contractType, string pair,
                                                       string tradePartition)
        {

            var result = client.CrossGetAdjustFactorFundAsync(contractCode, businessType, contractType, pair, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = pair.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("60min", 1, null, "btc-usdt", null, null)]
        [InlineData("60min", 1, null, null, "quarter", "btc-usdt")]
        [InlineData("60min", 1, null, null, "quarter", "btc-husd")]
        public void RESTfulMarketHisOpenInterestTest(string period, int amountType, int? size,
                                                     string contractCode, string contractType, string pair)
        {
            var result = client.GetHisOpenInterestAsync(period, amountType, size, contractCode, contractType, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(pair != null)
            {
                string type = pair.Split("-")[1].ToUpper();
                Assert.Equal(type, result.data.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "usdt")]
        public void RESTfulMarketIsolatedGetLadderMarginTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetLadderMarginAsync(contractCode, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all" && contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "usdt")]
        public void RESTfulMarketCrossdGetLadderMarginTest(string contractCode, string tradePartition)
        {
            var result = client.CrossGetLadderMarginAsync(contractCode, tradePartition).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all" && contractCode != null)
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        [InlineData("BTC-HUSD", "60min")]
        [InlineData("BTC-USDT-FUTURES", "60min")]
        [InlineData("BTC-HUSD-FUTURES", "60min")]
        public void RESTfulMarketEliteAccountRatioTest(string contractCode, string period)
        {
            var result = client.GetEliteAccountRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
            {
                Assert.Equal("USDT", result.data.tradePartition);
            }
            else
            {
                Assert.Equal("HUSD", result.data.tradePartition);
            }
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        [InlineData("BTC-HUSD", "60min")]
        [InlineData("BTC-USDT-FUTURES", "60min")]
        [InlineData("BTC-HUSD-FUTURES", "60min")]
        public void RESTfulMarketElitePositionRatioTest(string contractCode, string period)
        {
            var result = client.GetElitePositionRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
            {
                Assert.Equal("USDT", result.data.tradePartition);
            }
            else
            {
                Assert.Equal("HUSD", result.data.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void RESTfulMarketApiStatusTest(string contractCode, string tradePartition)
        {
            var result = client.IsolatedGetApiStatusAsync(contractCode, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data)
            {
                if (tradePartition == null || tradePartition.ToLower() == "usdt")
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
                else if (tradePartition.ToLower() == "husd")
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
                else if (tradePartition.ToLower() == "all")
                {
                    string type = contractCode.Split("-")[1].ToUpper();
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("USDT")]
        [InlineData("husd")]
        public void RESTfulMarketTransferStatusTest(string marginAccount)
        {
            var result = client.CrossGetTransferStateAsync(marginAccount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("BTC-USDT", "all", null, null, null)]
        [InlineData(null, "futures", "quarter", "btc-usdt", null)]
        [InlineData(null, "futures", "quarter", "btc-husd", "husd")]
        [InlineData(null, "futures", "quarter", "btc-husd", "all")]
        public void RESTfulMarketTradeStatusTest(string contractCode, string businessType, 
                                                 string contractType, string pair,
                                                 string tradePartition)
        {
            var result = client.CrossGetTradeStateAsync(contractCode, businessType, contractType, pair, tradePartition).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = pair.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("BTC-HUSD")]
        public void RESTfulMarketFundingRateTest(string contractCode)
        {
            var result = client.GetFundingRateAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
            {
                Assert.Equal("USDT", result.data.tradePartition);
            }
            else
            {
                Assert.Equal("HUSD", result.data.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("BTC-USDT", null)]
        [InlineData("BTC-HUSD", "husd")]
        [InlineData("BTC-HUSD", "all")]
        public void RESTfulMarketBatchFundingRateTest(string contractCode, string tradePartition)
        {
            var result = client.GetBatchFundingRateAsync(contractCode, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            if(tradePartition == null || tradePartition.ToLower() == "usdt")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "husd")
            {
                foreach(var item in result.data)
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }else if(tradePartition.ToLower() == "all")
            {
                string type = contractCode.Split("-")[1].ToUpper();
                foreach(var item in result.data)
                {
                    Assert.Equal(type, item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 2)]
        [InlineData("BTC-HUSD", 1, 2)]
        public void RESTfulMarketHisFundingRateTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisFundingRateAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data.data)
            {
                if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
                else
                {
                    Assert.Equal("HUSD", item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 7, null, null, "BTC-USDT", null)]
        [InlineData(0, 90, 1, 2, null, "btc-usdt")]
        [InlineData(0, 90, 1, 2, null, "btc-husd")]
        [InlineData(0, 90, 1, 2, "btc-husd", null)]
        public void RESTfulMarketLiquidationOrdersTest(int tradeType, int createDate, 
                                                       int? pageIndex, int? pageSize,
                                                       string contractCode, string pair)
        {
            var result = client.GetLiquidationOrdersAsync(tradeType, createDate, pageIndex, pageSize, contractCode, pair).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data.orders)
            {
                if (contractCode != null)
                {
                    if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
                    {
                        Assert.Equal("USDT", item.tradePartition);
                    }
                    else
                    {
                        Assert.Equal("HUSD", item.tradePartition);
                    }
                }
                else if (pair != null)
                {
                    if (pair.IndexOf("usdt") != -1 || pair.IndexOf("USDT") != -1)
                    {
                        Assert.Equal("USDT", item.tradePartition);
                    }
                    else
                    {
                        Assert.Equal("HUSD", item.tradePartition);
                    }
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", 1639300007924, 1639378937924, null, null)]
        [InlineData("BTC-HUSD", 1639300007924, 1639378937924, null, null)]
        [InlineData("BTC-USDT", 1639300007924, 1639378937924, 1, 2)]
        [InlineData("BTC-USDT-220325", 1639300007924, 1639378937924, 1, 2)]
        [InlineData("BTC-HUSD-220325", 1639300007924, 1639378937924, 1, 2)]
        public void RESTfulMarketSettlementRecordsTest(string contractCode, long? startTime, long? endTime, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetSettlementRecordsAsync(contractCode, startTime, endTime, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data.settlementRecord)
            {
                if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
                else
                {
                    Assert.Equal("USDT", item.tradePartition);
                }
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5)]
        [InlineData("BTC-HUSD", "5min", 5)]
        public void RESTfulMarketPremiumIndexKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetPremiumIndexKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5)]
        [InlineData("BTC-HUSD", "5min", 5)]
        public void RESTfulMarketEstimatedRateKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetEstimatedRateKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5, null)]
        [InlineData("BTC-USDT", "5min", 5, "open")]
        [InlineData("BTC-USDT-CQ", "5min", 5, "open")]
        [InlineData("btc-usdt-220325", "5min", 5, "open")]
        [InlineData("btc-husd", "5min", 5, null)]
        public void RESTfulMarketBasisTest(string contractCode, string period, int size, string basisPriceType)
        {
            var result = client.GetBasisAsync(contractCode, period, size, basisPriceType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("BTC-USDT", "all", null, null, null)]
        [InlineData(null, "futures", "quarter", "btc-usdt", null)]
        [InlineData(null, "futures", "quarter", "btc-husd", "husd")]
        [InlineData(null, "futures", "quarter", "btc-husd", "all")]
        [InlineData("BTC-HUSD", "all", null, null, "all")]
        public void RESTfulMarketEstimatedSettlementPriceTest(string contractCode, string businessType, 
                                                              string contractType, string pair,
                                                              string tradePartition)
        {
            var result = client.GetEstimatedSettlementPriceAsync(contractCode, businessType, contractType, pair, tradePartition).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            foreach (var item in result.data)
            {
                if (contractCode != null)
                {
                    if (contractCode.IndexOf("usdt") != -1 || contractCode.IndexOf("USDT") != -1)
                    {
                        Assert.Equal("USDT", item.tradePartition);
                    }
                    else
                    {
                        Assert.Equal("HUSD", item.tradePartition);
                    }
                }
                else if (pair != null)
                {
                    if (pair.IndexOf("usdt") != -1 || pair.IndexOf("USDT") != -1)
                    {
                        Assert.Equal("USDT", item.tradePartition);
                    }
                    else
                    {
                        Assert.Equal("HUSD", item.tradePartition);
                    }
                }
            }
            Console.WriteLine("------------");
        }

    }
}