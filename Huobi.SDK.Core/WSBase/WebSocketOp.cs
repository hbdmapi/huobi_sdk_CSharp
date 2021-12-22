using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebSocketSharp;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Core.RequestBuilder;

namespace Huobi.SDK.Core.WSBase
{
    public class WebSocketOp
    {
        protected ILogger logger = new ConsoleLogger();
        private string host = null;
        private string path = null;
        private string subStr = null;
        private string accessKey;
        private string secretKey;
        Delegate callbackFun = null;
        Type paramType = null;
        bool autoReconnect = false;
        
        protected WebSocket websocket = null;
        private bool isConnected = false;
        private bool isManclose = false;


        /// <summary>
        /// construct
        /// </summary>
        /// <param name="path"></param>
        /// <param name="subStr"></param>
        /// <param name="callbackFun"></param>
        /// <param name="paramType"></param>
        /// <param name="Reconnect"></param>
        /// <param name="host"></param>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        public WebSocketOp(string path, string subStr, Delegate callbackFun, Type paramType, bool autoReconnect = true,
                              string host = Host.FUTURES, string accessKey = null, string secretKey = null)
        {
            this.path = path;
            this.host = host;
            this.subStr = subStr;
            this.callbackFun = callbackFun;
            this.paramType = paramType;
            this.autoReconnect = autoReconnect;

            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }

        ~WebSocketOp()
        {
            Disconnect();
        }

        /// <summary>
        /// connect
        /// </summary>
        public void Connect()
        {
            websocket = new WebSocket($"wss://{host}{path}");
            websocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;

            websocket.OnOpen += OnOpen;
            websocket.OnClose += OnClose;
            websocket.OnMessage += OnMsg;
            websocket.OnError += OnError;

            websocket.Connect();
        }

        /// <summary>
        /// disconnect websocket server
        /// </summary>
        public void Disconnect()
        {
            if(websocket == null)
            {
                return;
            }
            websocket.OnOpen -= OnOpen;
            websocket.OnClose -= OnClose;
            websocket.OnMessage -= OnMsg;
            websocket.OnError -= OnError;

            websocket.Close(CloseStatusCode.Normal);
            websocket = null;
            isConnected = false;
            isManclose = true;
        }

        /// <summary>
        /// websocket open handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpen(object sender, EventArgs e)
        {
            logger.Log(Log.LogLevel.Info, "WebSocket opened");
            isConnected = true;

            if (accessKey != null && secretKey != null)
            {
                string timestamp = DateTime.UtcNow.ToString("s");
                var sign = new Signer(secretKey);

                var req = new GetRequest()
                    .AddParam("AccessKeyId", accessKey)
                    .AddParam("SignatureMethod", "HmacSHA256")
                    .AddParam("SignatureVersion", "2")
                    .AddParam("Timestamp", timestamp);

                string signature = sign.Sign("GET", host, path, req.BuildParams());
                WSAuthData auth = new WSAuthData() { accessKeyId = accessKey, signature = signature, timestamp = timestamp };

                string auth_str = JsonConvert.SerializeObject(auth);
                websocket.Send(auth_str);
            }
            websocket.Send(subStr);
        }

        /// <summary>
        /// websocker close handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, EventArgs e)
        {
            isConnected = false;
            logger.Log(Log.LogLevel.Info, "WebSocket close.");

            if (autoReconnect == true && !isManclose)
            {
                Connect();
            }
        }

        /// <summary>
        /// error msg handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnError(object sender, ErrorEventArgs e)
        {
            logger.Log(Log.LogLevel.Error, $"WebSocket error: {e.Message}");
        }

        /// <summary>
        /// reply msg handle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMsg(object sender, MessageEventArgs e)
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

                //logger.Log(Log.LogLevel.Debug, $"websocket has received data: {data}");

                string pongData = $"{{\"pong\":{ts} }}";
                websocket.Send(pongData);

                //logger.Log(Log.LogLevel.Debug, $"websocket has send data: {pongData}");
            }
            else if (jdata.ContainsKey("op"))
            {
                string op = jdata["op"].ToObject<string>();
                switch (op)
                {
                    case "ping": // order heartbeat
                        string ts = jdata["ts"].ToObject<string>();
                        //logger.Log(Log.LogLevel.Debug, $"websocket has received data: {data}");

                        string pongData = $"{{ \"op\":\"pong\", \"ts\":{ts} }}";
                        websocket.Send(pongData);

                        //logger.Log(Log.LogLevel.Debug, $"websocket has send data: {pongData}");
                        break;

                    case "close":
                        logger.Log(Log.LogLevel.Error, $"websocket has received data: {data}");
                        break;

                    case "error":
                        logger.Log(Log.LogLevel.Trace, $"websocket has received data: {data}");
                        break;

                    case "auth":
                        logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
                        int code = jdata["err-code"].ToObject<int>();
                        break;
                    case "notify":
                        if (callbackFun != null)
                        {
                            callbackFun.DynamicInvoke(JsonConvert.DeserializeObject(data, paramType));
                        }
                        else
                        {
                            logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
                        }
                        break;
                    case "sub":
                        logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
                        break;
                    case "unsub":
                        logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
                        break;
                    default:
                        logger.Log(Log.LogLevel.Info, $"unknown data: {data}");
                        break;
                }
            }
            else if (jdata.ContainsKey("subbed")) // sub success reply
            {
                logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
            }
            else if (jdata.ContainsKey("unsubbed")) // unsub success reply
            {
                logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
            }
            else if (jdata.ContainsKey("ch")) // market sub reply data
            {
                if (callbackFun != null)
                {
                    callbackFun.DynamicInvoke(JsonConvert.DeserializeObject(data, paramType));
                }
                else
                {
                    logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
                }
            }
            else if (jdata.ContainsKey("rep")) // market request reply data
            {
                if (callbackFun != null)
                {
                    callbackFun.DynamicInvoke(JsonConvert.DeserializeObject(data, paramType));
                }
                else
                {
                    logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
                }
            }
            else if (jdata.ContainsKey("err-code")) // market request reply data
            {
                logger.Log(Log.LogLevel.Info, $"websocket has received data: {data}");
            }
            else
            {
                logger.Log(Log.LogLevel.Info, $"unknown data: {data}");
            }
        }

        /// <summary>
        /// send msg
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendMsg(string msg)
        {
            if(!isConnected)
            {
                return false;
            }

            websocket.Send(msg);
            return true;
        }

        public bool IsConnected()
        {
            return isConnected;
        }
    }
}
