using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.Billing.Models
{
    public class ClientDay
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "שעות")]
        public TimeSpan Time { get; set; }        
        public Client Client { get; set; }

        public int ClientId { get; set; }
        public bool Learnd { get; set; }

        [Display(Name = "Summary")]
        public string BreakDown { get; set; }

        [Display(Name = "פרייז")]
        public decimal Price { get; set; }
        public int PricePHId { get; set; }
        public PricePerHour PricePH { get; set; }

        public ClientWeek Week { get; set; }
        public int WeekId { get; set; }

        public ClientDay() { }

        public ClientDay(DateTime startTime, TimeSpan endTime, int clientId, string breakDown, int priceId)
        {
            var context = new ApplicationDbContext();

            if (endTime < startTime.TimeOfDay)
                throw new Exception("די ענדע צייט קען נישט זיין פאר די אנהייב צייט");
            var endDate = new DateTime(startTime.Year, startTime.Month, startTime.Day, endTime.Hours, endTime.Minutes, endTime.Seconds);

            (StartTime, EndTime,Time, BreakDown, ClientId, PricePHId)
                = (startTime, endDate, endDate - startTime, breakDown, clientId, priceId );
            if (!string.IsNullOrWhiteSpace(breakDown))
            {

                Learnd = true;
            Price = context.PricePerHours.Find(priceId).Devide(endDate - startTime);
            }
        }

    }
}