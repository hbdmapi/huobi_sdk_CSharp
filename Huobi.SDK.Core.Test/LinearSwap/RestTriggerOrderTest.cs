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
}