using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lhuvin.Billing.Models
{
    public class CreditCardCharge
    {
        [Key]
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public int CardId { get; set; }


        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public bool Approved { get; set; }
        public CreditCard Card { get; set; }
        public Payment Payment { get; set; }

        public CreditCardCharge()
        {
             Approved = true;
        }
            
        public CreditCardCharge(int cardId)
        {
            ( Approved, CardId) = ( true, cardId);
        }

    }
}