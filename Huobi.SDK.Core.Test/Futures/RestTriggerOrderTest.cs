using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.Futures.RESTful;
using TriggerOrder = Huobi.SDK.Core.Futures.RESTful.Request.TriggerOrder;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.Futures
{
    public class RestTriggerOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TriggerOrderClient client = new TriggerOrderClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData("btch", null, "bch210625", "le", 100, "buy", "open", 1, 100, null, 10)]
        [InlineData("bch", "quarter", null, "le", 100, "buy", "open", 1, 100, "limit", 10)]
        public void PlaceOrderTest(string symbol, string contractType, string contractCode, string triggerType, 
                                   double triggerPrice, string direction, string offset, long volume,
                                   double orderPrice, string orderPriceType, int? leverRate)
        {
            TriggerOrder.PlaceOrderRequest request = new TriggerOrder.PlaceOrderRequest
            {
                symbol = symbol,
                contractType = contractType,
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
        //[InlineData("bch", "821041478083768321", "open", "buy")]
        [InlineData("bch", null, null, null)]
        public void CancelOrderTest(string contractCode, string orderId, string offset, string direction)
        {
            var result = client.CancelOrderAsync(contractCode, orderId, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", null, null, null, null)]
        [InlineData("bch", "bch210625", 1, 10, 0)]
        public void GetOpenOrderTest(string symbol, string contractCode, int? pageIndex, int? pageSize, int? tradeType)
        {
            var result = client.GetOpenOrderAsync(symbol, contractCode, pageIndex, pageSize, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", "bch210625", 0, "0", 1, null, null, null)]
        [InlineData("bch", "bch210625", 0, "0", 1, 1, 20, "created_at")]
        public void GetHisOrderTest(string symbol, string contractCode, int tradeType, string status, int createdDate,
                                    int? pageIndex, int? pageSize, string sortBy)
        {
            var result = client.GetHisOrderAsync(symbol, contractCode, tradeType, status, createdDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, null, "bch210625", "sell", 1, 800, 800, "limit", 300, 300, "limit")]
        //[InlineData("bch", "quarter", null, "buy", 1, 800, 800, "limit", 300, 300, "limit")]
        public void TpslOrderTest(string symbol, string contractType, string contractCode, string direction, 
                                  long volume, double tpTriggerPrice, double tpOrderPrice, string tpOrderPriceType,
                                  double slTriggerPrice, double slOrderPrice, string slOrderPriceType)
        {
            TriggerOrder.TpslOrderRequest request = new TriggerOrder.TpslOrderRequest
            {
                symbol = symbol,
                contractType = contractType,
                contractCode = contractCode,
                direction = direction,
                volume = volume,
                tpTriggerPrice = tpTriggerPrice,
                tpOrderPrice = tpOrderPrice,
                tpOrderPriceType = tpOrderPriceType,
                slTriggerPrice = slTriggerPrice,
                slOrderPrice = slOrderPrice,
                slOrderPriceType = slOrderPriceType,
            };
            var result = client.TpslOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData(null, null, "bch210625", null, "sell")]
        [InlineData("bch", "821049733317193728,821049733317193729", null, "quarter", null)]
        public void TpslCancelTest(string symbol, string orderId, string contractCode, string contractType, string direction)
        {
            var result = client.TpslCancelAsync(symbol, orderId, contractCode, contractType, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", null, null, null, null)]
        [InlineData("bch", "bch210625", null, null, null)]
        public void TpslOpenOrderTest(string symbol, string contractCode, int? page_index, int? page_size, int? tradeType)
        {
            var result = client.GetTpslOpenOrderAsync(symbol, contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", "0", 90, null, null, null, null)]
        [InlineData("bch", "0", 90, "bch210625", 1, 20, "update_time")]
        public void TpslHisOrderTest(string symbol, string status, int createDate, string contractCode,
                                     int? pageIndex, int? pageSize , string sortBy)
        {
            var result = client.GetTpslHisOrderAsync(symbol, status, createDate, contractCode, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", 821063355179077633)]
        public void RelationTpslOrderTest(string symbol, long orderId)
        {
            var result = client.GetRelationTpslOrderAsync(symbol, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData(null, null, "bch210625", "sell", "open", 10, 1, 0.01, 300, "limit")]
        public void TrackOrderTest(string symbol, string contractType, string contractCode, string direction, 
                                  string offset, int lever_rate, double volume, double callback_rate,
                                  double active_price, string order_price_type)
        {
            TriggerOrder.TrackOrderRequest request = new TriggerOrder.TrackOrderRequest
            {
                symbol = symbol,
                contractType = contractType,
                contractCode = contractCode,
                direction = direction,
                offset = offset,
                leverRate = lever_rate,
                volume = volume,
                callbackRate = callback_rate,
                activePrice = active_price,
                orderPriceType = order_price_type
            };
            var result = client.TrackOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", "821049733317193728,821049733317193729", null, "quarter", null, null)]
        public void TrackCancelTest(string symbol, string orderId, string contractCode, string contractType, string direction, string offset)
        {
            var result = client.TrackCancelAsync(symbol, orderId, contractCode, contractType, direction, offset).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("bch", null, null, null, null)]
        [InlineData("bch", "bch210625", null, null, null)]
        public void TrackOpenOrderTest(string symbol, string contractCode, int? page_index, int? page_size, int? tradeType)
        {
            var result = client.GetTrackOpenOrderAsync(symbol, contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("bch", null, "0", 0, 90, 1, 20, "update_time")]
        public void TrackHisOrderTest(string symbol, string contractCode, string status, int tradeType, int createDate,
                                      int? pageIndex, int? pageSize , string sortBy)
        {
            var result = client.GetTrackHisOrderAsync(symbol, contractCode, status, tradeType, createDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

    }
}