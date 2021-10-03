using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.Data.Entity;

namespace Lhuvin.Billing.ViewModels
{
    public class WeekDetailsViewModels
    {
        public ClientWeek Week { get; set; }
        public List<ClientDay> Days { get; set; }
        public WeekDetailsViewModels() { }
        public WeekDetailsViewModels(int weekId)
        {
            var context = new ApplicationDbContext();
            var week = context.ClientWeeks.Include(w => w.Client).Include(w => w.Days).Include(w => w.Parsha).SingleOrDefault(w => w.Id == weekId);
            var days = week.Days;

            (Week, Days) = (week, days.ToList());
        }
    }
}