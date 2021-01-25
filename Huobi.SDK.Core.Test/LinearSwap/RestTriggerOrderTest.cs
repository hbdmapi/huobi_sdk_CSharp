using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using TriggerOrder = Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test
{
    public class RestTriggerOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TriggerOrderClient client = new TriggerOrderClient(config["AccessKey"], config["SecretKey"], config["Host"]);

        [Theory]
        [InlineData("XRP-USDT", "le", 0.15, "buy", "open", 1, 0.15, null, 5)]
        [InlineData("XRP-USDT", "le", 0.15, "buy", "open", 1, 0.15, "limit", 5)]
        public void PlaceOrderTest(string contractCode, string triggerType, double triggerPrice, string direction, string offset, long volume,
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
            var result = client.IsolatedPlaceOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossPlaceOrderAsync(request).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", "22,25")]
        [InlineData("XRP-USDT", null)]
        public void CancelOrderTest(string contractCode, string orderId)
        {
            var result = client.IsolatedCancelOrderAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossCancelOrderAsync(contractCode, orderId).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", null, null)]
        [InlineData("XRP-USDT", 1, 10)]
        public void GetOpenOrderTest(string contractCode, int? pageIndex, int? pageSize)
        {
            var result = client.IsolatedGetOpenOrderAsync(contractCode, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOpenOrderAsync(contractCode, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("XRP-USDT", 0, "0", 1, null, null)]
        [InlineData("XRP-USDT", 0, "0", 1, 1, 20)]
        public void GetHisOrderTest(string contractCode, int tradeType, string status, int createdDate,
                                           int? pageIndex, int? pageSize)
        {
            var result = client.IsolatedGetHisOrderAsync(contractCode, tradeType, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisOrderAsync(contractCode, tradeType, status, createdDate, pageIndex, pageSize).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("EOS-USDT", "buy", 1, 2.0, 2.0, "limit", 3.0, 3.0, "limit")]
        public void TpslOrderTest(string contractCode, string direction, long volume, double tpTriggerPrice, double tpOrderPrice, string tpOrderPriceType,
                                  double slTriggerPrice, double slOrderPrice, string slOrderPriceType)
        {
            TriggerOrder.TpslOrderRequest request = new TriggerOrder.TpslOrderRequest
            {
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
            var result = client.IsolatedTpslOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossTpslOrderAsync(request).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("EOS-USDT", "799327909361061888")]
        [InlineData("EOS-USDT", null)]
        public void TpslCancelTest(string contractCode, string orderId)
        {
            var result = client.IsolatedTpslCancelAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);

            result = client.CrossTpslCancelAsync(contractCode, orderId).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void TpslOpenOrderTest(string contractCode, int page_index=1, int page_size=50)
        {
            var result = client.IsolatedGetTpslOpenOrderAsync(contractCode, page_index, page_size).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);

            result = client.CrossGetTpslOpenOrderAsync(contractCode, page_index, page_size).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT")]
        public void TpslHisOrderTest(string contractCode, string status="0", int create_date=10)
        {
            var result = client.IsolatedGetTpslHisOrderAsync(contractCode, status, create_date).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);

            result = client.CrossGetTpslHisOrderAsync(contractCode, status, create_date).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("BTC-USDT", 801045594587615232)]
        public void RelationTpslOrderTest(string contractCode, long orderId)
        {
            var result = client.IsolatedGetRelationTpslOrderAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);

            result = client.CrossGetRelationTpslOrderAsync(contractCode, orderId).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

    }
}