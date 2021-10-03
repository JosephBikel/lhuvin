using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lhuvin.Billing.Models;
using Lhuvin.Billing.ViewModels;
using Lhuvin.Models;


namespace Lhuvin.Billing.Controllers
{
    public class BalanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var balances = new BalancesViewModal();
            return View(balances);
        }

        public ActionResult Update(int id, decimal amount, int weekId = 0)
        {
            var updateBalance = new UpdateBalanceViewModel()
            {
                Client = db.Clients.Find(id),
                Balance = db.ClientBalances.Find(id),
                NewAmount = amount,
                WeekId = weekId
            };
            return View(updateBalance);
        }

        [HttpPost]
        public ActionResult Update(UpdateBalanceViewModel viewModel)
        {
           var balance = db.ClientBalances.Find(viewModel.Balance.Id);
            balance.Add(viewModel.NewAmount);
           /* if(viewModel.WeekId > 0)
            {
            db.ClientWeeks.Find(viewModel.WeekId).OnBalance = true;
                db.SaveChanges();
            }*/
            db.SaveChanges();
            return RedirectToAction("Details", "Clients", new { id = viewModel.Balance.Id, redirect = "balance-btn" });
        }
    }
}