using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Request.AlgoOrder
{
    public class PlaceOrderRequest
    {
        public int accountId;

        public string symbol;

        public string orderPrice;

        public string orderSide;

        public string orderSize;

        public string orderValue;

        public string timeInForce;

        public string orderType;

        public string clientOrderId;

        public string stopPrice;

        public string trailingRate;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
