
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Huobi.SDK.Core.LinearSwap.RESTful.Response.Account
{
    /// <summary>
    /// user settlement records
    /// </summary>
    public class CrossGetUserSettlementRecordsResponse
    {
        public string status { get; set; }

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data { get; set; }

        public long ts { get; set; }

        public class Data
        {
            [JsonProperty("settlement_records", NullValueHandling = NullValueHandling.Ignore)]
            public List<SettlementRecords> settlementRecords { get; set; }

            public class SettlementRecords
            {
                [JsonProperty("margin_mode")]
                public string marginMode { get; set; }

                [JsonProperty("margin_account")]
                public string marginAccount { get; set; }

                [JsonProperty("margin_balance_init")]
                public double marginBalanceInit { get; set; }

                [JsonProperty("margin_balance")]
                public double marginBalance { get; set; }

                [JsonProperty("settlement_profit_real")]
                public double settlementProfitReal { get; set; }

                [JsonProperty("settlement_time")]
                public long settlementTime { get; set; }

                public double clawback { get; set; }

                [JsonProperty("funding_fee")]
                public double fundingFee { get; set; }

                [JsonProperty("offset_profitloss")]
                public double offsetProfitloss { get; set; }

                public double fee { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset;

                [JsonProperty("contract_detail")]
                public List<ContractDetail> contractDetail { get; set; }
            }

            public class ContractDetail
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                [JsonProperty("offset_profitloss")]
                public double offsetProfitloss { get; set; }

                public double fee { get; set; }

                [JsonProperty("fee_asset")]
                public string feeAsset;

                public List<Positions> positions;

                [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
                public string pair { get; set; }
            }

            public class Positions
            {
                public string symbol { get; set; }

                [JsonProperty("contract_code")]
                public string contractCode { get; set; }

                public string direction { get; set; }

                public double volume { get; set; }

                [JsonProperty("cost_open")]
                public double costOpen { get; set; }

                [JsonProperty("cost_hold_pre")]
                public double costHoldPre { get; set; }

                [JsonProperty("cost_hold")]
                public double costHold { get; set; }

                [JsonProperty("settlement_profit_unreal")]
                public double settlementProfitUnreal { get; set; }

                [JsonProperty("settlement_price")]
                public double settlementPrice { get; set; }

                [JsonProperty("settlement_type")]
                public string settlementType { get; set; }

                [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
                public string pair { get; set; }
            }

            [JsonProperty("total_page")]
            public long totalPage { get; set; }

            [JsonProperty("current_page")]
            public long currentPage { get; set; }

            [JsonProperty("total_size")]
            public long totalSize { get; set; }
        }
    }
}
