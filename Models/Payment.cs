using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.Billing.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }

        public PaymentType PaymentType { get; set; }

        public int ChargeId { get; set; }
        public CreditCardCharge Charge { get; set; }
        public TPCheck Check { get; set; }

        private readonly ApplicationDbContext  Context = new ApplicationDbContext();

        public Payment()
        {
            PaymentDate = DateTime.Now;
        }

        public Payment(int clientId)
        {
            ClientId = clientId;
            PaymentDate = DateTime.Now;
        }
        public Payment(int clientId, PaymentType paymentType, decimal amount)
        {
            (PaymentDate, Amount, ClientId, PaymentType)
                = (DateTime.Now, amount, clientId, paymentType);
            
            var clientBalance = Context.ClientBalances.Find(clientId);
            clientBalance.Subtract(amount);

            Invoice.SubtractIB(amount, clientId);

            Context.SaveChanges();
        }
    }
        
}
