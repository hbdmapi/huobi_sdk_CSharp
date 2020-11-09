using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    public class GetApiTradingStatusResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public class Data
        {
            [JsonProperty("is_disable")]
            public int isDisable { get; set; }

            [JsonProperty("order_price_types")]
            public string orderPriceTypes { get; set; }

            [JsonProperty("disable_reason")]
            public string disableReason { get; set; }

            [JsonProperty("disable_interval")]
            public long disableInterval { get; set; }

            [JsonProperty("recovery_time")]
            public long recoveryTime { get; set; }

            public CancelOrderRatio COR { get; set; }
            public class CancelOrderRatio
            {
                [JsonProperty("orders_threshold")]
                public long ordersThreshold { get; set; }

                [JsonProperty("orders")]
                public long orders { get; set; }

                [JsonProperty("invalid_cancel_orders")]
                public long invalidCancelOrders { get; set; }

                [JsonProperty("cancel_ratio_threshold")]
                public double cancelRatioThreshold { get; set; }

                [JsonProperty("cancel_ratio")]
                public double cancelRatio { get; set; }

                [JsonProperty("is_trigger")]
                public int isTrigger { get; set; }

                [JsonProperty("is_active")]
                public int isActive { get; set; }
            }

            public TotalDisableNumber TDN { get; set; }
            public class TotalDisableNumber
            {
                [JsonProperty("disables_threshold")]
                public long disablesThreshold { get; set; }

                public long disables { get; set; }

                [JsonProperty("is_trigger")]
                public int isTrigger { get; set; }

                [JsonProperty("is_active")]
                public int isActive { get; set; }
            }

        }
    }
}
