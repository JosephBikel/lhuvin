using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Lhuvin.Billing.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Billing Date")]
        public DateTime BillingDate { get; set; }

        public int AmountOfWeeks { get; set; }

        public decimal Subtotal { get; set; }

        public decimal PreviousBalance { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal TotalBalance { get; set; }
        public bool Detaild { get; set; }


        public string Report { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public decimal InvoiceBalance { get; set; }
        public void SetIB(decimal sum, int clientId)
        {
            var context = new ApplicationDbContext();
            var clientBalance = context.ClientBalances.Find(clientId);
            if (clientBalance.Balance >= sum)
                InvoiceBalance = sum;
            else if (clientBalance.Balance < 0)
                InvoiceBalance = 0;
            else
                InvoiceBalance = clientBalance.Balance; 
              context.SaveChanges();

        }

        public static void SubtractIB(decimal amount, int clientId)
        {
            var db = new ApplicationDbContext();

            while (amount > 0)
            {
                var invoice = db.Invoices.FirstOrDefault(i => i.ClientId == clientId
                && i.InvoiceBalance > 0);
                if (invoice == null)
                    break;

                if (amount >= invoice.InvoiceBalance)
                {
                    amount -= invoice.InvoiceBalance;
                    invoice.InvoiceBalance = 0;
                }
                else
                {
                    invoice.InvoiceBalance -= amount;
                    amount = 0;
                }
                db.SaveChanges();
            }
        }  

        public IEnumerable<ClientWeek> Weeks()
        {
            var context = new ApplicationDbContext();

            var weeks = context.ClientWeeks.Include(w => w.Parsha).Include(w => w.Days)
                .Where(w => w.StartDate >= StartDate 
                && w.Parsha.EndDate <= EndDate 
                && w.ClientId == ClientId);

            return weeks; 
        }

        public Invoice()
        {
            BillingDate = DateTime.Now;
        }

        public Invoice(List<ClientWeek> weeks, int clientId)
        {
            var context = new ApplicationDbContext();
           

            var weeksSum = weeks.Select(w => w.Sum);
            var sum = weeksSum.Sum();
            var startDate = weeks.FirstOrDefault().StartDate;
            var endDate = weeks.LastOrDefault().Parsha.EndDate;

            (BillingDate, StartDate, EndDate, AmountOfWeeks, Subtotal, ClientId) 
             = (DateTime.Now, startDate ,endDate, weeks.Count(), sum, clientId);

            SetIB(sum, clientId);

            foreach (var week in weeks)
            {
                context.Entry(week).Property(w => w.Billed).CurrentValue = true;
            }
            context.SaveChanges();

        }

        public Invoice(DateTime startDate, DateTime endDate, int clientId)
        {
            var context = new ApplicationDbContext();
            var weeks = context.ClientWeeks.Where(w => w.StartDate >= startDate 
            && w.Parsha.EndDate <= endDate 
            && w.ClientId == clientId);

            var sum = weeks.Select(w => w.Sum).Sum();

            (BillingDate, StartDate, EndDate, Subtotal, ClientId, AmountOfWeeks)
                = (DateTime.Now, startDate, endDate, sum, clientId, weeks.Count());

            SetIB(sum, clientId);

            foreach (var week in weeks)
            {
                context.Entry(week).Property(w => w.Billed).CurrentValue = true;
            }
            context.SaveChanges();
        }

      

    }
}