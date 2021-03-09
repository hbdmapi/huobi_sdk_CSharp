using Huobi.SDK.Core.LinearSwap.WS.Response.Index;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.WS
{
    public class WSIndexClient : WebSocketOp
    {
        public WSIndexClient(string host = DEFAULT_HOST) : base("/ws_index", host)
        {
            Connect(true);
        }

        ~WSIndexClient()
        {
            Disconnect();
        }
        private const string _DEFAULT_ID = "api";

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

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubIndexKLineResponse));
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

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqIndexKLineResponse));
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

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubIndexKLineResponse));
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

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqIndexKLineResponse));
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

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubIndexKLineResponse));
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

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqIndexKLineResponse));
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

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubBasiesResponse));
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

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqBasisResponse));
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

            Sub(JsonConvert.SerializeObject(subData), ch, callbackFun, typeof(SubIndexKLineResponse));
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

            Req(JsonConvert.SerializeObject(reqData), ch, callbackFun, typeof(ReqIndexKLineResponse));
        }
        #endregion

    }
}