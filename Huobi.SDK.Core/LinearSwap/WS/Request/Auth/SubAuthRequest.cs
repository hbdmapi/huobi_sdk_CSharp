
namespace Huobi.SDK.Core.LinearSwap.WS.Request.Auth
{
    public class SubAuthRequest
    {
        public string op { get { return "auth"; } }

        public string type { get { return "api"; } }

        public string AccessKeyId { get; set; }

        public string SignatureMethod { get { return "HmacSHA256"; } }

        public string SignatureVersion { get { return "HmacSHA256"; } }

        public string Timestamp { get; set; }

        public string Signature { get; set; }
    }
}

