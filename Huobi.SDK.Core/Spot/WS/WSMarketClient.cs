using Huobi.SDK.Core.Spot.WS.Response.Market;
using Huobi.SDK.Core.WSBase;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.WS
{
    public class WSMarketClient
    {
        private string host = null;
        private string path = null;
        private string mbp = null;

        public WSMarketClient(string host = Host.SPOT)
        {
            this.host = host;
            this.path = "/ws";
            this.mbp = "/feed";
        }

        #region kline
        public delegate void _OnSubKLineResponse(SubKLineResponse data);

        /// <summary>
        /// sub kline
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="period"></param>
        /// <param name="callbackFun"></param>
        public void SubKLine(string symbol, string period, _OnSubKLineResponse callbackFun)
        {
            string ch = $"market.{symbol}.kline.{period}";
            WSSubData subData = new WSSubData() { sub = ch };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubKLineResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

         #region ticker
        public delegate void _OnSubTickerResponse(SubTickerResponse data);

        /// <summary>
        /// sub kline
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        public void SubTicker(string symbol, _OnSubTickerResponse callbackFun)
        {
            string ch = $"market.{symbol}.ticker";
            WSSubData subData = new WSSubData() { sub = ch };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubTickerResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region depth
        public delegate void _OnSubDepthResponse(SubDepthResponse data);

        /// <summary>
        /// sub depth
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="type"></param>
        /// <param name="callbackFun"></param>
        public void SubDepth(string symbol, string type, _OnSubDepthResponse callbackFun)
        {
            string ch = $"market.{symbol}.depth.{type}";
            WSSubData subData = new WSSubData() { sub = ch };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubDepthResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region mbp
        public delegate void _OnSubMBPResponse(SubMBPResponse data);

        /// <summary>
        /// sub depth
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="levels"></param>
        /// <param name="beRefresh"></param>
        /// <param name="callbackFun"></param>
        public void SubMBP(string symbol, int levels, bool beRefresh, _OnSubMBPResponse callbackFun)
        {
            string path = this.mbp;
            string ch = $"market.{symbol}.mbp.{levels}";
            if (beRefresh)
            {
                path = this.path;
                ch = $"market.{symbol}.mbp.refresh.{levels}";
            }
            WSSubData subData = new WSSubData() { sub = ch };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(path, sub_str, callbackFun, typeof(SubMBPResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region bbo
        public delegate void _OnSubBBOResponse(SubBBOResponse data);

        /// <summary>
        /// sub detail
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        public void SubBBO(string symbol, _OnSubBBOResponse callbackFun)
        {
            string ch = $"market.{symbol}.bbo";
            WSSubData subData = new WSSubData() { sub = ch };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubBBOResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region trade detail
        public delegate void _OnSubTradeDetailResponse(SubTradeDetailResponse data);

        /// <summary>
        /// sub trade detail
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        public void SubTradeDetail(string symbol, _OnSubTradeDetailResponse callbackFun)
        {
            string ch = $"market.{symbol}.trade.detail";
            WSSubData subData = new WSSubData() { sub = ch};
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubTradeDetailResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region detail
        public delegate void _OnSubDetailResponse(SubDetailResponse data);

        /// <summary>
        /// sub detail
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        public void SubDetail(string symbol, _OnSubDetailResponse callbackFun)
        {
            string ch = $"market.{symbol}.detail";
            WSSubData subData = new WSSubData() { sub = ch };
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubDetailResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

        #region etp
        public delegate void _OnSubETPResponse(SubETPResponse data);

        /// <summary>
        /// sub trade detail
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="callbackFun"></param>
        public void SubDetail(string symbol, _OnSubETPResponse callbackFun)
        {
            string ch = $"market.{symbol}.etp";
            WSSubData subData = new WSSubData() { sub = ch};
            string sub_str = JsonConvert.SerializeObject(subData);

            WebSocketOp wsop = new WebSocketOp(this.path, sub_str, callbackFun, typeof(SubETPResponse), true, this.host);
            wsop.Connect();
        }
        #endregion

    }
}