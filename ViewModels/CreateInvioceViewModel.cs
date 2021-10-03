using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;

namespace Lhuvin.Billing.ViewModels
{
    public class CreateInvioceViewModel
    {
        public int ClientId { get; set; }
        public string Report { get; set; }

        public bool Detaild { get; set; }
        public IEnumerable<ClientWeek> Weeks { get; set; }
    }
}