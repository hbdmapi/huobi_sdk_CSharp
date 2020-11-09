using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    public class GetFeeResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        public long ts { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public class Data
        {
            public string symbol { get; set; }

            [JsonProperty("contract_code")]
            public string contractCode { get; set; }

            [JsonProperty("open_maker_fee")]
            public string openMakerFee { get; set; }

            [JsonProperty("open_taker_fee")]
            public string openTakerFee { get; set; }

            [JsonProperty("close_maker_fee")]
            public string closeMakerFee { get; set; }

            [JsonProperty("close_taker_fee")]
            public string closeTakerFee { get; set; }

            [JsonProperty("fee_asset")]
            public string feeAsset { get; set; }
        }
    }
}
