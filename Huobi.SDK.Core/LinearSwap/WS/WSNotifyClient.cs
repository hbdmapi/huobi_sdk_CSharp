using System.Collections.Generic;
using Huobi.SDK.Core.LinearSwap.WS.Response.Notify;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS
{
    public class WSNotifyClient
    {
        private string host = null;
        private string path = null;
        private string accessKey = null;
        private string secretKey = null;
        private const string _DEFAULT_CID = "cid";
        private Dictionary<string, WebSocketOp> allWsop = new Dictionary<string, WebSocketOp>();

        public WSNotifyClient(string accessKey = null, string secretKey = null, string host = Host.FUTURES)
        {
            this.host = host;
            this.path = "/linear-swap-notification";
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }

        ~WSNotifyClient()
        {
            foreach (var item in allWsop)
            {
                item.Value.Disconnect();
            }
            allWsop.Clear();
        }

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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubOrdersResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubOrdersResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
        }
        #endregion

        #region accounts
        public delegate void _OnIsolatedSubAccountsResponse(IsolatedSubAccountsResponse data);
        public delegate void _OnCrossSubAccountsResponse(CrossSubAccountsResponse data);

        /// <summary>
        /// isolated margin sub accounts
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void IsolatedSubAcounts(string contractCode, _OnIsolatedSubAccountsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts.{contractCode}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(IsolatedSubAccountsResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
        }

        /// <summary>
        /// cross margin sub accounts
        /// </summary>
        /// <param name="marginAccount"></param>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void CrossSubAcounts(string marginAccount, _OnCrossSubAccountsResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"accounts_cross.{marginAccount}";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch };
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(CrossSubAccountsResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubPositionsResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubPositionsResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubOrdersResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubOrdersResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
        /// <param name="businessType"></param>
        public void SubLiquidationOrders(string contractCode, _OnSubLiquidationOrdersResponse callbackFun, string cid = _DEFAULT_CID,
                                         string businessType = null)
        {
            string ch = $"public.{contractCode}.liquidation_orders";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch, businessType = businessType };
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubLiquidationOrdersResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
        }

        /// <summary>
        /// unsub liquidation orders
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        /// <param name="businessType"></param>
        public void UnsubLiquidationOrders(string contractCode, string cid = _DEFAULT_CID,
                                           string businessType = null)
        {
            string ch = $"public.{contractCode}.liquidation_orders";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch, businessType = businessType };
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubFundingRateResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
        /// <param name="businessType"></param>
        public void SubContractInfo(string contractCode, _OnSubContractInfoResponse callbackFun, string cid = _DEFAULT_CID,
                                    string businessType = null)
        {
            string ch = $"public.{contractCode}.contract_info";
            WSOpData opData = new WSOpData { op = "sub", cid = cid, topic = ch, businessType = businessType };
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubContractInfoResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
        }

        /// <summary>
        /// unsub contract info
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="cid"></param>
        /// <param name="businessType"></param>
        public void UnsubContractInfo(string contractCode, string cid = _DEFAULT_CID, string businessType = null)
        {
            string ch = $"public.{contractCode}.contract_info";
            WSOpData opData = new WSOpData { op = "unsub", cid = cid, topic = ch, businessType = businessType };
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubTriggerOrderResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
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
            string sub_str = JsonConvert.SerializeObject(opData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubTriggerOrderResponse), true, this.host,
                                            this.accessKey, this.secretKey);
            wsop.Connect();
            if (!allWsop.ContainsKey(ch))
            {
                allWsop.Add(ch, wsop);
            }
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
            string unsub_str = JsonConvert.SerializeObject(opData);

            if(!allWsop.ContainsKey(ch))
            {
                return;
            }
            allWsop[ch].SendMsg(unsub_str);
            allWsop.Remove(ch);
        }
        #endregion

    }
}