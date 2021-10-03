using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lhuvin.Extentions
{
    public static class TimeSpanExt
    {
        public static string ToTimeString(this TimeSpan time)
        {
            var timeString = "";

            if (time.Hours > 0)
            {
                timeString += time.Hours.ToString().TrimStart('0') + " שעה";
               
            }
            if (time.Minutes > 0)
            {
                timeString += " " + time.Minutes.ToString().TrimStart('0') + " מינוט";
            }
            return timeString;
        }

        public static TimeSpan Sum(this IEnumerable<TimeSpan> times)
        {
            var timeSum = new TimeSpan(times.Select(t => t.Hours).Sum(),
                           times.Select(t => t.Minutes).Sum(),
                            times.Select(t => t.Seconds).Sum());
            return timeSum;
        }
    }
}