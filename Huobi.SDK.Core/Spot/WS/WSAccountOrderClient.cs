using System.Collections.Generic;
using Huobi.SDK.Core.Spot.WS.Response.AccountOrder;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.WS
{
    public class WSAccountOrderClient
    {
        private string host = null;
        private string path = null;
        private string accessKey = null;
        private string secretKey = null;

        public WSAccountOrderClient(string accessKey, string secretKey, string host = Host.SPOT)
        {
            this.host = host;
            this.path = "/ws/v2";
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }

        #region orders
        public delegate void _OnSubOrdersResponse(SubOrdersResponse data);

        /// <summary>
        /// sub orders
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        public void SubOrders(string symbol, _OnSubOrdersResponse callbackFun)
        {
            string ch = $"orders#{symbol}";
            WSActionData actionData = new WSActionData { action = "sub", ch = ch };
            string sub_str = JsonConvert.SerializeObject(actionData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubOrdersResponse), true, this.host,
                                               this.accessKey, this.secretKey, true);
            wsop.Connect();
        }
        #endregion

        #region trade clearing
        public delegate void _OnSubTradeClearingResponse(SubTradeClearingResponse data);

        /// <summary>
        /// sub trade clearing
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="mode"></param>
        /// <param name="callbackFun"></param>
        public void SubTradeClearing(string symbol, int mode, _OnSubTradeClearingResponse callbackFun)
        {
            string ch = $"trade.clearing#{symbol}#{mode}";
            WSActionData actionData = new WSActionData { action = "sub", ch = ch };
            string sub_str = JsonConvert.SerializeObject(actionData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubTradeClearingResponse), true, this.host,
                                               this.accessKey, this.secretKey, true);
            wsop.Connect();
        }
        #endregion

        #region accounts update
        public delegate void _OnSubAccountResponse(SubAccountResponse data);

        /// <summary>
        /// sub match orders
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="callbackFun"></param>
        public void SubMatchOrders(string mode, _OnSubAccountResponse callbackFun)
        {
            string ch = $"accounts.update#{mode}";
            WSActionData actionData = new WSActionData { action = "sub", ch = ch };
            string sub_str = JsonConvert.SerializeObject(actionData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubAccountResponse), true, this.host,
                                               this.accessKey, this.secretKey, true);
            wsop.Connect();
        }
        #endregion
    }
}