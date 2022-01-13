using System;

namespace Huobi.SDK.Core.RequestBuilder
{
    public class PrivateUrlBuilder
    {
        private readonly string _host;

        private const string _aKKey = "AccessKeyId";
        private readonly string _aKValue;
        private const string _sMKey = "SignatureMethod";
        private const string _sMVaue = "HmacSHA256";
        private const string _sVKey = "SignatureVersion";
        private const string _sVValue = "2";
        private const string _tKey = "Timestamp";

        private readonly Signer _signer;

        public PrivateUrlBuilder(string accessKey, string secretKey, string host)
        {
            _aKValue = accessKey;
            _signer = new Signer(secretKey);

            _host = host;
        }

        public string Build(string method, string path, GetRequest query = null)
        {
            string strDateTime = DateTime.UtcNow.ToString("s");
            var req = new GetRequest(query)
                .AddParam(_aKKey, _aKValue)
                .AddParam(_sMKey, _sMVaue)
                .AddParam(_sVKey, _sVValue)
                .AddParam(_tKey, strDateTime);
            string to_sign_str = req.BuildParams();

            string signature = _signer.Sign(method, _host, path, to_sign_str);

            string options = req.BuildParams() + "&Signature=" + Uri.EscapeDataString(signature);

            string url = $"{Host.HTTP_PRO}://{_host}{path}?{options}";

            return url;
        }
    }
}
