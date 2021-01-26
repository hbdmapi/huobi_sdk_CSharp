using Huobi.SDK.Core.LinearSwap.WS.Response.Notify;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS
{
    public class WSNotifyClient : WebSocketOp
    {
        public WSNotifyClient(string accessKey = null, string secretKey = null, string host = DEFAULT_HOST) : 
               base("/linear-swap-notification", host, accessKey, secretKey)
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
        /// isolated margin sub orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void IsolatedSubOrders(string contractCode, _OnSubOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"orders.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// isolated margin unsub orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void IsolatedUnsubOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"orders.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }

        /// <summary>
        /// cross margin sub orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void CrossSubOrders(string contractCode, _OnSubOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"orders_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// cross margin unsub orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void CrossUnsubOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"orders_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region accounts
        public delegate void _OnSubAccountsResponse(SubAccountsResponse data);

        /// <summary>
        /// isolated margin sub accounts
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void IsolatedSubAcounts(string contractCode, _OnSubAccountsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubAccountsResponse));
        }

        /// <summary>
        /// isolated margin unsub accounts
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void IsolatedUnsubAccounts(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }

        /// <summary>
        /// cross margin sub accounts
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void CrossSubAcounts(string marginAccount, _OnSubAccountsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts_cross.{marginAccount}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubAccountsResponse));
        }

        /// <summary>
        /// cross margin unsub accounts
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="cid"></param>
        public void CrossUnsubAccounts(string marginAccount, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts_cross.{marginAccount}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region positions
        public delegate void _OnSubPositionsResponse(SubPositionsResponse data);

        /// <summary>
        /// isolated margin sub positions
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void IsolatedSubPositions(string contractCode, _OnSubPositionsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"positions.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubPositionsResponse));
        }

        /// <summary>
        /// isolated margin unsub positions
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void IsolatedUnsubPositions(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"positions.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }

        /// <summary>
        /// cross margin sub positions
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void CrossSubPositions(string contractCode, _OnSubPositionsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"positions_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubPositionsResponse));
        }

        /// <summary>
        /// cross margin unsub positions
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void CrossUnsubPositions(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"positions_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region match orders
        public delegate void _OnSubMatchOrdersResponse(SubOrdersResponse data);

        /// <summary>
        /// isolated margin sub match orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void IsolatedSubMatchOrders(string contractCode, _OnSubMatchOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            contractCode = contractCode.ToLower();
            string ch = $"matchOrders.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// isolated margin unsub match orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void IsolatedUnsubMathOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            contractCode = contractCode.ToLower();
            string ch = $"matchOrders.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }

        /// <summary>
        /// cross margin sub match orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void CrossSubMatchOrders(string contractCode, _OnSubMatchOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            contractCode = contractCode.ToLower();
            string ch = $"matchOrders_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// cross margin unsub match orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void CrossUnsubMathOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            contractCode = contractCode.ToLower();
            string ch = $"matchOrders_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region liquidation orders
        public delegate void _OnSubLiquidationOrdersResponse(SubLiquidationOrdersResponse data);

        /// <summary>
        /// sub liquidation orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubLiquidationOrders(string contractCode, _OnSubLiquidationOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{contractCode}.liquidation_orders";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubLiquidationOrdersResponse));
        }

        /// <summary>
        /// unsub liquidation orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubLiquidationOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{contractCode}.liquidation_orders";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region funding rate
        public delegate void _OnSubFundingRateResponse(SubFundingRateResponse data);

        /// <summary>
        /// sub funding rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubFundingRate(string contractCode, _OnSubFundingRateResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{contractCode}.funding_rate";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubFundingRateResponse));
        }

        /// <summary>
        /// unsub funding rate
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubFundingRate(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{contractCode}.funding_rate";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region fcontract info
        public delegate void _OnSubContractInfoResponse(SubContractInfoResponse data);

        /// <summary>
        /// sub contract info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubContractInfo(string contractCode, _OnSubContractInfoResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{contractCode}.contract_info";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubContractInfoResponse));
        }

        /// <summary>
        /// unsub contract info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubContractInfo(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"public.{contractCode}.contract_info";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region trigger order
        public delegate void _OnSubTriggerOrderResponse(SubTriggerOrderResponse data);

        /// <summary>
        /// isolated margin sub trigger order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void IsolatedSubTriggerOrder(string contractCode, _OnSubTriggerOrderResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubTriggerOrderResponse));
        }

        /// <summary>
        /// isolated margin unsub trigger order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void IsolatedUnsubTriggerOrder(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }

        /// <summary>
        /// cross margin sub trigger order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void CrossSubTriggerOrder(string contractCode, _OnSubTriggerOrderResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubTriggerOrderResponse));
        }

        /// <summary>
        /// cross margin unsub trigger order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void CrossUnsubTriggerOrder(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order_cross.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

    }
}