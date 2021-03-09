using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebSocketSharp;
using Huobi.SDK.Core.Log;
using System.Collections.Generic;
using System.Text;
using Huobi.SDK.Core.RequestBuilder;
using System.Web;

namespace Huobi.SDK.Core.WSBase
{

    public class WebSocketOp
    {
        protected ILogger _logger = new ConsoleLogger();

        protected const string DEFAULT_HOST = "api.btcgateway.pro";
        private string _host;
        private string _path;

        protected WebSocket _WebSocket;
        private string _accessKey;
        private string _secretKey;
        private bool _canWork = false;

        protected bool? _autoConnect = null;
        private List<string> _all_sub_strs = new List<string>();

        public class MethonInfo
        {
            public Delegate fun;
            public Type paramType;
        }

        private Dictionary<string, MethonInfo> _onSubCallbackFuns = new Dictionary<string, MethonInfo>();
        private Dictionary<string, MethonInfo> _onReqCallbackFuns = new Dictionary<string, MethonInfo>();

        /// <summary>
        /// construct
        /// </summary>
        /// <param name="path"></param>
        /// <param name="host"></param>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        protected WebSocketOp(string path, string host = DEFAULT_HOST, string accessKey = null, string secretKey = null)
        {
            _host = host;
            _path = path;

            InitializeWebSocket(host, path);

            _accessKey = accessKey;
            _secretKey = secretKey;
        }

        ~WebSocketOp()
        {
            DisposeWebSocket();
        }

        /// <summary>
        /// init websocket
        /// </summary>
        /// <param name="host"></param>
        /// <param name="path"></param>
        private void InitializeWebSocket(string host, string path)
        {
            _WebSocket = new WebSocket($"wss://{_host}{_path}");
            _WebSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;

            _WebSocket.OnOpen += _WebSocket_OnOpen;
            _WebSocket.OnClose += _WebSocket_OnClose;
            _WebSocket.OnMessage += _WebSocket_OnMessage;
            _WebSocket.OnError += _WebSocket_OnError;
        }

        /// <summary>
        /// dispose websocket
        /// </summary>
        private void DisposeWebSocket()
        {
            _WebSocket.OnOpen -= _WebSocket_OnOpen;
            _WebSocket.OnClose -= _WebSocket_OnClose;
            _WebSocket.OnMessage -= _WebSocket_OnMessage;
            _WebSocket.OnError -= _WebSocket_OnError;

            _WebSocket.Close(CloseStatusCode.Normal);
            _WebSocket = null;
            _canWork = false;
        }

        /// <summary>
        /// connect websocket server
        /// </summary>
        /// <param name="Connect"></param>
        protected void Connect(bool? autoConnect = null)
        {
            if (autoConnect != null && _autoConnect == null)
            {
                _autoConnect = autoConnect;
            }
            _WebSocket.Connect();
        }

        /// <summary>
        /// disconnect websocket server
        /// </summary>
        protected void Disconnect()
        {
            DisposeWebSocket();
        }

        /// <summary>
        /// websocket open handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WebSocket_OnOpen(object sender, EventArgs e)
        {
            _logger.Log(Log.LogLevel.Info, "WebSocket opened");
            _canWork = true;

            if (_accessKey != null && _secretKey != null)
            {
                string timestamp = DateTime.UtcNow.ToString("s");
                var sign = new Signer(_secretKey);

                var req = new GetRequest()
                    .AddParam("AccessKeyId", _accessKey)
                    .AddParam("SignatureMethod", "HmacSHA256")
                    .AddParam("SignatureVersion", "2")
                    .AddParam("Timestamp", timestamp);

                string signature = sign.Sign("GET", _host, _path, req.BuildParams());
                WSAuthData auth = new WSAuthData() { accessKeyId = _accessKey, signature = signature, timestamp = timestamp };

                string auth_str = JsonConvert.SerializeObject(auth);
                _WebSocket.Send(auth_str);
                _all_sub_strs.Add(auth_str);
                _canWork = false;
            }
        }

        /// <summary>
        /// websocker close handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WebSocket_OnClose(object sender, EventArgs e)
        {
            _logger.Log(Log.LogLevel.Info, "WebSocket close.");

            if (_WebSocket == null)
            {
                return;
            }

            if (_autoConnect == true)
            {
                DisposeWebSocket();
                InitializeWebSocket(_path, _host);
                Connect(_autoConnect);
                foreach(string item in _all_sub_strs)
                {
                    _WebSocket.Send(item);
                }
            }
        }

        /// <summary>
        /// reply msg handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            string data = null;
            if (e.IsBinary)
            {
                data = GZipDecompresser.Decompress(e.RawData);
            }
            else
            {
                data = e.Data;
            }

            JObject jdata = JObject.Parse(data);
            if (jdata.ContainsKey("ping"))// market heartbeat
            {
                long ts = jdata["ping"].ToObject<long>();

                //_logger.Log(Log.LogLevel.Debug, $"WebSocket received data: \"ping\":{ts}");

                string pongData = $"{{\"pong\":{ts} }}";
                _WebSocket.Send(pongData);

                //_logger.Log(Log.LogLevel.Debug, $"WebSocket replied data: {pongData}");
            }
            else if (jdata.ContainsKey("op"))
            {
                string op = jdata["op"].ToObject<string>();
                switch (op)
                {
                    case "ping": // order heartbeat
                        string ts = jdata["ts"].ToObject<string>();
                        //_logger.Log(Log.LogLevel.Debug, $"WebSocket received data, {{ \"op\":\"{op}\", \"ts\": \"{ts}\" }}");

                        string pongData = $"{{ \"op\":\"pong\", \"ts\":{ts} }}";
                        _WebSocket.Send(pongData);

                        //_logger.Log(Log.LogLevel.Debug, $"WebSocket replied data, {pongData}");
                        break;

                    case "close":
                        _logger.Log(Log.LogLevel.Error, $"Some error occurres when authentication in server side.");
                        break;

                    case "error":
                        _logger.Log(Log.LogLevel.Trace, $"Illegal op or internal error, but websoket is still connected.");
                        break;

                    case "auth":
                        int code = jdata["err-code"].ToObject<int>();
                        if (code == 0)
                        {
                            _logger.Log(Log.LogLevel.Info, $"Authentication success.");
                            _canWork = true;
                        }
                        else
                        {
                            _logger.Log(Log.LogLevel.Info, $"Authentication failure: {jdata["err-code"]}/{jdata["err-msg"]}");
                        }
                        break;
                    case "notify":
                        _HandleSubCallbackFun(jdata["topic"].ToObject<string>(), data, jdata);
                        break;
                    case "sub":
                        _logger.Log(Log.LogLevel.Info, $"sub: \"{jdata["topic"]}\"");
                        break;
                    case "unsub":
                        _logger.Log(Log.LogLevel.Info, $"unsub: \"{jdata["topic"]}\"");
                        string ch = jdata["topic"].ToObject<string>();
                        if (_onSubCallbackFuns.ContainsKey(ch))
                        {
                            _onSubCallbackFuns.Remove(ch);
                        }
                        break;
                    default:
                        _logger.Log(Log.LogLevel.Info, $"WebSocket received unknow data: {jdata}");
                        break;
                }
            }
            else if (jdata.ContainsKey("subbed")) // sub success reply
            {
                _logger.Log(Log.LogLevel.Info, $"\"subbed\": \"{jdata["subbed"]}\"");
            }
            else if (jdata.ContainsKey("unsubbed")) // unsub success reply
            {
                _logger.Log(Log.LogLevel.Info, $"\"unsubbed\": \"{jdata["unsubbed"]}\"");
                string ch = jdata["unsubbed"].ToObject<string>();
                if (_onSubCallbackFuns.ContainsKey(ch))
                {
                    _onSubCallbackFuns.Remove(ch);
                }
            }
            else if (jdata.ContainsKey("ch")) // market sub reply data
            {
                _HandleSubCallbackFun(jdata["ch"].ToObject<string>(), data, jdata);
            }
            else if (jdata.ContainsKey("rep")) // market request reply data
            {
                _HandleReqCallbackFun(jdata["rep"].ToObject<string>(), data, jdata);
            }
            else if (jdata.ContainsKey("err-code")) // market request reply data
            {
                _logger.Log(Log.LogLevel.Info, $"{jdata["err-code"]}:{jdata["err-msg"]}");
            }
            else
            {
                _logger.Log(Log.LogLevel.Info, $"WebSocket received unknow data: {jdata}");
            }
        }
        
        /// <summary>
        /// handle sub callback fun
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="data"></param>
        /// <param name="jdata"></param>
        private void _HandleSubCallbackFun(string ch, string data, JObject jdata)
        {
            ch = ch.ToLower();

            MethonInfo mi = null;
            if (_onSubCallbackFuns.ContainsKey(ch))
            {
                mi = _onSubCallbackFuns[ch];
            }
            else if (ch.StartsWith("orders.") && _onSubCallbackFuns.ContainsKey("orders.*"))
            {
                mi = _onSubCallbackFuns["orders.*"];
            }
            else if (ch.StartsWith("matchOrders.") && _onSubCallbackFuns.ContainsKey("matchOrders.*"))
            {
                mi = _onSubCallbackFuns["matchOrders.*"];
            }
            else if (ch.StartsWith("trigger_order.") && _onSubCallbackFuns.ContainsKey("trigger_order.*"))
            {
                mi = _onSubCallbackFuns["trigger_order.*"];
            }
            else if (ch.EndsWith(".liquidation_orders") && _onSubCallbackFuns.ContainsKey("public.*.liquidation_orders"))
            {
                mi = _onSubCallbackFuns["public.*.liquidation_orders"];
            }
            else if (ch == "accounts" || ch == "positions" || ch == "positions_cross")
            {
                string contract_code = jdata["data"][0]["contract_code"].ToObject<string>();
                string full_ch = $"{ch}.{contract_code}";
                full_ch = full_ch.ToLower();

                if (_onSubCallbackFuns.ContainsKey(full_ch))
                {
                    mi = _onSubCallbackFuns[full_ch];
                }
                else if(_onSubCallbackFuns.ContainsKey($"{ch}.*"))
                {
                    mi = _onSubCallbackFuns[$"{ch}.*"];
                }
            }
            else if (ch == "accounts_cross")
            {
                string margin_account = jdata["data"][0]["margin_account"].ToObject<string>();
                string full_ch = $"{ch}.{margin_account}";
                full_ch = full_ch.ToLower();

                if (_onSubCallbackFuns.ContainsKey(full_ch))
                {
                    mi = _onSubCallbackFuns[full_ch];
                }
                else if(_onSubCallbackFuns.ContainsKey($"{ch}.*"))
                {
                    mi = _onSubCallbackFuns[$"{ch}.*"];
                }
            }

            if (mi == null)
            {
                _logger.Log(Log.LogLevel.Info, $"no callback function to handle: {jdata}");
                return;
            }
            mi.fun.DynamicInvoke(JsonConvert.DeserializeObject(data, mi.paramType));
        }

        /// <summary>
        /// handle req callback fun
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="data"></param>
        /// <param name="jdata"></param>
        private void _HandleReqCallbackFun(string ch, string data, JObject jdata)
        {
            ch = ch.ToLower();

            if (!_onReqCallbackFuns.ContainsKey(ch))
            {
                _logger.Log(Log.LogLevel.Info, $"no callback function to handle: {jdata}");
                return;
            }
            MethonInfo mi = _onReqCallbackFuns[ch];
            if (mi == null)
            {
                _logger.Log(Log.LogLevel.Info, $"no callback function to handle: {jdata}");
                return;
            }
            mi.fun.DynamicInvoke(JsonConvert.DeserializeObject(data, mi.paramType));
        }

        /// <summary>
        /// error msg handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WebSocket_OnError(object sender, ErrorEventArgs e)
        {
            _logger.Log(Log.LogLevel.Error, $"WebSocket error: {e.Message}");
        }

        /// <summary>
        /// sub channel and set callback function
        /// </summary>
        /// <param name="subStr"></param>
        /// <param name="ch"></param>
        /// <param name="fun"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected bool Sub(string subStr, string ch, Delegate fun, Type paramType)
        {
            if (_WebSocket == null)
            {
                _logger.Log(Log.LogLevel.Error, $"please connect first.");
                return false;
            }
            while(!_canWork)
            {
                System.Threading.Thread.Sleep(10);
            }

            ch = ch.ToLower();
            if (_onSubCallbackFuns.ContainsKey(ch))
            {
                _onSubCallbackFuns[ch] = new MethonInfo() { fun = fun, paramType = paramType };
                return true;
            }
            _WebSocket.Send(subStr);
            _all_sub_strs.Add(subStr);
            _logger.Log(Log.LogLevel.Info, $"websocket has send data: {subStr}");
            _onSubCallbackFuns[ch] = new MethonInfo() { fun = fun, paramType = paramType }; ;

            return true;
        }

        /// <summary>
        /// unsub channel and auto cancel callback function
        /// </summary>
        /// <param name="unsubStr"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        protected bool Unsub(string unsubStr, string ch)
        {
            if (_WebSocket == null)
            {
                _logger.Log(Log.LogLevel.Error, $"please connect first.");
                return false;
            }
            while(!_canWork)
            {
                System.Threading.Thread.Sleep(10);
            }

            ch = ch.ToLower();
            if (!_onSubCallbackFuns.ContainsKey(ch))
            {
                return true;
            }
            _WebSocket.Send(unsubStr);
            if (_all_sub_strs.Find(item => item == unsubStr) != null)
            {
                _all_sub_strs.Remove(unsubStr);
            }
            _logger.Log(Log.LogLevel.Info, $"websocket has send data: {unsubStr}.");

            return true;
        }

        /// <summary>
        /// request channel data
        /// </summary>
        /// <param name="reqStr"></param>
        /// <param name="ch"></param>
        /// <param name="fun"></param>
        /// <param name="paramType"></param>
        /// <returns></returns>
        protected bool Req(string reqStr, string ch, Delegate fun, Type paramType)
        {
            if (_WebSocket == null)
            {
                _logger.Log(Log.LogLevel.Error, $"please connect first.");
                return false;
            }
            while(!_canWork)
            {
                System.Threading.Thread.Sleep(10);
            }

            ch = ch.ToLower();

            _WebSocket.Send(reqStr);
            _logger.Log(Log.LogLevel.Info, $"websocket has send data: {reqStr}.");
            _onReqCallbackFuns[ch] = new MethonInfo() { fun = fun, paramType = paramType };

            return true;
        }
    }
}
