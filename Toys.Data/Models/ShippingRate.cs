﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Toys.Data.Models
{
    public partial class ShippingRate
    {
        public string CCountryId { get; set; }
        public string CModeId { get; set; }
        public decimal MRatePerPound { get; set; }

        public virtual Country CCountry { get; set; }
        public virtual ShippingMode CMode { get; set; }
    }
}
