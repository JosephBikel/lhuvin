using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.Data.Entity;

namespace Lhuvin.Billing.ViewModels
{
    public class BalancesViewModal
    {
        public List<Client> Clients { get; set; }
        public List<ClientWeek> UnPaidWeeks { get; set; }

        public BalancesViewModal()
        {
            var db = new ApplicationDbContext();
            Clients = db.Clients.Where(c => c.Weeks.Any(w => w.BalanceDue > 0)).ToList();
            UnPaidWeeks = db.ClientWeeks.Include(w => w.Days).Include(w => w.Parsha).Where(w => w.BalanceDue> 0).OrderBy(w => w.StartDate).ToList(); 
        }
    }
}

 