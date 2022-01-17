﻿
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{

    /// <summary>
    /// response for all subaccount assets request
    /// POST linear-swap-api/v1/swap_sub_account_list
    /// </summary>
    public class GetAllSubAssetsResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Data> data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            [JsonProperty("sub_uid")]
            public string subUid { get; set; }

            public List<CoinAssets> list { get; set; }

            public class CoinAssets
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("margin_asset")]
                public string marginAsset { get; set; }

                [JsonProperty("margin_balance")]
                public double marginBalance { get; set; }

                [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
                public double liquidationPrice { get; set; }

                [JsonProperty("risk_rate", NullValueHandling = NullValueHandling.Ignore)]
                public double riskRate { get; set; }

                [JsonProperty("margin_mode")]
                public string marginMode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }

                [JsonProperty("trade_partition")]
                public string tradePartition { get; set; }
            }
        }
    }
}
