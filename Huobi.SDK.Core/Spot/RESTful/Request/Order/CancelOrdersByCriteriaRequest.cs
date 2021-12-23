using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Request.Order
{
    public class CancelOrdersByCriteriaRequest
    {
        [JsonProperty(PropertyName = "account-id")]
        public string AccountId;

        public string symbol;

        public string side;

        public int size;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
