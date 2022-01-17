
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{

    /// <summary>
    /// response for account and sub account two class info
    /// POST linear-swap-api/v1/swap_account_info
    /// POST linear-swap-api/v1/swap_sub_account_info
    /// </summary>
    public class CrossGetAccountInfoResponse
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
            [JsonProperty("margin_mode")]
            public string marginMode { get; set; }

            [JsonProperty("margin_account")]
            public string marginAccount { get; set; }

            [JsonProperty("margin_asset")]
            public string marginAsset { get; set; }

            [JsonProperty("margin_balance")]
            public double marginBalance { get; set; }

            [JsonProperty("margin_static")]
            public double marginStatic { get; set; }

            [JsonProperty("margin_position")]
            public double marginPosition { get; set; }

            [JsonProperty("margin_frozen")]
            public double marginFrozen { get; set; }

            [JsonProperty("profit_real")]
            public double profitReal { get; set; }

            [JsonProperty("profit_unreal")]
            public double profitUnreal { get; set; }

            [JsonProperty("withdraw_available")]
            public double withdrawAvailable;

            [JsonProperty("risk_rate", NullValueHandling = NullValueHandling.Ignore)]
            public double riskRate { get; set; }

            public class ContractDetail
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("margin_position")]
                public double marginPosition { get; set; }

                [JsonProperty("margin_frozen")]
                public double marginFrozen { get; set; }

                [JsonProperty("margin_available")]
                public double marginAvailable { get; set; }

                [JsonProperty("profit_real")]
                public double profitReal { get; set; }

                [JsonProperty("liquidation_price", NullValueHandling = NullValueHandling.Ignore)]
                public double liquidationPrice { get; set; }

                [JsonProperty("lever_rate")]
                public double leverRate { get; set; }

                [JsonProperty("adjust_factor")]
                public double adjustFactor { get; set; }

                [JsonProperty("contract_type")]
                public string contractType { get; set; }

                [JsonProperty("pair")]
                public string pair { get; set; }

                [JsonProperty("business_type")]
                public string businessType { get; set; }

                [JsonProperty("trade_partition")]
                public string tradePartition { get; set; }
            }

            [JsonProperty("contract_detail", NullValueHandling = NullValueHandling.Ignore)]
            public List<ContractDetail> contractDetails { get; set; }

            [JsonProperty("futures_contract_detail", NullValueHandling = NullValueHandling.Ignore)]
            public List<ContractDetail> futuresContractDetail { get; set; }
        }
    }
}
