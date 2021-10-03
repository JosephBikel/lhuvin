using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;


namespace Lhuvin.Billing.ViewModels
{
    public class UpdateBalanceViewModel
    {
        public Client Client { get; set; }
        public ClientBalance Balance { get; set; }

        [Display(Name = "New Amount")]
        public decimal NewAmount { get; set; }
        public int WeekId  { get; set; }
    }
}