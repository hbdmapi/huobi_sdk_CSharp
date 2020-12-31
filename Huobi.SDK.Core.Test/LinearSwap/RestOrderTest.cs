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
        [InlineData("XRP-USDT", null, 0.15, 1, "buy", "open", 5, "limit")]
        public void PlaceOrderTest(string contractCode, long? clientOrderId, double price, long volume,
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
            var result = client.IsolatedPlaceOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossPlaceOrderAsync(request).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void PlaceBatchOrderTest()
        {
            Order.PlaceOrderRequest[] request = {
                new Order.PlaceOrderRequest
                {
                    contractCode = "XRP-USDT",
                    clientOrderId = null,
                    price = 0.15,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                },
                new Order.PlaceOrderRequest
                {
                    contractCode = "XRP-USDT",
                    clientOrderId = null,
                    price = 0.18,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                }
            };
            var result = client.IsolatedPlaceBatchOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossPlaceBatchOrderAsync(request).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("BTC-USDT", null, null)]
        [InlineData("XRP-USDT", "794156585717932034,794156588096479233", null)]
        [InlineData("XRP-USDT", null, null)]
        public void CancelOrderTest(string contractCode, string orderId, string clientOrderId)
        {
            var result = client.IsolatedCancelOrderAsync( contractCode,  orderId,  clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossCancelOrderAsync( contractCode,  orderId,  clientOrderId).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 5)]
        public void SwitchLeverRateTest(string contractCode, int leverRate)
        {
            var result = client.IsolatedSwitchLeverRateAsync( contractCode,  leverRate).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            System.Threading.Thread.Sleep(3000);
            Assert.Equal("ok", result.status);

            result = client.CrossSwitchLeverRateAsync( contractCode,  leverRate).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            System.Threading.Thread.Sleep(3000);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", "794156585717932034,794156588096479233,", null)]
        public void GetOrderInfoTest(string contractCode, string orderId, string clientOrderId)
        {
            var result = client.IsolatedGetOrderInfoAsync( contractCode,  orderId,  clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOrderInfoAsync( contractCode,  orderId,  clientOrderId).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 794156585717932034, 1609383284749, 1, 1, 10)]
        [InlineData("XRP-USDT", 794156588096479233, 1609383285316, 1, 1, 10)]
        public void GetOrderDetailTest(string contractCode, long orderId, long? createdAt, 
                                              int? orderType, int? pageIndex, int? pageSize)
        {
            var result = client.IsolatedGetOrderDetailAsync( contractCode,  orderId,  createdAt, orderType, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOrderDetailAsync( contractCode,  orderId,  createdAt, orderType, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 1, 10)]
        public void GetOpenOrderTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.IsolatedGetOpenOrderAsync( contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOpenOrderAsync( contractCode, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 0, 1, "0", 5, null, null)]
        [InlineData("XRP-USDT", 0, 1, "0", 5, 1, 20)]
        public void GetHisOrderTest(string contractCode, int tradeType, int type, string status,
                                           int createdDate, int? pageIndex, int? pageSize)
        {
            var result = client.IsolatedGetHisOrderAsync(contractCode, tradeType, type, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisOrderAsync(contractCode, tradeType, type, status, createdDate, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 0, 1, null, null)]
        [InlineData("XRP-USDT", 0, 1, 1, 20)]
        public void GetHisMatchTest(string contractCode, int tradeType, int createdDate, int? pageIndex, int? pageSize)
        {
            var result = client.IsolatedGetHisMatchAsync(contractCode, tradeType, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisMatchAsync(contractCode, tradeType, createdDate, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 1, "buy", null, null)]
        [InlineData("XRP-USDT", 1, "buy", null, "lightning")]
        public void LightningCloseTest(string contractCode, double volume, string direction, 
                                              long? clientOrderId = null, string orderPriceType = null)
        {
            var result = client.IsolatedLightningCloseAsync(contractCode, volume, direction, clientOrderId, orderPriceType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            
            result = client.CrossLightningCloseAsync(contractCode, volume, direction, clientOrderId, orderPriceType).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}