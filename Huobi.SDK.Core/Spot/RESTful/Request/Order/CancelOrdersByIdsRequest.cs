using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Request.Order
{
    public class CancelOrdersByIdsRequest
    {
        [JsonProperty(PropertyName = "order-ids")]
        public string[] OrderIds;

        [JsonProperty(PropertyName = "client-order-ids")]
        public string[] ClientOrderIds;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
