using Huobi.SDK.Core.CoinSwap.WS.Response.System;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.CoinSwap.WS
{
    public class WSSystemClient
    {
        private string host = null;
        private string path = null;
        private const string _DEFAULT_CID = "cid";

        public WSSystemClient(string host = WebSocketOp.DEFAULT_HOST)
        {
            this.host = host;
            this.path = "/center-notification";
        }

        #region heartbeat
        public delegate void _OnSubHeartBeatResponse(SubHeartBeatResponse data);

        /// <summary>
        /// sub heart beat
        /// </summary>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubHeartBeat(_OnSubHeartBeatResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.linear-swap.heartbeat";
            WSOpData subData = new WSOpData() { op = "sub", topic = ch, cid = cid };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubHeartBeatResponse), true, this.host);
            wsop.Connect();
        }
        #endregion
    }
}