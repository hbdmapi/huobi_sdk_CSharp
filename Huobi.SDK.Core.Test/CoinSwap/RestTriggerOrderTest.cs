using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.CoinSwap.RESTful;
using TriggerOrder = Huobi.SDK.Core.CoinSwap.RESTful.Request.TriggerOrder;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class RestTriggerOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TriggerOrderClient client = new TriggerOrderClient(config["AccessKey"], config["SecretKey"], Host.FUTURES);

        [Theory]
        [InlineData("TRX-USD", "ge", 0.6, "buy", "close", 1, 0.6, null, 10)]
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
            var result = client.PlaceOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", "817359783215788032", "close", "buy")]
        public void CancelOrderTest(string contractCode, string orderId, string offset, string direction)
        {
            var result = client.CancelOrderAsync(contractCode, orderId, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        //[InlineData("TRX-USD", null, null, null)]
        [InlineData("TRX-USD", 1, 10, 0)]
        public void GetOpenOrderTest(string contractCode, int pageIndex, int pageSize, int tradeType)
        {
            var result = client.GetOpenOrderAsync(contractCode, pageIndex, pageSize, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 0, "0", 10, 1, 20)]
        public void GetHisOrderTest(string contractCode, int tradeType, string status, int createdDate,
                                    int? pageIndex, int? pageSize)
        {
            var result = client.GetHisOrderAsync(contractCode, tradeType, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", "buy", 1, 0.03, 0.03, "limit", 0.06, 0.06, "limit")]
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
            var result = client.TpslOrderAsync(request).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", "818431499623350272", null)]
        //[InlineData("TRX-USD", null, "sell")]
        public void TpslCancelTest(string contractCode, string orderId, string direction)
        {
            var result = client.TpslCancelAsync(contractCode, orderId, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD")]
        public void TpslOpenOrderTest(string contractCode, int page_index=1, int page_size=50, int? tradeType = 0)
        {
            var result = client.GetTpslOpenOrderAsync(contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD")]
        public void TpslHisOrderTest(string contractCode, string status="0", int create_date=90)
        {
            var result = client.GetTpslHisOrderAsync(contractCode, status, create_date).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

        [Theory]
        [InlineData("TRX-USD", 818431499623350272)]
        public void RelationTpslOrderTest(string contractCode, long orderId)
        {
            var result = client.GetRelationTpslOrderAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            //Assert.Equal("ok", result.status);
        }

    }
}