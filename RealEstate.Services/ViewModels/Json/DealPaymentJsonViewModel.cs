﻿using System;
using Newtonsoft.Json;
using RealEstate.Base;

namespace RealEstate.Services.ViewModels.Json
{
    public class DealPaymentJsonViewModel : BaseViewModel
    {
        [JsonProperty("tp")]
        public decimal Tip { get; set; }

        [JsonProperty("cms")]
        public decimal Commission { get; set; }

        [JsonProperty("pd")]
        public DateTime PayDate { get; set; }

        [JsonProperty("txt")]
        public string Text { get; set; }
    }
}