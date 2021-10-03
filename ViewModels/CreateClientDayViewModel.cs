using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;

namespace Lhuvin.Billing.ViewModels
{
    public class CreateClientDayViewModel
    {
        public int ClientId { get; set; }
        public int DayId { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "שנת")]
        public string Year { get; set; }

        [Display(Name = "פרשת")]
        public string Parsha { get; set; }
        [Display(Name = "יום")]
        public ParshaWeek.DayBHL Day { get; set; }

        [Display(Name = "אנגעהויבן")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "געענדיגט")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "ריפארט")]
        public string BreakDown { get; set; }

        public int PriceId { get; set; }
        public CreateClientDayViewModel() { }
        public CreateClientDayViewModel(DateTime date)
        {
            var dayInParsha = ParshaWeek.GetDayInParsha(date).Split(' ');
            Enum.TryParse(dayInParsha[0], out ParshaWeek.DayBHL dayBHL);
            (Year, Parsha, Day) = (dayInParsha[2], dayInParsha[1], dayBHL) ;

        }
    }
}