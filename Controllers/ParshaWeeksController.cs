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
    public class ParshaWeeksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ParshaWeeks
        public ActionResult Index()
        {
            var parshas = db.ParshaWeeks.ToList();
            return View(parshas);
        }
        public ActionResult Create()
        {
            var week = new ParshaWeek();
            return View(week);
        }

        [HttpPost]

        public JsonResult Create(ParshaWeek week)
        {
            week.StartDate = week.StartDate.AddDays(- (int)week.StartDate.DayOfWeek).Date;
            week.EndDate = week.StartDate.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
            
            var parshas = db.ParshaWeeks;
            if (parshas.Any(p => p.StartDate == week.StartDate))
                throw new Exception();
            db.ParshaWeeks.Add(week);
            db.SaveChanges();
            var parsha = db.ParshaWeeks.Find(week.id);
            return Json(parsha, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return View("Create", db.ParshaWeeks.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(ParshaWeek week)
        {
            week.StartDate = week.StartDate.AddDays(-(int)week.StartDate.DayOfWeek).Date;
            week.EndDate = week.StartDate.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
            db.Entry(week).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

 
}