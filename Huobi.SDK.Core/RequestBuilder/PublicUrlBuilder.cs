namespace Huobi.SDK.Core.RequestBuilder
{
    public class PublicUrlBuilder
    {
        private readonly string _host;

        public PublicUrlBuilder(string host)
        {
            _host = host;
        }

        public string Build(string path, GetRequest query = null)
        {
            string options = string.Empty;
            if (query != null)
            {
                options = $"?{query.BuildParams()}";
            }
            return $"{Host.HTTP_PRO}://{_host}{path}{options}";
        }
    }
}
