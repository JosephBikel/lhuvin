using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;

namespace Lhuvin.Billing.ViewModels
{
    public class CreateCCChargeViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<CreditCard> Cards { get; set; }

        public CreditCardCharge Charge { get; set; }
    }
}