using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;

namespace Lhuvin.Billing.ViewModels
{
    public class NewClientPriceViewModel
    {
        public Client Client { get; set; }
        public ClientPrice ClientPrice { get; set; }
        public IEnumerable<PricePerHour> PricePerHours { get; set; }

    }
}