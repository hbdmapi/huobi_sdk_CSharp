using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using Order = Huobi.SDK.Core.LinearSwap.RESTful.Request.Order;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.LinearSwap
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
        //[InlineData("XRP-USDT", "794156585717932034,794156588096479233", null, null, null)]
        [InlineData("XRP-USDT", null, null, "open", "sell")]
        public void CancelOrderTest(string contractCode, string orderId, string clientOrderId, string offset, string direction)
        {
            var result = client.IsolatedCancelOrderAsync( contractCode,  orderId,  clientOrderId, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossCancelOrderAsync( contractCode,  orderId,  clientOrderId, offset, direction).Result;
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
        [InlineData("XRP-USDT", "806899392753246208,806899440509616128", null)]
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
        [InlineData("XRP-USDT", 806899392753246208, null, 1, 1, 10)]
        [InlineData("XRP-USDT", 806899440509616128, null, 1, 1, 10)]
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
        [InlineData("XRP-USDT", 1, 10, "created_at", 0)]
        public void GetOpenOrderTest(string contractCode, int pageIndex, int pageSize, string sortBy, int tradeType)
        {
            var result = client.IsolatedGetOpenOrderAsync( contractCode, pageIndex, pageSize, sortBy, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOpenOrderAsync( contractCode, pageIndex, pageSize, sortBy, tradeType).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 0, 1, "0", 10, null, null)]
        [InlineData("XRP-USDT", 0, 1, "0", 10, 1, 20)]
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
        [InlineData("XRP-USDT", 0, 1, "0", "limit", null, null, null)]
        public void GetHisOrderExactTest(string contractCode, int tradeType, int type, string status,
                                        string order_price_type, long? start_time, long? end_time,
                                        long? from_id)
        {
            var result = client.IsolatedGetHisOrderExactAsync(contractCode, tradeType, type, status, order_price_type, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisOrderExactAsync(contractCode, tradeType, type, status, order_price_type, start_time, end_time, from_id).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XTZ-USDT", 0, 1, null, null)]
        [InlineData("XTZ-USDT", 0, 1, 1, 20)]
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
        [InlineData("XRP-USDT", 0, null, null, null)]
        public void GetHisMatchExactTest(string contractCode, int tradeType, long? start_time, long? end_time,
                                        long? from_id)
        {
            var result = client.IsolatedGetHisMatchExactAsync(contractCode, tradeType, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisMatchExactAsync(contractCode, tradeType, start_time, end_time, from_id).Result;
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