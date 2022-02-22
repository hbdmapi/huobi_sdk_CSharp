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
        [InlineData("le", 43000, "buy", "both", 1, 43000, "limit", 5, "BTC-USDT", 1)]
        // [InlineData("le", 43000, "buy", "open", 1, 43000, "limit", 5, "BTC-HUSD")]
        public void IsolatedPlaceOrderTest(string triggerType, double triggerPrice, string direction, string offset, long volume,
                                   double orderPrice, string orderPriceType, int? leverRate,
                                   string contractCode, int? reduceOnly)
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
                leverRate = leverRate,
                reduceOnly = reduceOnly
            };
            var result = client.IsolatedPlaceOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }


        [Theory]
        [InlineData("le", 43000, "sell", "both", 1, 43000, "limit", 10, "BTC-USDT", null, null, 1)]
        // [InlineData("le", 43000, "buy", "open", 1, 43000, "limit", 5, null, "swap", "btc-usdt")]
        // [InlineData("le", 43000, "buy", "open", 1, 43000, "limit", 5, "BTC-HUSD", null, null)]
        // [InlineData("le", 43000, "buy", "open", 1, 43000, "limit", 5, null, "swap", "btc-husd")]
        public void CrossPlaceOrderTest(string triggerType, double triggerPrice, string direction, string offset, long volume,
                                   double orderPrice, string orderPriceType, int? leverRate,
                                   string contractCode, string contractType, string pair,
                                   int? reduceOnly)
        {
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
                pair = pair,
                reduceOnly = reduceOnly
            };
            var result = client.CrossPlaceOrderAsync(request2).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("933011673197842432", "open", "buy", "BTC-USDT")]
        // [InlineData("933011675181748224", "open", "buy", "BTC-HUSD")]
        [InlineData(null, "open", "buy", "BTC-USDT")]
        [InlineData(null, "open", "buy", "BTC-HUSD")]
        public void IsolatedCancelOrderTest(string orderId, string offset, string direction,
                                            string contractCode)
        {
            var result = client.IsolatedCancelOrderAsync(contractCode, orderId, offset, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("933012194180739072", "open", "buy", "BTC-USDT", null, null)]
        // [InlineData("933012197930446848", "open", "buy", null, "swap", "btc-usdt")]
        // [InlineData("933012196110110720", "open", "buy", "BTC-HUSD", null, null)]
        // [InlineData("933012199679463424", "open", "buy", null, "swap", "btc-husd")]
        [InlineData(null, "open", "buy", "BTC-HUSD", null, null)]
        [InlineData(null, "open", "buy", null, "swap", "btc-usdt")]
        public void CrossCancelOrderTest(string orderId, string offset, string direction,
                                         string contractCode, string contractType, string pair)
        {
            var result = client.CrossCancelOrderAsync(orderId, offset, direction, contractCode, contractType, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 10, 0, "BTC-USDT")]
        [InlineData(1, 10, 17, "BTC-USDT")]
        // [InlineData(1, 10, 1, "BTC-HUSD")]
        public void IsolatedGetOpenOrderTest(int pageIndex, int pageSize, int tradeType, string contractCode)
        {
            var result = client.IsolatedGetOpenOrderAsync(contractCode, pageIndex, pageSize, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 10, 0, "BTC-USDT", null, null)]
        [InlineData(1, 10, 18, "BTC-USDT", null, null)]
        // [InlineData(1, 10, 1, null, "btc-usdt", null)]
        // [InlineData(1, 10, 1, "BTC-HUSD", null, "husd")]
        // [InlineData(1, 10, 1, null, "btc-husd", "all")]
        public void CrossGetOpenOrderTest(int pageIndex, int pageSize, int tradeType, string contractCode, string pair,
                                          string tradePartition)
        {
            var result = client.CrossGetOpenOrderAsync(pageIndex, pageSize, tradeType, contractCode, pair, tradePartition).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, "0", 1, 1, 20, "created_at", "BTC-USDT")]
        [InlineData(17, "0", 1, 1, 20, "created_at", "BTC-USDT")]
        // [InlineData(0, "0", 1, 1, 20, "created_at", "BTC-HUSD")]
        public void IsolatedGetHisOrderTest(int tradeType, string status, int createdDate, 
                                    int pageIndex, int pageSize, string sortBy,
                                    string contractCode)
        {
            var result = client.IsolatedGetHisOrderAsync(contractCode, tradeType, status, createdDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, "0", 1, 1, 20, "created_at", "BTC-USDT", null)]
        [InlineData(18, "0", 1, 1, 20, "created_at", "BTC-USDT", null)]
        // [InlineData(0, "0", 1, 1, 20, "created_at", null, "btc-usdt")]
        // [InlineData(0, "0", 1, 1, 20, "created_at", "BTC-HUSD", null)]
        // [InlineData(0, "0", 1, 1, 20, "created_at", null, "btc-husd")]
        public void CrossGetHisOrderTest(int tradeType, string status, int createdDate, 
                                         int pageIndex, int pageSize, string sortBy,
                                         string contractCode, string pair)
        {
            var result = client.CrossGetHisOrderAsync(tradeType, status, createdDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("sell", 1, 48000, 48000, "limit", 43000, 43000, "limit", "BTC-USDT")]
        [InlineData("sell", 1, 48000, 48000, "limit", 43000, 43000, "limit", "BTC-HUSD")]
        public void IsolatedTpslOrderTest(string direction, long volume, double tpTriggerPrice, double tpOrderPrice, string tpOrderPriceType,
                                  double slTriggerPrice, double slOrderPrice, string slOrderPriceType,
                                  string contractCode)
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
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("sell", 1, 48000, 48000, "limit", 43000, 43000, "limit", "BTC-USDT", null, null)]
        [InlineData("sell", 1, 48000, 48000, "limit", 43000, 43000, "limit", "BTC-HUSD", null, null)]
        [InlineData("sell", 1, 48000, 48000, "limit", 43000, 43000, "limit", null, "swap", "btc-usdt")]
        [InlineData("sell", 1, 48000, 48000, "limit", 43000, 43000, "limit", null, "swap", "btc-husd")]
        public void CrossTpslOrderTest(string direction, long volume, double tpTriggerPrice, double tpOrderPrice, string tpOrderPriceType,
                                  double slTriggerPrice, double slOrderPrice, string slOrderPriceType,
                                  string contractCode, string contractType, string pair)
        {

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
            var result = client.CrossTpslOrderAsync(request2).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("933054821194280960", "sell", "BTC-USDT")]
        // [InlineData("933054819201978369", "sell", "BTC-HUSD")]
        [InlineData(null, "sell", "BTC-USDT")]
        [InlineData(null, "sell", "BTC-HUSD")]
        public void IsolatedTpslCancelTest(string orderId, string direction, string contractCode)
        {
            var result = client.IsolatedTpslCancelAsync(contractCode, orderId, direction).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("933055478097776641", "sell", "BTC-HUSD", null, null)]
        // [InlineData("933055479809052673", "sell", null, "swap", "btc-usdt")]
        [InlineData(null, "sell", "BTC-HUSD", null, null)]
        [InlineData(null, "sell", null, "swap", "btc-usdt")]
        public void CrossTpslCancelTest(string orderId, string direction, string contractCode, string contractType, string pair)
        {
            var result = client.CrossTpslCancelAsync(orderId, direction, contractCode, contractType, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 50, 4, "BTC-USDT")]
        [InlineData(1, 50, 4, "BTC-HUSD")]
        public void IsolatedTpslOpenOrderTest(int page_index, int page_size, int? tradeType,
                                              string contractCode)
        {
            var result = client.IsolatedGetTpslOpenOrderAsync(contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 50, 4, "BTC-USDT", null, null)]
        [InlineData(1, 50, 4, null, "btc-usdt", null)]
        [InlineData(1, 50, 4, "BTC-HUSD", null, "husd")]
        [InlineData(1, 50, 4, null, "btc-husd", "all")]
        public void CrossTpslOpenOrderTest(int page_index, int page_size, int? tradeType,
                                           string contractCode, string pair,
                                           string tradePartition)
        {
            var result = client.CrossGetTpslOpenOrderAsync(page_index, page_size, tradeType, contractCode, pair, tradePartition).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("0", 10, 1, 1, "created_at", "BTC-USDT")]
        [InlineData("0", 10, 1, 1, "created_at", "BTC-HUSD")]
        public void IsolatedTpslHisOrderTest(string status, int createDate, int pageIndex, int pageSize, 
                                             string sortBy, string contractCode)
        {
            var result = client.IsolatedGetTpslHisOrderAsync(contractCode, status, createDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("0", 10, 1, 1, "created_at", "BTC-USDT", null)]
        [InlineData("0", 10, 1, 1, "created_at", null, "btc-usdt")]
        [InlineData("0", 10, 1, 1, "created_at", "BTC-HUSD", null)]
        [InlineData("0", 10, 1, 1, "created_at", null, "btc-husd")]
        public void CrossTpslHisOrderTest(string status, int createDate, int pageIndex, int pageSize, 
                                          string sortBy, string contractCode, string pair)
        {
            var result = client.CrossGetTpslHisOrderAsync(status, createDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(933063729749168128, "BTC-USDT")]
        [InlineData(933063727912062976, "BTC-HUSD")]
        public void IsolatedRelationTpslOrderTest(long orderId, string contractCode)
        {
            var result = client.IsolatedGetRelationTpslOrderAsync(contractCode, orderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            Assert.Equal(tp, result.data.tradePartition);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(933073694324953088, "BTC-USDT", null)]
        [InlineData(933073694324953088, null, "btc-usdt")]
        [InlineData(933073458743488512, "BTC-HUSD", null)]
        [InlineData(933073458743488512, null, "btc-husd")]
        public void CrossRelationTpslOrderTest(long orderId, string contractCode, string pair)
        {
            var result = client.CrossGetRelationTpslOrderAsync(orderId, contractCode, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            Assert.Equal(tp, result.data.tradePartition);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("both", "buy", 5, 1, 0.01, 44000, "optimal_5", "BTC-USDT", 1)]
        // [InlineData("open", "buy", 5, 1, 0.01, 42000, "optimal_5", "BTC-HUSD")]
        public void IsolatedTrackOrderTest(string offset, string direction, int leverRate, int volume, double callbackRate,
                                  double activePrice, string orderPriceType, string contractCode,
                                  int? reduceOnly)
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
                contractCode = contractCode,
                reduceOnly = reduceOnly
            };
            var result = client.IsolatedTrackOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("both", "buy", 10, 1, 0.01, 42000, "optimal_5", "BTC-USDT", null, null, 1)]
        // [InlineData("open", "buy", 5, 1, 0.01, 42000, "optimal_5", null, "swap", "btc-usdt")]
        // [InlineData("open", "buy", 5, 1, 0.01, 42000, "optimal_5", "BTC-HUSD", null, null)]
        // [InlineData("open", "buy", 5, 1, 0.01, 42000, "optimal_5", null, "swap", "btc-HUSD")]
        public void CrossTrackOrderTest(string offset, string direction, int leverRate, int volume, double callbackRate,
                                  double activePrice, string orderPriceType, string contractCode, string contractType, string pair,
                                  int? reduceOnly)
        {
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
                pair = pair,
                reduceOnly = reduceOnly
            };
            var result = client.CrossTrackOrderAsync(request2).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("933403228089888768", "BTC-USDT")]
        // [InlineData("933403230161874944", "BTC-HUSD")]
        [InlineData(null, "BTC-USDT")]
        [InlineData(null, "BTC-HUSD")]
        public void IsolatedTrackCancelTest(string orderId, string contractCode)
        {
            var result = client.IsolatedTrackCancelAsync(orderId, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        // [InlineData("933405436755849216", "BTC-USDT", null, null)]
        // [InlineData("933405515688456192", null, "swap", "btc-usdt")]
        // [InlineData("933405611796738048", "BTC-HUSD", null, null)]
        // [InlineData("933405691618537472", null, "swap", "btc-husd")]
        [InlineData(null, null, "swap", "btc-usdt")]
        [InlineData(null, "BTC-HUSD", null, null)]
        public void CrossTrackCancelTest(string orderId, string contractCode, string contractType, string pair)
        {
            var result = client.CrossTrackCancelAsync(orderId, contractCode, contractType, pair).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 50, 0, "BTC-USDT")]
        [InlineData(1, 50, 17, "BTC-USDT")]
        // [InlineData(1, 50, 0, "BTC-HUSD")]
        public void IsolatedTrackOpenOrderTest(int page_index, int page_size, int? tradeType,
                                        string contractCode)
        {
            var result = client.IsolatedGetTrackOpenOrderAsync(contractCode, page_index, page_size, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 50, 0, "BTC-USDT", null, null)]
        [InlineData(1, 50, 18, "BTC-USDT", null, null)]
        // [InlineData(1, 50, 0, null, "btc-usd", null)]
        // [InlineData(1, 50, 0, "BTC-HUSD", null, "husd")]
        // [InlineData(1, 50, 0, null, "btc-husd", "all")]
        public void CrossTrackOpenOrderTest(int page_index, int page_size, int? tradeType,
                                            string contractCode, string pair, string tradePartition)
        {
            var result = client.CrossGetTrackOpenOrderAsync(page_index, page_size, tradeType, contractCode, pair, tradePartition).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("0", 0, 10, 1, 1, "created_at", "BTC-USDT")]
        [InlineData("0", 18, 10, 1, 1, "created_at", "BTC-USDT")]
        // [InlineData("0", 0, 10, 1, 1, "created_at", "BTC-HUSD")]
        public void IsolatedTrackHisOrderTest(string status, int tradeType, int createDate, int pageIndex, int pageSize,
                                      string sortBy, string contractCode)
        {
            var result = client.IsolatedGetTrackHisOrderAsync(contractCode, status, tradeType, createDate, pageIndex, pageSize, sortBy).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("0", 0, 10, 1, 1, "created_at", "BTC-USDT", null)]
        [InlineData("0", 17, 10, 1, 1, "created_at", "BTC-USDT", null)]
        // [InlineData("0", 0, 10, 1, 1, "created_at", null, "btc-usdt")]
        // [InlineData("0", 0, 10, 1, 1, "created_at", "BTC-HUSD", null)]
        // [InlineData("0", 0, 10, 1, 1, "created_at", null, "btc-husd")]
        public void CrossTrackHisOrderTest(string status, int tradeType, int createDate, int pageIndex, int pageSize,
                                      string sortBy, string contractCode, string pair)
        {
            var result = client.CrossGetTrackHisOrderAsync(status, tradeType, createDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (pair != null)
            {
                tp = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

    }
}