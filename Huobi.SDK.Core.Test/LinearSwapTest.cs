using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using Order = Huobi.SDK.Core.LinearSwap.RESTful.Request.Order;
using TriggerOrder = Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.Market;
using Huobi.SDK.Core.LinearSwap.WS.Response.Index;
using Huobi.SDK.Core.LinearSwap.WS.Response.Notify;
using System.Threading;

namespace Huobi.SDK.Core.Test
{
    #region test account
    public class LinearSwapAccountTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static AccountClient client = new AccountClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData(null, false)]
        [InlineData("BTC-USDT", false)]
        [InlineData(null, true)]
        [InlineData("BTC-USDT", true)]
        public void RESTfulAccountAssetsTest(string contractCode, bool beSubUid)
        {
            var result = client.GetAccountAssetsAsync(contractCode).Result;
            if (beSubUid)
            {
                result = client.GetAccountAssetsAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("BTC-USDT", false)]
        [InlineData(null, true)]
        [InlineData("BTC-USDT", true)]
        public void RESTfulAccountPositionTest(string contractCode, bool beSubUid)
        {
            var result = client.GetAccountPositionAsync(contractCode).Result;
            if (beSubUid)
            {
                result = client.GetAccountPositionAsync(contractCode, long.Parse(config["SubUid"])).Result;
            }
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", false, null, null, null)]
        [InlineData("BTC-USDT", false, 10, 1, 30)]
        [InlineData("BTC-USDT", true, null, null, null)]
        [InlineData("BTC-USDT", true, 10, 1, 30)]
        public void RESTfulAccountTransHisTest(string marginAccount, bool beMasterSub = false, int? createDate = null,
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
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulAllSubAssetsTest(string contractCode)
        {
            var result = client.GetAllSubAssetsAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("USDT", "BTC-USDT", "ETH-USDT", 1, false, null)]
        //[InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "master_to_sub")]
        [InlineData("USDT", "ETH-USDT", "ETH-USDT", 1, true, "sub_to_master")]
        public void RESTfulAccountTransTest(string asset, string fromMarginAccount, string toMarginAccount, double amount,
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
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulValidLeverRateTest(string contractCode)
        {
            var result = client.GetValidLeverRateAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("limit", null)]
        [InlineData("limit", "ETH-USDT")]
        public void RESTfulGetOrderLimitTest(string orderPriceType, string contractCode)
        {
            var result = client.GetOrderLimitAsync(orderPriceType, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulGetFeeTest(string contractCode)
        {
            var result = client.GetFeeAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulGetTransferLimitTest(string contractCode)
        {
            var result = client.GetTransferLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("ETH-USDT")]
        public void RESTfulGetPositionLimitTest(string contractCode)
        {
            var result = client.GetPositionLimitAsync(contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void RESTfulGetApiTradingStatusTest()
        {
            var result = client.GetApiTradingStatusAsync().Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
    #endregion

    #region test order
    public class LinearSwapOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static OrderClient client = new OrderClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData("BTC-USDT", null, 13000, 1, "buy", "open", 5, "limit")]
        [InlineData("BTC-USDT", null, 14000, 1, "sell", "open", 5, "limit")]
        public void RESTfulPlaceOrderTest(string contractCode, long? clientOrderId, double price, long volume,
                                          string direction, string offset, int leverRate, string orderPriceType)
        {
            Order.PlaceOrderRequest request = new Order.PlaceOrderRequest
            {
                contractCode = contractCode,
                clientOrderId = clientOrderId,
                price = price,
                volume = volume,
                direction = direction,
                offset = offset,
                leverRate = leverRate,
                orderPriceType = orderPriceType
            };
            var result = client.PlaceOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void RESTfulPlaceBatchOrderTest()
        {
            Order.PlaceOrderRequest[] request = {
                new Order.PlaceOrderRequest
                {
                    contractCode = "BTC-USDT",
                    clientOrderId = null,
                    price = 13000,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                },
                new Order.PlaceOrderRequest
                {
                    contractCode = "BTC-USDT",
                    clientOrderId = 14000,
                    price = 14000,
                    volume = 1,
                    direction = "sell",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                }
            };
            var result = client.PlaceBatchOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", "771317012235644928", "14000")]
        [InlineData("BTC-USDT", null, "14000")]
        public void RESTfulCancelOrderTest(string contractCode, string orderId, string clientOrderId)
        {
            var result = client.CancelOrderAsync( contractCode,  orderId,  clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 10)]
        [InlineData("ETH-USDT", 20)]
        public void RESTfulSwitchLeverRateTest(string contractCode, int leverRate)
        {
            var result = client.SwitchLeverRateAsync( contractCode,  leverRate).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            System.Threading.Thread.Sleep(3000);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "771317012235644928", null)]
        [InlineData("BTC-USDT", null, "14000")]
        public void RESTfulGetOrderInfoTest(string contractCode, string orderId, string clientOrderId)
        {
            var result = client.GetOrderInfoAsync( contractCode,  orderId,  clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 771317012235644928, null, null, null, null)]
        [InlineData("BTC-USDT", 771317012235644928, 1603937970378, 1, 1, 10)]
        public void RESTfulGetOrderDetailTest(string contractCode, long orderId, long? createdAt, 
                                              int? orderType, int? pageIndex, int? pageSize)
        {
            var result = client.GetOrderDetailAsync( contractCode,  orderId,  createdAt, orderType, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 10)]
        public void RESTfulGetOpenOrderTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetOpenOrderAsync( contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 0, 1, "0", 5, null, null)]
        [InlineData("BTC-USDT", 0, 1, "0", 5, 1, 20)]
        public void RESTfulGetHisOrderTest(string contractCode, int tradeType, int type, string status,
                                           int createdDate, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisOrderAsync(contractCode, tradeType, type, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 0, 1, null, null)]
        [InlineData("BTC-USDT", 0, 1, 1, 20)]
        public void RESTfulGetHisMatchTest(string contractCode, int tradeType, int createdDate, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisMatchAsync(contractCode, tradeType, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("ETH-USDT", 1, "sell", null, null)]
        [InlineData("ETH-USDT", 1, "sell", null, "lightning")]
        public void RESTfulLightningCloseTest(string contractCode, double volume, string direction, 
                                              long? clientOrderId = null, string orderPriceType = null)
        {
            var result = client.LightningCloseAsync(contractCode, volume, direction, clientOrderId, orderPriceType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
    #endregion

    #region test trigger order
    public class LinearSwapTriggerOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TriggerOrderClient client = new TriggerOrderClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData("ETH-USDT", "le", 350, "buy", "open", 1, 350, null, 20)]
        [InlineData("ETH-USDT", "le", 350, "buy", "open", 1, 350, "limit", 20)]
        public void RESTfulPlaceOrderTest(string contractCode, string triggerType, double triggerPrice, string direction, string offset, long volume,
                                          double orderPrice, string orderPriceType, int? leverRate)
        {
            TriggerOrder.PlaceOrderRequest request = new TriggerOrder.PlaceOrderRequest
            {
                contractCode = contractCode,
                triggerType = triggerType,
                triggerPrice = triggerPrice,
                volume = volume,
                direction = direction,
                offset = offset,
                orderPrice = orderPrice,
                orderPriceType = orderPriceType,
                leverRate = leverRate
            };
            var result = client.PlaceOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("ETH-USDT", null)]
        [InlineData("ETH-USDT", "2")]
        public void RESTfulCancelOrderTest(string contractCode, string orderId)
        {
            var result = client.CancelOrderAsync( contractCode,  orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("ETH-USDT", null, null)]
        [InlineData("ETH-USDT", 1, 10)]
        public void RESTfulGetOpenOrderTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetOpenOrderAsync( contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("ETH-USDT", 0, "0", 1, null, null)]
        [InlineData("ETH-USDT", 0, "0", 1, 1, 20)]
        public void RESTfulGetHisOrderTest(string contractCode, int tradeType, string status, int createdDate,
                                           int? pageIndex, int? pageSize)
        {
            var result = client.GetHisOrderAsync(contractCode, tradeType, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
    #endregion

    #region test transfer
    public class LinearSwapTransferTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TransferClient client = new TransferClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        //[InlineData("linear-swap", "spot", 1, "BTC-USDT")]
        [InlineData("spot", "linear-swap", 1, "BTC-USDT")]
        public void RESTfulTransferTest(string from, string to, double amount, string marginAccount)
        {
            var result = client.TransferAsync(from, to, amount, marginAccount).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.True(result.success);
        }
    }
    #endregion

    #region test market
    public class LinearSwapMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static MarketClient client = new MarketClient(config["Host"]);
        
        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketContractInfoTest(string contractCode)
        {
            var result = client.GetContractInfoAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketIndexTest(string contractCode)
        {
            var result = client.GetIndexAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketPriceLimitTest(string contractCode)
        {
            var result = client.GetPriceLimitAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketOpenInterestTest(string contractCode)
        {
            var result = client.GetOpenInterestAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "step10")]
        public void RESTfulMarketDepthTest(string contractCode, string type)
        {
            var result = client.GetDepthAsync(contractCode, type).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1, null, null)]
        [InlineData("BTC-USDT", "1min", null, 1604048907, 1604049205)]
        public void RESTfulMarketHisKLineTest(string contractCode, string period, int? size, int? from, int? to)
        {
            var result = client.GetKLineAsync(contractCode, period, size, from, to).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketMergedTest(string contractCode)
        {
            var result = client.GetGetMergedAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketTradeTest(string contractCode)
        {
            var result = client.GetTradeAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 5)]
        public void RESTfulMarketHisTradeTest(string contractCode, int size)
        {
            var result = client.GetHisTradeAsync(contractCode, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketRiskInfoTest(string contractCode)
        {
            var result = client.GetRiskInfoAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 10)]
        public void RESTfulMarketInsuranceFundTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetInsuranceFundAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketAdjustFactorTest(string contractCode)
        {
            var result = client.GetAdjustFactorFundAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min", 1, null)]
        [InlineData("BTC-USDT", "60min", 1, 5)]
        public void RESTfulMarketHisOpenInterestTest(string contractCode, string period, int amountType, int? size)
        {
            var result = client.GetHisOpenInterestAsync(contractCode, period, amountType, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        public void RESTfulMarketEliteAccountRatioTest(string contractCode, string period)
        {
            var result = client.GetEliteAccountRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "60min")]
        public void RESTfulMarketElitePositionRatioTest(string contractCode, string period)
        {
            var result = client.GetElitePositionRatioAsync(contractCode, period).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketApiStatusTest(string contractCode)
        {
            var result = client.GetApiStatusAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void RESTfulMarketFundingRateTest(string contractCode)
        {
            var result = client.GetFundingRateAsync(contractCode).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USDT", null, null)]
        [InlineData("BTC-USDT", 1, 2)]
        public void RESTfulMarketHisFundingRateTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisFundingRateAsync(contractCode, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 0, 7, null, null)]
        [InlineData("BTC-USDT", 0, 90, 1, 2)]
        public void RESTfulMarketLiquidationOrdersTest(string contractCode, int tradeType, int createDate, 
                                                       int? pageIndex, int? pageSize)
        {
            var result = client.GetLiquidationOrdersAsync(contractCode, tradeType, createDate, pageIndex, pageSize).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5)]
        public void RESTfulMarketPremiumIndexKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetPremiumIndexKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5)]
        public void RESTfulMarketEstimatedRateKLineTest(string contractCode, string period, int size)
        {
            var result = client.GetEstimatedRateKLineAsync(contractCode, period, size).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", "5min", 5, null)]
        [InlineData("BTC-USDT", "5min", 5, "open")]
        public void RESTfulMarketBasisTest(string contractCode, string period, int size, string basisPriceType)
        {
            var result = client.GetBasisAsync(contractCode, period, size, basisPriceType).Result;

            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
    #endregion

    #region test wss market
    public class LinearSwapWssMarketTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSMarketClient client = new WSMarketClient();

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubKLineTest(string contractCode, string period)
        {
            client.SubKLine(contractCode, period, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
            client.UnsubKLine(contractCode, period);
            System.Threading.Thread.Sleep(1000 * 5);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqKLine(contractCode, period, delegate (ReqKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
            client.UnreqKLine(contractCode, period, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "step0")]
        [InlineData("*", "step0")]
        public void WSSubDepthTest(string contractCode, string type)
        {
            client.SubDepth(contractCode, type, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
            client.UnSubDepth(contractCode, type);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT", "20")]
        [InlineData("*", "20")]
        public void WSIncrementalDepthTest(string contractCode, string size)
        {
            client.SubIncrementalDepth(contractCode, size, delegate (SubDepthResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
            client.UnSubIncrementaDepth(contractCode, size);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSDetailTest(string contractCode)
        {
            client.SubDetail(contractCode, delegate (SubKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 80);
            client.UnsubDetail(contractCode);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSBBOTest(string contractCode)
        {
            client.SubBBO(contractCode, delegate (SubBBOResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 10);
            client.UnsubBBO(contractCode);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSSubTradeDetailTest(string contractCode)
        {
            client.SubTradeDetail(contractCode, delegate (SubTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
            client.UnsubTradeDetail(contractCode);
            System.Threading.Thread.Sleep(1000 * 10);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        [InlineData("*")]
        public void WSReqTradeDetailTest(string contractCode)
        {
            client.ReqTradeDetail(contractCode, delegate (ReqTradeDetailResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
            client.UnreqTradeDetail(contractCode);
            System.Threading.Thread.Sleep(1000 * 10);
        }
    }
    #endregion

    #region test wss index
    public class LinearSwapWssIndexTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static WSIndexClient client = new WSIndexClient();

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubPreiumIndexKLineTest(string contractCode, string period)
        {
            client.SubPremiumIndexKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
            client.UnsubPremiumIndexKLine(contractCode, period);
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqPremiumIndexKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqPremiumIndexKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
            client.UnreqPremiumIndexKLine(contractCode, period, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubEstimatedRateKLineTest(string contractCode, string period)
        {
            client.SubEstimatedRateKLine(contractCode, period, delegate (SubIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
            client.UnsubEstimatedRateKLine(contractCode, period);
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqEstimatedRateKLineTest(string contractCode, string period, long from, long to)
        {
            client.ReqEstimatedRateKLine(contractCode, period, delegate (ReqIndexKLineResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
            client.UnreqEstimatedRateKLine(contractCode, period, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min")]
        [InlineData("*", "1min")]
        public void WSSubBasisTest(string contractCode, string period)
        {
            client.SubBasis(contractCode, period, delegate (SubBasiesResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 50);
            client.UnsubBasis(contractCode, period);
            System.Threading.Thread.Sleep(1000 * 50);
        }

        [Theory]
        [InlineData("BTC-USDT", "1min", 1604395758, 1604396758)]
        [InlineData("*", "1min", 1604395758, 1604396758)]
        public void WSReqBasisTest(string contractCode, string period, long from, long to)
        {
            client.ReqBasis(contractCode, period, delegate (ReqBasisResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
            client.UnreqBasis(contractCode, period, from, to);
            System.Threading.Thread.Sleep(1000 * 80);
        }
    }
    #endregion

    #region test wss notify
    public class LinearSwapWssNotifyTest
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
    #endregion
}
