using Huobi.SDK.Core.Futures.WS.Response.Index;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.WS
{
    public class WSIndexClient
    {
        private string host = null;
        private string path = null;
        private const string _DEFAULT_ID = "api";

        public WSIndexClient(string host = WebSocketOp.DEFAULT_HOST)
        {
            this.host = host;
            this.path = "/ws_index";
        }

        #region index kline
        public delegate void _OnSubIndexKLineResponse(SubIndexKLineResponse data);
        public delegate void _OnReqIndexKLineResponse(ReqIndexKLineResponse data);

        /// <summary>
        /// sub index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubIndexKLine(string contractCode, string period, _OnSubIndexKLineResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.index.{period}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubIndexKLineResponse), true, this.host);
            wsop.Connect();
        }

        /// <summary>
        /// req index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="id"></param>
        public void ReqIndexKLine(string contractCode, string period, _OnReqIndexKLineResponse callbackFun, long from, long to, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.index.{period}";
            WSReqData reqData = new WSReqData() { req = ch, id = id, from = from, to = to };
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqIndexKLineResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region premium index kline
        public delegate void _OnSubPremiumIndexKLineResponse(SubIndexKLineResponse data);
        public delegate void _OnReqPremiumIndexKLineResponse(ReqIndexKLineResponse data);

        /// <summary>
        /// sub premium index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubPremiumIndexKLine(string contractCode, string period, _OnSubPremiumIndexKLineResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.premium_index.{period}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubIndexKLineResponse), true, this.host);
            wsop.Connect();
        }

        /// <summary>
        /// req premium index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="id"></param>
        public void ReqPremiumIndexKLine(string contractCode, string period, _OnReqPremiumIndexKLineResponse callbackFun, long from, long to, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.premium_index.{period}";
            WSReqData reqData = new WSReqData() { req = ch, id = id, from = from, to = to };
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqIndexKLineResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region estimated rate kline
        public delegate void _OnSubEstimatedRateResponse(SubIndexKLineResponse data);
        public delegate void _OnReqEstimatedRateResponse(ReqIndexKLineResponse data);

        /// <summary>
        /// sub premium index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubEstimatedRateKLine(string contractCode, string period, _OnSubEstimatedRateResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.estimated_rate.{period}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubIndexKLineResponse), true, this.host);
            wsop.Connect();
        }

        /// <summary>
        /// req premium index kline
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="id"></param>
        public void ReqEstimatedRateKLine(string contractCode, string period, _OnReqEstimatedRateResponse callbackFun, long from, long to, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.estimated_rate.{period}";
            WSReqData reqData = new WSReqData() { req = ch, id = id, from = from, to = to };
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqIndexKLineResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region basis
        public delegate void _OnSubBasisResponse(SubBasiesResponse data);
        public delegate void _OnReqBasisResponse(ReqBasisResponse data);

        /// <summary>
        /// sub basis
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="basisPriceType"></param>
        /// <param name="id"></param>
        public void SubBasis(string contractCode, string period, _OnSubBasisResponse callbackFun, string basisPriceType = "open", string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.basis.{period}.{basisPriceType}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubBasiesResponse), true, this.host);
            wsop.Connect();
        }

        /// <summary>
        /// req basis
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="basisPriceType"></param>
        /// <param name="id"></param>
        public void ReqBasis(string contractCode, string period, _OnReqBasisResponse callbackFun, long from, long to,
                             string basisPriceType = "open", string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.basis.{period}.{basisPriceType}";
            WSReqData reqData = new WSReqData() { req = ch, id = id, from = from, to = to };
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqBasisResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region mark price kline
        public delegate void _OnSubMarkPriceKLineResponse(SubIndexKLineResponse data);
        public delegate void _OnReqMarkPriceKLineResponse(ReqIndexKLineResponse data);

        /// <summary>
        /// Sub Mark Price KLine
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="id"></param>
        public void SubMarkPriceKLine(string contractCode, string period, _OnSubMarkPriceKLineResponse callbackFun, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.mark_price.{period}";
            WSSubData subData = new WSSubData() { sub = ch, id = id };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubIndexKLineResponse), true, this.host);
            wsop.Connect();
        }

        /// <summary>
        /// Requst Mark Price KLine
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="id"></param>
        public void ReqMarkPriceKLine(string contractCode, string period, _OnReqMarkPriceKLineResponse callbackFun, long from, long to, string id = _DEFAULT_ID)
        {
            string ch = $"market.{contractCode}.mark_price.{period}";
            WSReqData reqData = new WSReqData() { req = ch, id = id, from = from, to = to };
            string sub_str = JsonConvert.SerializeObject(reqData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(ReqIndexKLineResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

    }
}