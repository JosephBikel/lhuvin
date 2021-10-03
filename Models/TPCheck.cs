using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.Billing.Models
{
    public class TPCheck
    {
        [Key]
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public string Memo { get; set; }

        
        public Payment Payment { get; set; }
    }
}