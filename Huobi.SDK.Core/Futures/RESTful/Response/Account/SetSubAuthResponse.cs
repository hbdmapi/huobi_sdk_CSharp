using System.Collections.Generic;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Futures.RESTful.Response.Account
{
    public class SetSubAuthResponse
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
            public List<Errors> errors { get; set; }

            public class Errors
            {
                [JsonProperty("sub_uid")]
                public string subUid { get; set; }

                [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
                public string errorCode { get; set; }

                [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
                public string errorMessage { get; set; }

            }

            public string successes { get; set; }
        }
    }
}
