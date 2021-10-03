using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Billing.Models;

namespace Lhuvin.Billing.ViewModels
{
    public class CreatePriceViewModel
    {
        public int? ClientId { get; set; }
        public PricePerHour PricePerHour { get; set; }
    }
}