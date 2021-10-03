using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;

namespace Lhuvin.Billing.ViewModels
{
    public class CreateCCViewModel
    {
        public Client Client { get; set; }
        public CreditCard Card { get; set; }
    }
}