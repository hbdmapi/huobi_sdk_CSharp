using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Request.AlgoOrder
{
    public class CancelOrdersRequest
    {
        public string[] clientOrderIds;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
