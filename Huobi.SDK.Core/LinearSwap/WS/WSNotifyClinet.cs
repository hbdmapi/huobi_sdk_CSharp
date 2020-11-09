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
        /// sub orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubOrders(string contractCode, _OnSubOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"orders.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// unsub orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"orders.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region accounts
        public delegate void _OnSubAccountsResponse(SubAccountsResponse data);

        /// <summary>
        /// sub accounts
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubAcounts(string contractCode, _OnSubAccountsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubAccountsResponse));
        }

        /// <summary>
        /// unsub accounts
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubAccounts(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region positions
        public delegate void _OnSubPositionsResponse(SubPositionsResponse data);

        /// <summary>
        /// sub positions
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubPositions(string contractCode, _OnSubPositionsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"positions.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubPositionsResponse));
        }

        /// <summary>
        /// unsub positions
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubPositions(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"positions.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

        #region match orders
        public delegate void _OnSubMatchOrdersResponse(SubOrdersResponse data);

        /// <summary>
        /// sub match orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubMatchOrders(string contractCode, _OnSubMatchOrdersResponse callbackFun, string cid = _DEFAULT_CID)
        {
            contractCode = contractCode.ToLower();
            string ch = $"matchOrders.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubOrdersResponse));
        }

        /// <summary>
        /// unsub match orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubMathOrders(string contractCode, string cid = _DEFAULT_CID)
        {
            contractCode = contractCode.ToLower();
            string ch = $"matchOrders.{contractCode}";
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
        /// sub trigger order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubTriggerOrder(string contractCode, _OnSubTriggerOrderResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };

            Sub(JsonConvert.SerializeObject(opData), ch, callbackFun, typeof(SubTriggerOrderResponse));
        }

        /// <summary>
        /// unsub trigger order
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        public void UnsubTriggerOrder(string contractCode, string cid = _DEFAULT_CID)
        {
            string ch = $"trigger_order.{contractCode}";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch };

            Unsub(JsonConvert.SerializeObject(opData), ch);
        }
        #endregion

    }
}