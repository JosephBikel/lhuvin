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
    public class ClientWeeksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ClientWeeksController()
        {

        }

        // GET: ClientWeeks
        public ActionResult Index(int? id)
        {
            var weeks = db.ClientWeeks.Include(w => w.Client).Include(w => w.Parsha).Include(w => w.Days)
                .OrderBy(p => p.StartDate).ToList();

            if (id != null)
            {
                id = Convert.ToInt32(id);
                weeks = weeks.Where(w => w.ClientId == id).ToList();
                ViewBag.NewInvoice = new MvcHtmlString("<a href = \'/invoices/create/" + id + "\'>new invoice</a>");
            }
               

            return View(weeks);
        }

        // GET: ClientWeeks/Details/5
        public ActionResult Details(int id)
        {
            var weekDetails = db.ClientWeeks
                .Include(w => w.Client).Include(w => w.Days).Include(w => w.Parsha)
                .SingleOrDefault(w => w.Id == id);
            return View(weekDetails);
        }

     
        public ActionResult Create(ClientDay day)
        {
            try
            {
                var weekStart = day.StartTime.AddDays(-(int)day.StartTime.DayOfWeek).Date;
                var clientId = day.ClientId;
                var weeks = db.ClientWeeks.Include(w => w.Days).AsEnumerable().Where(w =>
                w.ClientId == clientId &&
                w.StartDate.AddDays(-(int)w.StartDate.DayOfWeek) == weekStart);

                var week = weeks.SingleOrDefault(w => w.Billed == false);
                if (week == null)
                {
                    var parsha = db.ParshaWeeks.SingleOrDefault(p => p.StartDate == weekStart);

                    if (parsha == null)
                    {
                        var newParsha = new ParshaWeek(weekStart);
                        db.ParshaWeeks.Add(newParsha);
                        db.SaveChanges();
                        parsha = newParsha;

                    }

                    var newWeek = new ClientWeek(clientId, day.StartTime) { ParshaId = parsha.id };

                    if (weeks.Count() > 0)
                    {
                        newWeek.StartDate = day.StartTime.Date;

                        foreach (var w in weeks)
                        {
                            w.EndDate = w.Days.LastOrDefault().StartTime;
                        }
                    }
                    db.ClientWeeks.Add(newWeek);
                    db.SaveChanges();
                    week = newWeek;
                }
                day.WeekId = week.Id;
                db.ClientDays.Add(day);
                db.SaveChanges();
                week.SetBalanceDue();
                db.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

       /* public ActionResult OnBalance(int weekId, string returnUrl)
        {
            var week = db.ClientWeeks.Find(weekId);
            if(week.OnBalance == false)
            {
                var clientBalance = db.ClientBalances.Find(week.ClientId);
                clientBalance.Add(week.Sum);
                week.OnBalance = true;
                db.SaveChanges();
            }
            
            return RedirectToAction(returnUrl);
        }*/

        // GET: ClientWeeks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientWeeks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: ClientWeeks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientWeeks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
