using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.Billing.Models
{
    public class ParshaWeek
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "אנהייב דעיט")]
        public DateTime StartDate { get; set; }

        [Display(Name = "ענדע דעיט")]
        public DateTime EndDate { get; set; }

        [StringLength(20)]
        [Display(Name ="פרשת")]
        public string Name { get; set; }

        public string Year {
            get
            {
                var ci = CultureInfo.CreateSpecificCulture("he-IL");
                ci.DateTimeFormat.Calendar = new HebrewCalendar();
                return StartDate.ToString(ci).Split(' ')[2];
            }
                }
        public ICollection<ClientWeek> ClientWeeks { get; set; }

        public ParshaWeek() { }
        public ParshaWeek(DateTime startDate)
        {
            StartDate = startDate;
            var timeSpan = new TimeSpan(23, 59, 59);
            EndDate = startDate.Add(timeSpan);
        }

        public static string GetDayInParsha(DateTime date)
        {
            var db = new ApplicationDbContext();
            var parsha = db.ParshaWeeks.AsEnumerable()
                .SingleOrDefault(p => p.StartDate == date.Date.AddDays(-(int)date.DayOfWeek));
            if(parsha == null)
            {
                var ci = CultureInfo.CreateSpecificCulture("he-IL");
                ci.DateTimeFormat.Calendar = new HebrewCalendar();
                return (DayBHL)date.DayOfWeek + " " + "new" + " " + date.ToString(ci).Split(' ')[2];
            }
             else  
            return (DayBHL)date.DayOfWeek + " " + parsha.Name + " " + parsha.Year;
        }

        public static DateTime GetDateFromPharsha(DayBHL dayBHL, string parsha, string year)
        {
            var db = new ApplicationDbContext();
            var parshaWeek = db.ParshaWeeks.AsEnumerable().SingleOrDefault(p => p.Name == parsha && p.Year == year);

            if (parshaWeek == null)
                throw new Exception("פרשת '" + parsha + "' עקזיסטירט נאכנישט אדער איז אנדערש געשריבן געווארן פאר יאר '" + year + "'");
            var date = parshaWeek.StartDate.AddDays((int)dayBHL);
            return date;
        }

        public enum DayBHL:byte
        {
            זינטאג, מאנטאג, דינסטאג, מיטוואך, דאנערשאג, פרייטאג, שבת
        }
    }
}