namespace Huobi.SDK.Core.RequestBuilder
{
    public class PublicUrlBuilder
    {
        private readonly string _host;

        public PublicUrlBuilder(string host)
        {
            _host = host;
        }

        public string Build(string path)
        {
            return $"https://{_host}{path}";
        }
    }
}
