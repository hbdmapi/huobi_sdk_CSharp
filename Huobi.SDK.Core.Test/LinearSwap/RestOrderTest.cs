using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using Order = Huobi.SDK.Core.LinearSwap.RESTful.Request.Order;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test
{
    public class RestOrderTest
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
}