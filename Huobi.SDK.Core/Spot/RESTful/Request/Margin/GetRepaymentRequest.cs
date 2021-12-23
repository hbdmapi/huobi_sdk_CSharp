using Newtonsoft.Json;

namespace Huobi.SDK.Core.Spot.RESTful.Request.Margin
{
    public class GetRepaymentRequest
    {
        public string repayId;

        public string accountId;

        public string currency;

        public long startTime;

        public long endTime;

        public string sort;

        public int limit;

        public long fromId;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
