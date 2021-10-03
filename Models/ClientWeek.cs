using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime;
using Lhuvin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Lhuvin.Billing.Models
{
    public class ClientWeek
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Display(Name = "פרשת")]
        public ParshaWeek Parsha { get; set; }
        public int ParshaId { get; set; }

    
        public byte AmountOfDays { 
            get {
                if (Days != null)
                    return (byte)Days.Count();
                else return 0;
            } 
        }
        [Display(Name = "סך הכל")]
        public decimal Sum {
            get
            {
                if (Days != null)
                    return Days.Select(d => d.Price).Sum();
                else return 0;
            }
        }

        public decimal BalanceDue { get; set; }

        public bool Billed { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }

        public ICollection<ClientDay> Days { get; set; }
        public ClientWeek() {
            
        }

        public ClientWeek(int clientId)
        {
            (ClientId)
                = (clientId);
        }

        public ClientWeek(int clientId, DateTime date)
        {
            

            (ClientId, StartDate, EndDate) 
                = (clientId, date.AddDays(-(int)date.DayOfWeek).Date, date.AddDays(6 -(int)date.DayOfWeek).AddHours(23 -date.TimeOfDay.Hours)
                .AddMinutes(59 - date.TimeOfDay.Minutes).AddSeconds(59 - date.TimeOfDay.Seconds));
        }

        public ClientWeek(int clientId, List<ClientDay> days)
        {

            var sum = days.Select(d => d.Price).Sum();
            var startDate = days.FirstOrDefault().StartTime
                .AddDays(-(int)days.FirstOrDefault().StartTime.DayOfWeek);
            var endDate = startDate.AddDays(6);
            var amountDays = Convert.ToByte(days.Count);

            (ClientId, StartDate)
                = (clientId, startDate);
        }

        public void SetBalanceDue()
        {
            var db = new ApplicationDbContext();
           
            var weeksBalances = db.ClientWeeks.AsEnumerable().Where(w => w.ClientId == ClientId && w.Id != Id).Select(w => w.BalanceDue).Sum();
            var clientBalance = db.ClientBalances.Find(ClientId).Balance - weeksBalances;
            if (clientBalance >= Sum)
                BalanceDue = Sum;
            else if (clientBalance < 0)
                BalanceDue = 0;
            else
                BalanceDue = clientBalance;
            db.SaveChanges();
        }

        public static void AddBD(decimal amount, int clientId)
        {
            var db = new ApplicationDbContext();
       

            while (amount > 0)
            {
                var week = db.ClientWeeks.Include(w => w.Days).AsEnumerable()
           .LastOrDefault(w => w.ClientId == clientId && w.BalanceDue < w.Sum);
                var balanceDifferent = week.Sum - week.BalanceDue;
                if (week == null)
                    break;
                if(amount >= balanceDifferent)
                {
                    week.BalanceDue = week.Sum;
                    amount -= balanceDifferent;
                }
                else
                {
                    week.BalanceDue += amount;
                    amount = 0;
                }
                db.SaveChanges();
            }
        }
        public static void SubtractBD(decimal amount, int clientId)
        {
            var db = new ApplicationDbContext();

            while (amount > 0)
            {
                var week = db.ClientWeeks.FirstOrDefault(w => w.ClientId == clientId
                && w.BalanceDue > 0);
                if (week == null)
                    break;

                if (amount >= week.BalanceDue)
                {
                    amount -= week.BalanceDue;
                    week.BalanceDue = 0;
                }
                else
                {
                    week.BalanceDue -= amount;
                    amount = 0;
                }
                db.SaveChanges();
            }
        }

    }
}