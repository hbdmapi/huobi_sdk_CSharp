using Huobi.SDK.Core.LinearSwap.WS.Response.Market;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS
{
    public class WSMarketClient : WebSocketOp
    {
        public WSMarketClient(string host = DEFAULT_HOST) : base("/linear-swap-ws", host)
        {
            Connect(true);
        }

        ~WSMarketClient()
        {
            Disconnect();
        }
        private const string _DEFAULT_ID = "api";

        #region kline
        public delegate void _OnSubKLineResponse(SubKLineResponse data);
        public delegate void _OnReqKLineResponse(ReqKLineResponse data);

        /// <summary>
        /// sub kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubKLine(string contractCode, string period, _OnSubKLineResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.kline.{period}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubKLineResponse));
        }

        /// <summary>
        /// unsub kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        public void UnsubKLine(string contractCode, string period, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.kline.{period}";
            WSUnsubData unsubData = new WSUnsubData { unsub = ch, id = id };

            Unsub(JsonConvert.SerializeObject(unsubData), ch);
        }

        /// <summary>
        /// req kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="id"></param>
        public void ReqKLine(string contractCode, string period, _OnReqKLineResponse callbackFun, long from, long to, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.kline.{period}";
            WSReqData reqData = new WSReqData() { req = ch, id = id, from = from, to = to };

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqKLineResponse));
        }

        /// <summary>
        /// unreq kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="id"></param>
        public void UnreqKLine(string contractCode, string period, long from, long to, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.kline.{period}";
            WSUnreqData reqData = new WSUnreqData() { unreq = ch, id = id, from = from, to = to };

            Unreq(JsonConvert.SerializeObject(reqData), ch);
        }
        #endregion

        #region depth
        public delegate void _OnSubDepthResponse(SubDepthResponse data);

        /// <summary>
        /// sub depth
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="type"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubDepth(string contractCode, string type, _OnSubDepthResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.depth.{type}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubDepthResponse));
        }

        /// <summary>
        /// unsub depth
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="id"></param>
        public void UnSubDepth(string contractCode, string period, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.depth.{period}";
            WSUnsubData unsubData = new WSUnsubData { unsub = ch, id = id };

            Unsub(JsonConvert.SerializeObject(unsubData), ch);
        }

        /// <summary>
        /// sub incrementa depth
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="size"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubIncrementalDepth(string contractCode, string size, _OnSubDepthResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.depth.size_{size}.high_freq";
            WSSubData subData = new WSSubData() { sub = ch, id = id };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubDepthResponse));
        }

        /// <summary>
        /// unsub incrementa depth
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="size"></param>
        /// <param name="id"></param>
        public void UnSubIncrementaDepth(string contractCode, string size, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.depth.size_{size}.high_freq";
            WSUnsubData unsubData = new WSUnsubData { unsub = ch, id = id };

            Unsub(JsonConvert.SerializeObject(unsubData), ch);
        }
        #endregion

        #region detail
        public delegate void _OnSubDetailResponse(SubKLineResponse data);

        /// <summary>
        /// sub detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubDetail(string contractCode, _OnSubDetailResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.detail";
            WSSubData subData = new WSSubData() { sub = ch, id = id };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubKLineResponse));
        }
        
        /// <summary>
        /// unsub detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="id"></param>
        public void UnsubDetail(string contractCode, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.detail";
            WSUnsubData unsubData = new WSUnsubData { unsub = ch, id = id };

            Unsub(JsonConvert.SerializeObject(unsubData), ch);
        }
        #endregion

        #region bbo
        public delegate void _OnSubBBOResponse(SubBBOResponse data);

        /// <summary>
        /// sub detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubBBO(string contractCode, _OnSubBBOResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.bbo";
            WSSubData subData = new WSSubData() { sub = ch, id = id };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubBBOResponse));
        }
        
        /// <summary>
        /// unsub detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="id"></param>
        public void UnsubBBO(string contractCode, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.bbo";
            WSUnsubData unsubData = new WSUnsubData { unsub = ch, id = id };

            Unsub(JsonConvert.SerializeObject(unsubData), ch);
        }
        #endregion

        #region trade detail
        public delegate void _OnSubTradeDetailResponse(SubTradeDetailResponse data);
        public delegate void _OnReqTradeDetailResponse(ReqTradeDetailResponse data);

        /// <summary>
        /// sub trade detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubTradeDetail(string contractCode, _OnSubTradeDetailResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.trade.detail";
            WSSubData subData = new WSSubData() { sub = ch, id = id };

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubTradeDetailResponse));
        }

        /// <summary>
        /// unsub trade detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="id"></param>
        public void UnsubTradeDetail(string contractCode, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.trade.detail";
            WSUnsubData unsubData = new WSUnsubData { unsub = ch, id = id };

            Unsub(JsonConvert.SerializeObject(unsubData), ch);
        }

        /// <summary>
        /// req trade detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void ReqTradeDetail(string contractCode, _OnReqTradeDetailResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.trade.detail";
            WSReqData reqData = new WSReqData() { req = ch, id = id};

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqTradeDetailResponse));
        }

        /// <summary>
        /// unreq trade detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="id"></param>
        public void UnreqTradeDetail(string contractCode, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.trade.detail";
            WSUnreqData reqData = new WSUnreqData() { unreq = ch, id = id};

            Unreq(JsonConvert.SerializeObject(reqData), ch);
        }
        #endregion

    }
}