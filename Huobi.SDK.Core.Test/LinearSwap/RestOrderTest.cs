using Xunit;
using Microsoft.Extensions.Configuration;
using Huobi.SDK.Core.LinearSwap.RESTful;
using Order = Huobi.SDK.Core.LinearSwap.RESTful.Request.Order;
using Huobi.SDK.Core.LinearSwap.RESTful.Response.Order;
using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class RestOrderTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static OrderClient client = new OrderClient(config["AccessKey"], config["SecretKey"]);

        [Theory]
        [InlineData("btc-usdt", null, 42000, 1, "buy", "open", 5, "limit")]
        [InlineData("btc-husd", null,  42000, 1, "buy", "open", 5, "limit")]
        public void IsolatedPlaceOrderTest(string contractCode, long? clientOrderId, double price, long volume,
                                           string direction, string offset, int leverRate, string orderPriceType)
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
                orderPriceType = orderPriceType,
                tpTriggerPrice = price + 200,
                tpOrderPrice = price + 200,
                tpOrderPriceType = orderPriceType,
                slTriggerPrice = price - 200,
                slOrderPrice = price - 200,
                slOrderPriceType = orderPriceType
            };

            var result = client.IsolatedPlaceOrderAsync(request1).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("btc-usdt", null, 42000, 1, "buy", "open", 5, "limit", null, null)]
        // [InlineData(null, null,  42000, 1, "buy", "open", 5, "limit", "swap", "btc-usdt")]
        // [InlineData(null, null,  42000, 1, "buy", "open", 5, "limit", "quarter", "btc-usdt")]
        // [InlineData("btc-usdt-220121", null,  42000, 1, "buy", "open", 5, "limit", "quarter", "btc-usdt")]
        // [InlineData("btc-husd", null, 42000, 1, "buy", "open", 5, "limit", null, null)]
        // [InlineData(null, null,  42000, 1, "buy", "open", 5, "limit", "swap", "btc-husd")]
        // [InlineData(null, null,  42000, 1, "buy", "open", 5, "limit", "quarter", "btc-husd")]
        // [InlineData("btc-husd-220121", null,  42000, 1, "buy", "open", 5, "limit", "quarter", "btc-husd")]
        public void CrossPlaceOrderTest(string contractCode, long? clientOrderId, double price, long volume,
                                        string direction, string offset, int leverRate, string orderPriceType,
                                        string contractType, string pair)
        {
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
                pair = pair,
                tpTriggerPrice = price + 200,
                tpOrderPrice = price + 200,
                tpOrderPriceType = orderPriceType,
                slTriggerPrice = price - 200,
                slOrderPrice = price - 200,
                slOrderPriceType = orderPriceType
            };
            var result = client.CrossPlaceOrderAsync(request2).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("btc-usdt", null, 42000, 1, "buy", "open", 5, "limit")]
        [InlineData("btc-husd", null, 42000, 1, "buy", "open", 5, "limit")]
        public void IsolatedPlaceBatchOrderTest(string contractCode, long? clientOrderId, float price, long volume, string direction,
                                        string offset, int leverRate, string orderPriceType)
        {
            Order.PlaceOrderRequest[] request1 = {
                new Order.PlaceOrderRequest
                {
                    contractCode = contractCode,
                    clientOrderId = clientOrderId,
                    price = price,
                    volume = volume,
                    direction = direction,
                    offset = offset,
                    leverRate = leverRate,
                    orderPriceType = orderPriceType
                }
            };
            var result = client.IsolatedPlaceBatchOrderAsync(request1).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("btc-usdt", null, 42000, 1, "buy", "open", 5, "limit", null, null)]
        [InlineData(null, null, 42000, 1, "buy", "open", 5, "limit", "swap", "btc-usdt")]
        [InlineData(null, null, 42000, 1, "buy", "open", 5, "limit", "quarter", "btc-usdt")]
        [InlineData("btc-usdt-220121", null, 42000, 1, "buy", "open", 5, "limit", "quarter", "btc-usdt")]
        [InlineData("btc-husd", null, 42000, 1, "buy", "open", 5, "limit", null, null)]
        [InlineData(null, null, 42000, 1, "buy", "open", 5, "limit", "swap", "btc-husd")]
        [InlineData(null, null, 42000, 1, "buy", "open", 5, "limit", "quarter", "btc-husd")]
        [InlineData("btc-husd-220121", null, 42000, 1, "buy", "open", 5, "limit", "quarter", "btc-husd")]
        public void CrossPlaceBatchOrderTest(string contractCode, long? clientOrderId, float price, long volume, string direction,
                                        string offset, int leverRate, string orderPriceType, string contractType, string pair)
        {
            Order.PlaceOrderRequest[] request2 = {
                new Order.PlaceOrderRequest
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
                }
            };
            var result = client.CrossPlaceBatchOrderAsync(request2).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("932675906495852544,932675908433620992", null, "BTC-USDT")]
        [InlineData("932675906495852544,932675908433620992", null, "BTC-HUSD")]
        [InlineData(null, null, "BTC-USDT")]
        [InlineData(null, null, "BTC-HUSD")]
        public void IsolatedCancelOrderTest(string orderId, string clientOrderId, string contractCode)
        {
            var result = client.IsolatedCancelOrderAsync(orderId, clientOrderId, contractCode).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("932677636872736768", null, "BTC-USDT", null, null)]
        [InlineData("932677638944722944", null, null, "swap", "btc-usdt")]
        [InlineData("932677648528707584", null, null, "quarter", "btc-usdt")]
        [InlineData("932677646502858752", null, "BTC-USDT-220121", null, null)]
        [InlineData("932677640777633792", null, "BTC-HUSD", null, null)]
        [InlineData("932677642644107264", null, null, "swap", "btc-HUSD")]
        [InlineData("932677650491650048", null, null, "quarter", "btc-HUSD")]
        [InlineData("932677644619624448", null, "BTC-HUSD-220121", null, null)]
        // [InlineData(null, null, "BTC-USDT", null, null)]
        [InlineData(null, null, null, "swap", "btc-usdt")]
        [InlineData(null, null, null, "quarter", "btc-usdt")]
        [InlineData(null, null, "BTC-USDT-220121", null, null)]
        [InlineData(null, null, "BTC-HUSD", null, null)]
        // [InlineData(null, null, null, "swap", "btc-HUSD")]
        [InlineData(null, null, null, "quarter", "btc-HUSD")]
        [InlineData(null, null, "BTC-HUSD-220121", null, null)]
        public void CrossCancelOrderTest(string orderId, string clientOrderId, string contractCode,
                                         string contractType, string pair)
        {
            var result = client.CrossCancelOrderAsync(orderId, clientOrderId, contractCode, contractType, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
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
        [InlineData("932675908433620992", null, "btc-usdt")]
        [InlineData("932675906495852544", null, "btc-husd")]
        public void IsolatedGetOrderInfoTest(string orderId, string clientOrderId, string contractCode)
        {
            var result = client.IsolatedGetOrderInfoAsync(contractCode, orderId, clientOrderId).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            
            string type = contractCode.Split("-")[1].ToUpper();
            foreach(var item in result.data)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData("932677636872736768", null, "BTC-USDT", null)]
        [InlineData("932677638944722944", null, null, "btc-usdt")]
        [InlineData("932677648528707584", null, null, "btc-usdt")]
        [InlineData("932677646502858752", null, "BTC-USDT-220121", null)]
        [InlineData("932677640777633792", null, "BTC-HUSD", null)]
        [InlineData("932677642644107264", null, null, "btc-HUSD")]
        [InlineData("932677650491650048", null, null, "btc-HUSD")]
        [InlineData("932677644619624448", null, "BTC-HUSD-220121", null)]
        public void CrossGetOrderInfoTest(string orderId, string clientOrderId, string contractCode, string pair)
        {

            var result = client.CrossGetOrderInfoAsync(orderId, clientOrderId, contractCode, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if (pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(932688343714508800, 1642411829654, 1, 1, 10, "BTC-USDT")]
        [InlineData(932688341734789120, 1642411829183, 1, 1, 10, "BTC-HUSD")]
        public void IsolatedGetOrderDetailTest(long orderId, long? createdAt,
                                               int? orderType, int? pageIndex, int? pageSize,
                                               string contractCode)
        {
            var result = client.IsolatedGetOrderDetailAsync(contractCode, orderId, createdAt, orderType, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = contractCode.Split("-")[1].ToUpper();
            Assert.Equal(type, result.data.tradePartition);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(932677636872736768, 1642409276940, 1, 1, 10, "BTC-USDT", null)]
        [InlineData(932677638944722944, 1642409277434, 1, 1, 10, null, "btc-usdt")]
        [InlineData(932677646502858752, 1642409279237, 1, 1, 10, "BTC-USDT-220121", null)]
        [InlineData(932677642644107264, 1642409278317, 1, 1, 10, "BTC-HUSD", null)]
        [InlineData(932677644619624448, 1642409278787, 1, 1, 10, null, "btc-husd")]
        [InlineData(932677650491650048, 1642409280187, 1, 1, 10, "BTC-HUSD-220325", null)]
        public void CrossGetOrderDetailTest(long orderId, long? createdAt,
                                            int? orderType, int? pageIndex, int? pageSize,
                                            string contractCode, string pair)
        {
            var result = client.CrossGetOrderDetailAsync(orderId,  createdAt, orderType, pageIndex, pageSize, contractCode, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = null;
            if (pair != null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            Assert.Equal(type, result.data.tradePartition);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 10, "created_at", 0, "BTC-USDT")]
        [InlineData(1, 10, "created_at", 0, "BTC-HUSD")]
        public void IsolatedGetOpenOrderTest(int pageIndex, int pageSize, string sortBy, int tradeType,
                                             string contractCode)
        {
            var result = client.IsolatedGetOpenOrderAsync(contractCode, pageIndex, pageSize, sortBy, tradeType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string type = contractCode.Split("-")[1].ToUpper();
            foreach(var item in result.data.orders)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, 10, "created_at", 0, "BTC-USDT", null, null)]
        [InlineData(1, 10, "created_at", 0, null, "btc-usdt", null)]
        [InlineData(1, 10, "created_at", 0, "BTC-HUSD", "btc-husdt", "husd")]
        [InlineData(1, 10, "created_at", 0, null, "btc-husd", "husd")]
        [InlineData(1, 10, "created_at", 0, null, "btc-husd", "all")]
        public void CrossGetOpenOrderTest(int pageIndex, int pageSize, string sortBy, int tradeType,
                                          string contractCode, string pair, string tradePartition)
        {
            var result = client.CrossGetOpenOrderAsync(pageIndex, pageSize, sortBy, tradeType, contractCode, pair, tradePartition).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string type = null;
            if(pair!=null)
            {
                type = pair.Split("-")[1].ToUpper();
            }
            if (contractCode != null)
            {
                type = contractCode.Split("-")[1].ToUpper();
            }
            foreach(var item in result.data.orders)
            {
                Assert.Equal(type, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", "BTC-USDT")]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", "BTC-HUSD")]
        public void IsolatedGetHisOrderTest(int tradeType, int type, string status,
                                    int createdDate, int? pageIndex, int? pageSize, string sortBy,
                                    string contractCode)
        {
            var result = client.IsolatedGetHisOrderAsync(contractCode, tradeType, type, status, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);

            string tp = contractCode.Split("-")[1].ToUpper();
            foreach(var item in result.data.orders)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", "BTC-USDT", null)]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", null, "btc-usdt")]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", "BTC-HUSD", null)]
        [InlineData(0, 1, "0", 10, 1, 20, "create_date", null, "btc-husd")]
        public void CrossGetHisOrderTest(int tradeType, int type, string status,
                                        int createdDate, int? pageIndex, int? pageSize, string sortBy,
                                        string contractCode, string pair)
        {
            var result = client.CrossGetHisOrderAsync(tradeType, type, status, createdDate, pageIndex, pageSize, sortBy, contractCode, pair).Result;
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
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", "BTC-USDT")]
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", "BTC-HUSD")]
        public void IsolatedGetHisOrderExactTest(int tradeType, int type, string status,
                                                string order_price_type, long? start_time, long? end_time,
                                                long? from_id, int size, string direct, string contractCode)
        {
            var result = client.IsolatedGetHisOrderExactAsync(contractCode, tradeType, type, status, order_price_type, start_time, end_time, from_id).Result;
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
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", "BTC-USDT", null)]
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", null, "btc-usdt")]
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", "BTC-HUSD", null)]
        [InlineData(0, 1, "0", "limit", null, null, null, 20, "prev", null, "btc-husd")]
        public void CrossGetHisOrderExactTest(int tradeType, int type, string status,
                                              string order_price_type, long? start_time, long? end_time,
                                              long? from_id, int size, string direct, string contractCode, string pair)
        {
            var result = client.CrossGetHisOrderExactAsync(tradeType, type, status, order_price_type, start_time, end_time, from_id, size, direct, contractCode, pair).Result;
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
        [InlineData(0, 1, null, null, "BTC-USDT")]
        [InlineData(0, 1, 1, 20, "BTC-HUSD")]
        public void IsolatedGetHisMatchTest(int tradeType, int createdDate, int? pageIndex, int? pageSize, string contractCode)
        {
            var result = client.IsolatedGetHisMatchAsync(contractCode, tradeType, createdDate, pageIndex, pageSize).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.trades)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, 1, null, null, "BTC-USDT", null)]
        [InlineData(0, 1, 1, 20, null, "btc-usdt")]
        [InlineData(0, 1, null, null, "BTC-HUSD", null)]
        [InlineData(0, 1, 1, 20, null, "btc-husd")]
        public void CrossGetHisMatchTest(int tradeType, int createdDate, int? pageIndex, int? pageSize, string contractCode, string pair)
        {
            var result = client.CrossGetHisMatchAsync(tradeType, createdDate, pageIndex, pageSize, contractCode, pair).Result;
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
            foreach (var item in result.data.trades)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(0, null, null, null, 200, "prev", "BTC-USDT")]
        [InlineData(0, null, null, null, 200, "prev", "BTC-HUSD")]
        public void IsolatedGetHisMatchExactTest(int tradeType, long? start_time, long? end_time,
                                                 long? from_id, int size, string direct,
                                                 string contractCode)
        {
            var result = client.IsolatedGetHisMatchExactAsync(contractCode, tradeType, start_time, end_time, from_id).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            string tp = null;
            if (contractCode != null)
            {
                tp = contractCode.Split("-")[1].ToUpper();
            }
            foreach (var item in result.data.trades)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }


        [Theory]
        [InlineData(0, null, null, null, 200, "prev", "BTC-USDT", null)]
        [InlineData(0, null, null, null, 200, "prev", null, "btc-usdt")]
        [InlineData(0, null, null, null, 200, "prev", "BTC-HUSD", null)]
        [InlineData(0, null, null, null, 200, "prev", null, "btc-husd")]
        public void CrossGetHisMatchExactTest(int tradeType, long? start_time, long? end_time,
                                              long? from_id, int size, string direct,
                                              string contractCode, string pair)
        {
            var result = client.CrossGetHisMatchExactAsync(tradeType, start_time, end_time, from_id, size, direct, contractCode, pair).Result;
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
            foreach (var item in result.data.trades)
            {
                Assert.Equal(tp, item.tradePartition);
            }
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, "sell", null, "lightning", "BTC-USDT")]
        [InlineData(1, "sell", null, "lightning", "BTC-HUSD")]
        public void IsolatedLightningCloseTest(double volume, string direction, 
                                       long? clientOrderId, string orderPriceType,
                                       string contractCode)
        {
            var result = client.IsolatedLightningCloseAsync(contractCode, volume, direction, clientOrderId, orderPriceType).Result;
            string strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

        [Theory]
        [InlineData(1, "sell", null, "lightning", "BTC-USDT", null, null)]
        [InlineData(1, "sell", null, "lightning", null, "swap", "BTC-USDT")]
        [InlineData(1, "sell", null, "lightning", "BTC-HUSD", null, null)]
        [InlineData(1, "sell", null, "lightning", null, "swap", "BTC-HUSD")]
        [InlineData(1, "sell", null, "lightning", null, "quarter", "BTC-HUSD")]
        public void CrossLightningCloseTest(double volume, string direction, 
                                       long? clientOrderId, string orderPriceType,
                                       string contractCode, string contractType, string pair)
        {
            var result = client.CrossLightningCloseAsync(volume, direction, clientOrderId, orderPriceType, contractCode, contractType, pair).Result;
            var strret = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(strret);
            Assert.Equal("ok", result.status);
            Console.WriteLine("------------");
        }

    }
}