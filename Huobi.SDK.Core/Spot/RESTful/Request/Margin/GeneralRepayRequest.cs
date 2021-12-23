using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Request.Margin
{
    public class GeneralRepayRequest
    {
        public string accountId;

        public string currency;

        public string amount;

        public string transactId;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
