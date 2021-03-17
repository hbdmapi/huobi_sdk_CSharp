using Huobi.SDK.Core.Futures.WS.Response.System;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS
{
    public class WSSystemClient : WebSocketOp
    {
        public WSSystemClient(string host = DEFAULT_HOST) : base("/center-notification", host)
        {
            Connect(true);
        }

        ~WSSystemClient()
        {
            Disconnect();
        }
        private const string _DEFAULT_CID = "cid";

        #region heartbeat
        public delegate void _OnSubHeartBeatResponse(SubHeartBeatResponse data);

        /// <summary>
        /// sub heart beat
        /// </summary>
        /// <param name="callbackFun"></param>
        /// <param name="cid"></param>
        public void SubHeartBeat(_OnSubHeartBeatResponse callbackFun, string cid = _DEFAULT_CID)
        {
            string ch = $"public.futures.heartbeat";
            WSOpData subData = new WSOpData() { op = "sub", topic = ch, cid = cid };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubHeartBeatResponse));
        }
        #endregion
    }
}