using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.CoinSwap.RESTful;
using Order = Huobi.SDK.Core.CoinSwap.RESTful.Request.Order;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class RestOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static OrderClient client = new OrderClient(config["AccessKey"], config["SecretKey"], Host.FUTURES);

        [Theory]
        [InlineData("TRX-USD", null, 0.05, 1, "buy", "open", 10, "limit")]
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
                    contractCode = "TRX-USD",
                    clientOrderId = null,
                    price = 0.05,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 10,
                    orderPriceType = "limit"
                },
                new Order.PlaceOrderRequest
                {
                    contractCode = "TRX-USD",
                    clientOrderId = null,
                    price = 0.04,
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
        //[InlineData("BTC-USDT", null, null)]
        //[InlineData("XRP-USDT", "794156585717932034,794156588096479233", null, null, null)]
        [InlineData("TRX-USD", null, null, "open", "buy")]
        public void CancelOrderTest(string contractCode, string orderId, string clientOrderId, string offset, string direction)
        {
            var result = client.CancelOrderAsync( contractCode,  orderId,  clientOrderId, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 20)]
        public void SwitchLeverRateTest(string contractCode, int leverRate)
        {
            var result = client.SwitchLeverRateAsync( contractCode,  leverRate).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            System.Threading.Thread.Sleep(3000);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", "817083041561825280,817083041570213888", null)]
        public void GetOrderInfoTest(string contractCode, string orderId, string clientOrderId)
        {
            var result = client.GetOrderInfoAsync( contractCode,  orderId,  clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 816984350964285440, null, 1, 1, 10)]
        public void GetOrderDetailTest(string contractCode, long orderId, long? createdAt, 
                                       int? orderType, int? pageIndex, int? pageSize)
        {
            var result = client.GetOrderDetailAsync( contractCode,  orderId,  createdAt, orderType, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 1, 10, "created_at", 0)]
        public void GetOpenOrderTest(string contractCode, int pageIndex, int pageSize, string sortBy, int tradeType)
        {
            var result = client.GetOpenOrderAsync( contractCode, pageIndex, pageSize, sortBy, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 0, 1, "3", 10, null, null)]
        [InlineData("TRX-USD", 0, 1, "0", 10, 1, 20)]
        public void GetHisOrderTest(string contractCode, int tradeType, int type, string status,
                                           int createdDate, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisOrderAsync(contractCode, tradeType, type, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 0, 1, "0", "limit", null, null, null)]
        public void GetHisOrderExactTest(string contractCode, int tradeType, int type, string status,
                                        string order_price_type, long? start_time, long? end_time,
                                        long? from_id)
        {
            var result = client.GetHisOrderExactAsync(contractCode, tradeType, type, status, order_price_type, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 0, 1, null, null)]
        [InlineData("TRX-USD", 0, 1, 1, 20)]
        public void GetHisMatchTest(string contractCode, int tradeType, int createdDate, int? pageIndex, int? pageSize)
        {
            var result = client.GetHisMatchAsync(contractCode, tradeType, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 0, null, null, null)]
        public void GetHisMatchExactTest(string contractCode, int tradeType, long? start_time, long? end_time,
                                        long? from_id)
        {
            var result = client.GetHisMatchExactAsync(contractCode, tradeType, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 1, "buy", null, null)]
        [InlineData("TRX-USD", 1, "buy", null, "lightning")]
        public void LightningCloseTest(string contractCode, double volume, string direction, 
                                              long? clientOrderId = null, string orderPriceType = null)
        {
            var result = client.LightningCloseAsync(contractCode, volume, direction, clientOrderId, orderPriceType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}