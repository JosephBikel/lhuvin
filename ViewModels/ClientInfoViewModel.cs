using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;

namespace Lhuvin.ViewModels
{
    public class ClientInfoViewModel
    {
        public Client Client { get; set; }
        public ClientPrice Price { get; set; }
    }
}