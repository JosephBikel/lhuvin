using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lhuvin.Billing;
using Lhuvin.Reports.Modals;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lhuvin.Models
{
    public class YiddishDate
    {
        [Display(Name = "טאג")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DayByName? Day { get; set; }

        [Display(Name = "פרשת")]
        public string Parsha { get; set; }

        [Display(Name = "יאר")]
        public string Year { get; set; }

        public YiddishDate() { }

        public YiddishDate(DateTime date)
        {
            var db = new ApplicationDbContext();
            var parsha = db.ParshaWeeks.AsEnumerable()
                .SingleOrDefault(p => p.StartDate == date.Date.AddDays(-(int)date.DayOfWeek));
            if (parsha == null)
            {
                var ci = CultureInfo.CreateSpecificCulture("he-IL");
                ci.DateTimeFormat.Calendar = new HebrewCalendar();
                (Parsha, Year) = (null, date.ToString(ci).Split(' ')[2]);
            }
            else
                (Parsha, Year) = (parsha.Name, parsha.Year);
            Day = (DayByName)date.DayOfWeek;
        }

        public YiddishDate(DayByName day, string parsha, string year)
        {
            (Day, Parsha, Year) = (day, parsha, year);
        }

        public DateTime GetDate()
        {
            var db = new ApplicationDbContext();
            var parshaWeek = db.ParshaWeeks.AsEnumerable().SingleOrDefault(p => p.Name == Parsha && p.Year == Year);

            if (parshaWeek == null)
                throw new Exception("");
            var date = parshaWeek.StartDate.AddDays((int)Day);
            return date;
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DayByName : byte
        {
            א, ב, ג, ד, ה, ו, שבת
        }
    }
}