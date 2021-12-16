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
        [InlineData("shib-usdt", null, 0.00004, 1, "sell", "open", 5, "limit", null, null)]
        [InlineData("SHIB-USDT", null,  0.00003, 1, "buy", "open", 5, "limit", "swap", "btc-usdt")]
        public void PlaceOrderTest(string contractCode, long? clientOrderId, double price, long volume,
                                   string direction, string offset, int leverRate, string orderPriceType,
                                   string contractType, string pair)
        {
            Order.PlaceOrderRequest request1 = new Order.PlaceOrderRequest
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
            var result = client.IsolatedPlaceOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Order.PlaceOrderRequest request2 = new Order.PlaceOrderRequest
            {
                contractCode = contractCode,
                clientOrderId = clientOrderId,
                price = price,
                volume = volume,
                direction = direction,
                offset = offset,
                leverRate = leverRate,
                orderPriceType = orderPriceType,
                contractType = contractType,
                pair = pair
            };
            result = client.CrossPlaceOrderAsync(request2).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Fact]
        public void PlaceBatchOrderTest()
        {
            Order.PlaceOrderRequest[] request1 = {
                new Order.PlaceOrderRequest
                {
                    contractCode = "SHIB-USDT",
                    clientOrderId = null,
                    price = 0.00003,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                },
                new Order.PlaceOrderRequest
                {
                    contractCode = "SHIB-USDT",
                    clientOrderId = null,
                    price = 0.00004,
                    volume = 1,
                    direction = "sell",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                }
            };
            var result = client.IsolatedPlaceBatchOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Order.PlaceOrderRequest[] request2 = {
                new Order.PlaceOrderRequest
                {
                    contractCode = "SHIB-USDT",
                    clientOrderId = null,
                    price = 0.00003,
                    volume = 1,
                    direction = "buy",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit",
                    contractType = "swap",
                    pair = "btc-usdt"
                },
                new Order.PlaceOrderRequest
                {
                    contractCode = "SHIB-USDT",
                    clientOrderId = null,
                    price = 0.00004,
                    volume = 1,
                    direction = "sell",
                    offset = "open",
                    leverRate = 5,
                    orderPriceType = "limit"
                }
            };
            result = client.CrossPlaceBatchOrderAsync(request2).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        //[InlineData("BTC-USDT", null, null)]
        //[InlineData("XRP-USDT", "794156585717932034,794156588096479233", null, null, null)]
        [InlineData(null, null, "open", "sell", "SHIB-USDT", "swap", "btc-usdt")]
        public void CancelOrderTest(string orderId, string clientOrderId, string offset, string direction, string contractCode, 
                                    string contractType, string pair)
        {
            var result = client.IsolatedCancelOrderAsync(orderId, clientOrderId, offset, direction, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossCancelOrderAsync(orderId, clientOrderId, offset, direction, contractCode, contractType, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(5, "btc-usdt", null, null)]
        [InlineData(5, "eth-usdt", "swap", "ltc-usdt")]
        public void SwitchLeverRateTest(int leverRate, string contractCode, string contractType, string pair)
        {
            var result = client.IsolatedSwitchLeverRateAsync(leverRate, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossSwitchLeverRateAsync(leverRate, contractCode, contractType, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
            System.Threading.Thread.Sleep(3000);
        }

        [Theory]
        [InlineData("920738019181694976,920738020959797248,920738017021788160,920738014685487104", null, "SHIB-USDT", "btc-usdt")]
        public void GetOrderInfoTest(string orderId, string clientOrderId, string contractCode, string pair)
        {
            var result = client.IsolatedGetOrderInfoAsync(contractCode, orderId, clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOrderInfoAsync(orderId, clientOrderId, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(920738019181694976, null, 1, 1, 10, "SHIB-USDT", "btc-usdt")]
        [InlineData(920738020959797248, null, 1, 1, 10, "SHIB-USDT", "btc-usdt")]
        public void GetOrderDetailTest(long orderId, long? createdAt,
                                       int? orderType, int? pageIndex, int? pageSize,
                                       string contractCode, string pair)
        {
            var result = client.IsolatedGetOrderDetailAsync(contractCode, orderId, createdAt, orderType, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOrderDetailAsync(orderId,  createdAt, orderType, pageIndex, pageSize, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 10, "created_at", 0, "SHIB-USDT", "btc-usdt")]
        public void GetOpenOrderTest(int pageIndex, int pageSize, string sortBy, int tradeType,
                                     string contractCode, string pair)
        {
            var result = client.IsolatedGetOpenOrderAsync(contractCode, pageIndex, pageSize, sortBy, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOpenOrderAsync(pageIndex, pageSize, sortBy, tradeType, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", "SHIB-USDT", "btc-usdt")]
        public void GetHisOrderTest(int tradeType, int type, string status,
                                    int createdDate, int? pageIndex, int? pageSize, string sortBy,
                                    string contractCode, string pair)
        {
            var result = client.IsolatedGetHisOrderAsync(contractCode, tradeType, type, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisOrderAsync(tradeType, type, status, createdDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", "SHIB-USDT", "btc-usdt")]
        public void GetHisOrderExactTest(int tradeType, int type, string status,
                                        string order_price_type, long? start_time, long? end_time,
                                        long? from_id, int size, string direct, string contractCode, string pair)
        {
            var result = client.IsolatedGetHisOrderExactAsync(contractCode, tradeType, type, status, order_price_type, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisOrderExactAsync(tradeType, type, status, order_price_type, start_time, end_time, from_id, size, direct, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 1, null, null, "SHIB-USDT", "btc-usdt")]
        [InlineData(0, 1, 1, 20, "SHIB-USDT", "btc-usdt")]
        public void GetHisMatchTest(int tradeType, int createdDate, int? pageIndex, int? pageSize, string contractCode, string pair)
        {
            var result = client.IsolatedGetHisMatchAsync(contractCode, tradeType, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisMatchAsync(tradeType, createdDate, pageIndex, pageSize, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, null, null, null, 200, "prev", "SHIB-USDT", "btc-usdt")]
        public void GetHisMatchExactTest(int tradeType, long? start_time, long? end_time,
                                        long? from_id, int size, string direct,
                                        string contractCode, string pair)
        {
            var result = client.IsolatedGetHisMatchExactAsync(contractCode, tradeType, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisMatchExactAsync(tradeType, start_time, end_time, from_id, size, direct, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
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