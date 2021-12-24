using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using TriggerOrder = Huobi.SDK.Core.LinearSwap.RESTful.Request.TriggerOrder;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestTriggerOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static TriggerOrderClient client = new TriggerOrderClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData("le", 0.00003, "buy", "open", 1, 0.15, "limit", 5, "SHIB-USDT", "swap", "btc-usdt")]
        public void PlaceOrderTest(string triggerType, double triggerPrice, string direction, string offset, long volume,
                                   double orderPrice, string orderPriceType, int? leverRate,
                                   string contractCode, string contractType, string pair)
        {
            TriggerOrder.PlaceOrderRequest request1 = new TriggerOrder.PlaceOrderRequest
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
            var result = client.IsolatedPlaceOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            TriggerOrder.PlaceOrderRequest request2 = new TriggerOrder.PlaceOrderRequest
            {
                triggerType = triggerType,
                triggerPrice = triggerPrice,
                volume = volume,
                direction = direction,
                offset = offset,
                orderPrice = orderPrice,
                orderPriceType = orderPriceType,
                leverRate = leverRate,
                contractCode = contractCode,
                contractType = contractType,
                pair = pair
            };
            result = client.CrossPlaceOrderAsync(request2).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("921083905048895489,921083907016171520", "open", "buy", "SHIB-USDT", "swap", "btc-usdt")]
        public void CancelOrderTest(string orderId, string offset, string direction,
                                    string contractCode, string contractType, string pair)
        {
            var result = client.IsolatedCancelOrderAsync(contractCode, orderId, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossCancelOrderAsync(orderId, offset, direction, contractCode, contractType, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 10, 1, "SHIB-USDT", "btc-usdt")]
        public void GetOpenOrderTest(int pageIndex, int pageSize, int tradeType, string contractCode, string pair)
        {
            var result = client.IsolatedGetOpenOrderAsync(contractCode, pageIndex, pageSize, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetOpenOrderAsync(pageIndex, pageSize, tradeType, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, "0", 1, 1, 20, "created_at", "SHIB-USDT", "btc-usdt")]
        public void GetHisOrderTest(int tradeType, string status, int createdDate, 
                                    int pageIndex, int pageSize, string sortBy,
                                    string contractCode, string pair)
        {
            var result = client.IsolatedGetHisOrderAsync(contractCode, tradeType, status, createdDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetHisOrderAsync(tradeType, status, createdDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("sell", 1, 0.00004, 0.00004, "limit", 0.00003, 0.00003, "limit", "SHIB-USDT", "swap", "btc-usdt")]
        public void TpslOrderTest(string direction, long volume, double tpTriggerPrice, double tpOrderPrice, string tpOrderPriceType,
                                  double slTriggerPrice, double slOrderPrice, string slOrderPriceType,
                                  string contractCode, string contractType, string pair)
        {
            TriggerOrder.TpslOrderRequest request1 = new TriggerOrder.TpslOrderRequest
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
            var result = client.IsolatedTpslOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            TriggerOrder.TpslOrderRequest request2 = new TriggerOrder.TpslOrderRequest
            {
                direction = direction,
                volume = volume,
                tpTriggerPrice = tpTriggerPrice,
                tpOrderPrice = tpOrderPrice,
                tpOrderPriceType = tpOrderPriceType,
                slTriggerPrice = slTriggerPrice,
                slOrderPrice = slOrderPrice,
                slOrderPriceType = slOrderPriceType,
                contractCode = contractCode,
                contractType = contractType,
                pair = pair
            };
            result = client.CrossTpslOrderAsync(request2).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("921090433126600704,921090435207061504", "sell", "SHIB-USDT", "swap", "btc-usdt")]
        [InlineData(null, "sell", "SHIB-USDT", "swap", "btc-usdt")]
        public void TpslCancelTest(string orderId, string direction, string contractCode, string contractType, string pair)
        {
            var result = client.IsolatedTpslCancelAsync(contractCode, orderId, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossTpslCancelAsync(orderId, direction, contractCode, contractType, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 50, 4, "SHIB-USDT", "btc-usdt")]
        public void TpslOpenOrderTest(int page_index, int page_size, int? tradeType,
                                      string contractCode, string pair)
        {
            var result = client.IsolatedGetTpslOpenOrderAsync(contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetTpslOpenOrderAsync(page_index, page_size, tradeType, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("0", 10, 1, 1, "created_at", "SHIB-USDT", "btc-usdt")]
        public void TpslHisOrderTest(string status, int createDate, int pageIndex, int pageSize, 
                                     string sortBy, string contractCode, string pair)
        {
            var result = client.IsolatedGetTpslHisOrderAsync(contractCode, status, createDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetTpslHisOrderAsync(status, createDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(801045594587615232, "SHIB-USDT", "btc-usdt")]
        public void RelationTpslOrderTest(long orderId, string contractCode, string pair)
        {
            var result = client.IsolatedGetRelationTpslOrderAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            // Assert.Equal("ok", result.status);

            result = client.CrossGetRelationTpslOrderAsync(orderId, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            // Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("open", "buy", 5, 1, 0.01, 0.00003, "optimal_5", "SHIB-USDT", "swap", "btc-usdt")]
        public void TrackOrderTest(string offset, string direction, int leverRate, int volume, double callbackRate,
                                  double activePrice, string orderPriceType, string contractCode, string contractType, string pair)
        {
            TriggerOrder.TrackOrderRequest request1 = new TriggerOrder.TrackOrderRequest
            {
                direction = direction,
                offset = offset,
                leverRate = leverRate,
                volume = volume,
                callbackRate = callbackRate,
                activePrice = activePrice,
                orderPriceType = orderPriceType,
                contractCode = contractCode
            };
            var result = client.IsolatedTrackOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            TriggerOrder.TrackOrderRequest request2 = new TriggerOrder.TrackOrderRequest
            {
                direction = direction,
                offset = offset,
                leverRate = leverRate,
                volume = volume,
                callbackRate = callbackRate,
                activePrice = activePrice,
                orderPriceType = orderPriceType,
                contractCode = contractCode,
                contractType = contractType,
                pair = pair
            };
            result = client.CrossTrackOrderAsync(request2).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("921106661303967744,921106663271002112", "SHIB-USDT", "swap", "btc-usdt")]
        [InlineData(null, "SHIB-USDT", "swap", "btc-usdt")]
        public void TrackCancelTest(string orderId, string contractCode, string contractType, string pair)
        {
            var result = client.IsolatedTrackCancelAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossTrackCancelAsync(orderId, contractCode, contractType, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 50, 0, "SHIB-USDT", "btc-usdt")]
        public void TrackOpenOrderTest(int page_index, int page_size, int? tradeType,
                                       string contractCode, string pair)
        {
            var result = client.IsolatedGetTrackOpenOrderAsync(contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetTrackOpenOrderAsync(page_index, page_size, tradeType, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("0", 0, 10, 1, 1, "created_at", "SHIB-USDT", "btc-usdt")]
        public void TrackHisOrderTest(string status, int tradeType, int createDate, int pageIndex, int pageSize,
                                      string sortBy, string contractCode, string pair)
        {
            var result = client.IsolatedGetTrackHisOrderAsync(contractCode, status, tradeType, createDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            result = client.CrossGetTrackHisOrderAsync(status, tradeType, createDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

    }
}