using Huobi.SDK.Core.Futures.WS.Response.Market;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS
{
    public class WSMarketClient
    {
        private string host = null;
        private string path = null;
        private const string _DEFAULT_ID = "api";

        public WSMarketClient(string host = WebSocketOp.DEFAULT_HOST)
        {
            this.host = host;
            this.path = "/ws";
        }

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
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubKLineResponse), true, this.host);
            wsop.Connect();
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
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqKLineResponse), true, this.host);
            wsop.Connect();
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
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubDepthResponse), true, this.host);
            wsop.Connect();
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
            WSSubData subData = new WSSubData() { sub = ch, id = id, dataType = "incremental"};
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubDepthResponse), true, this.host);
            wsop.Connect();
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
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubKLineResponse), true, this.host);
            wsop.Connect();
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
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubBBOResponse), true, this.host);
            wsop.Connect();
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
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubTradeDetailResponse), true, this.host);
            wsop.Connect();
        }

        /// <summary>
        /// req trade detail
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="callbackFun"></param>
        /// <param name="size"></param>
        /// <param name="id"></param>
        public void ReqTradeDetail(string contractCode, _OnReqTradeDetailResponse callbackFun, int size = 50, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.trade.detail";
            WSReqData reqData = new WSReqData() { req = ch, size = size, id = id};
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqTradeDetailResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

    }
}