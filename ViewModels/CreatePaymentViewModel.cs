using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;

namespace Lhuvin.Billing.ViewModels
{
    public class CreatePaymentViewModel
    {
        public Payment Payment { get; set; }
        public IEnumerable<PaymentType> PaymentTypes { get; set; }
    }
}