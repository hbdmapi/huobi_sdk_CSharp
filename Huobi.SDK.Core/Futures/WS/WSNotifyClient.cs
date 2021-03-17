using Huobi.SDK.Core.Futures.WS.Response.Notify;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS
{
    public class WSNotifyClient : WebSocketOp
    {
        public WSNotifyClient(string accessKey = null, string secretKey = null, string host = DEFAULT_HOST) :
               base("/notification", host, accessKey, secretKey)
        {
            Connect(true);
        }

        ~WSNotifyClient()
        {
            Disconnect();
        }
        private const string _DEFAULT_CID = "cid";

        #region orders
        public delegate void _OnSubOrdersResponse(SubOrdersResponse data);

        /// <summary>
        /// sub orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubOrders(string symbol, _OnSubOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"orders.{symbol}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// unsub orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubOrders(string symbol, string cid = _DEFAULT_CID)
        {
            string ch = $"orders.{symbol}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region match orders
        public delegate void _OnSubMatchOrdersResponse(SubOrdersResponse data);

        /// <summary>
        /// sub match orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubMatchOrders(string symbol, _OnSubMatchOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            symbol = symbol.ToLower();
            string ch = $"matchOrders.{symbol}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// unsub match orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubMathOrders(string symbol, string cid = _DEFAULT_CID)
        {
            symbol = symbol.ToLower();
            string ch = $"matchOrders.{symbol}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region accounts
        public delegate void _OnSubAccountsResponse(SubAccountsResponse data);

        /// <summary>
        /// sub accounts
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubAcounts(string symbol, _OnSubAccountsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{symbol}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubAccountsResponse));
        }

        /// <summary>
        /// unsub accounts
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubAccounts(string symbol, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{symbol}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion


        #region positions
        public delegate void _OnSubPositionsResponse(SubPositionsResponse data);

        /// <summary>
        /// sub positions
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubPositions(string symbol, _OnSubPositionsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"positions.{symbol}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubPositionsResponse));
        }

        /// <summary>
        /// unsub positions
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubPositions(string symbol, string cid = _DEFAULT_CID)
        {
            string ch = $"positions.{symbol}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region liquidation orders
        public delegate void _OnSubLiquidationOrdersResponse(SubLiquidationOrdersResponse data);

        /// <summary>
        /// sub liquidation orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubLiquidationOrders(string symbol, _OnSubLiquidationOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{symbol}.liquidation_orders";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubLiquidationOrdersResponse));
        }

        /// <summary>
        /// unsub liquidation orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubLiquidationOrders(string symbol, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{symbol}.liquidation_orders";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region contract info
        public delegate void _OnSubContractInfoResponse(SubContractInfoResponse data);

        /// <summary>
        /// sub contract info
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubContractInfo(string symbol, _OnSubContractInfoResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{symbol}.contract_info";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubContractInfoResponse));
        }

        /// <summary>
        /// unsub contract info
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubContractInfo(string symbol, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{symbol}.contract_info";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region trigger order
        public delegate void _OnSubTriggerOrderResponse(SubTriggerOrderResponse data);

        /// <summary>
        /// sub trigger order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubTriggerOrder(string symbol, _OnSubTriggerOrderResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order.{symbol}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubTriggerOrderResponse));
        }

        /// <summary>
        /// unsub trigger order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cid"></param>
        public void UnsubTriggerOrder(string symbol, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order.{symbol}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

    }
}