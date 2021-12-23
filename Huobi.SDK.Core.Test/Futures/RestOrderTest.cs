using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Futures.RESTful;
using Order = Huobi.SDK.Core.Futures.RESTful.Request.Order;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.Futures
{
    public class RestOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static OrderClient client = new OrderClient(config["AccessKey"], config["SecretKey"], Host.FUTURES);

        [Theory]
        [InlineData("bch210319", null, 500, 1, "buy", "open", 10, "limit")]
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
            var result = client.PlaceOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Fact]
        public void PlaceBatchOrderTest()
        {
            Order.PlaceOrderRequest[] request = {
                new Order.PlaceOrderRequest
                {
                    contractCode = "bch210319",
                    clientOrderId = null,
                    price = 501,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 10,
                    orderPriceType = "limit"
                },
                new Order.PlaceOrderRequest
                {
                    contractCode = "bch210319",
                    clientOrderId = null,
                    price = 502,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 10,
                    orderPriceType = "limit"
                }
            };
            var result = client.PlaceBatchOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", null, null, null, null, null, null)]
        [InlineData("bch", "819988842634530817,819988842647113728", null, null, null, null, null)]
        public void CancelOrderTest(string symbol, string orderId, string clientOrderId,
                                    string contractCode, string contractType,
                                    string offset, string direction)
        {
            var result = client.CancelOrderAsync(symbol, orderId, clientOrderId,
                                                 contractCode, contractType, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 5)]
        public void SwitchLeverRateTest(string symbol, int leverRate)
        {
            var result = client.SwitchLeverRateAsync( symbol,  leverRate).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            System.Threading.Thread.Sleep(3000);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", "819988842634530817,819988842647113728", null)]
        public void GetOrderInfoTest(string symbol, string orderId, string clientOrderId)
        {
            var result = client.GetOrderInfoAsync(symbol,  orderId,  clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 819988842634530817, null, 1, 1, 10)]
        public void GetOrderDetailTest(string symbol, long orderId, long? createdAt, 
                                       int? orderType, int? pageIndex, int? pageSize)
        {
            var result = client.GetOrderDetailAsync( symbol,  orderId,  createdAt, orderType, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 1, 10, "created_at", 0)]
        public void GetOpenOrderTest(string symbol, int pageIndex, int pageSize, string sortBy, int tradeType)
        {
            var result = client.GetOpenOrderAsync(symbol, pageIndex, pageSize, sortBy, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", 0, 1, "0", 10, null, null, null, null, null)]
        [InlineData("bch", 0, 1, "0", 90, 1, 20, null, "1", "create_date")]
        public void GetHisOrderTest(string symbol, int tradeType, int type, string status,
                                    int createdDate, int? pageIndex, int? pageSize,
                                    string contractCode, string orderType, string sortBy)
        {
            var result = client.GetHisOrderAsync(symbol, tradeType, type, status, createdDate, pageIndex, pageSize, contractCode, orderType, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 0, 1, "0", null, null, null, null, null, null, null)]
        public void GetHisOrderExactTest(string symbol, int tradeType, int type, string status, string contractCode,
                                         string order_price_type, long? start_time, long? end_time,
                                         long? from_id, int? size, string direct)
        {
            var result = client.GetHisOrderExactAsync(symbol, tradeType, type, status, contractCode, order_price_type, start_time, end_time,
                                                      from_id, size, direct).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 0, 90, null, null, null)]
        public void GetHisMatchTest(string symbol, int tradeType, int createdDate, string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisMatchAsync(symbol, tradeType, createdDate, contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 0, null, null, null, null, null, null)]
        public void GetHisMatchExactTest(string symbol, int tradeType, string contractCode,
                                        long? start_time, long? end_time, long? from_id,
                                        int? size, string direct)
        {
            var result = client.GetHisMatchExactAsync(symbol, tradeType, contractCode,
                                                      start_time, end_time, from_id,
                                                      size, direct).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 1, "buy", "next_quarter", null, null, "lightning")]
        public void LightningCloseTest(string symbol, double volume, string direction, string contractType,
                                       string contractCode, long? clientOrderId, string orderPriceType)
        {
            var result = client.LightningCloseAsync(symbol, volume, direction, contractType, contractCode, clientOrderId, orderPriceType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}