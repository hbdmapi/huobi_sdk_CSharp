using System;
using System.Threading;
using Huobi.SDK.Core.WSBase;
using Xunit;

namespace Huobi.SDK.Core.Test
{
    public class WsOpTest
    {
        [Fact]
        public void SubTest()
        {
            string sub_str = "{\"sub\": \"market.BTC-USDT.kline.1min\"}";
            string path = "/linear-swap-ws";
            string host = "api.hbdm.vn";

            WebSocketOp wsop = new WebSocketOp(path, sub_str, null, null, true, host);
            wsop.Connect();

            while(true)
            {
                Thread.Sleep(1);
            }
        }
    }
}
