using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lhuvin.Billing;
using Lhuvin.Models;
using Lhuvin.Reports.Modals;
using System.Web.Mvc;

namespace Lhuvin.Reports.Controllers
{
    public class DailyReportsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: DailyReports
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetReports(int id, int? weekId, string from = null, string to = null)
        {
            var clientDays = db.ClientDays.AsEnumerable().OrderBy(d => d.StartTime)
               .Where(d => d.ClientId == id);

            if (weekId != null)
                clientDays = clientDays.Where(d => db.ClientWeeks.Find(weekId).Days.Any(wd => wd.StartTime == d.StartTime));

           else if (from != null && to != null)
            {
                var splitFrom = from.Split('/');
                var splitTo = to.Split('/');
                var fromDate = new YiddishDate((YiddishDate.DayByName)Enum.Parse(typeof(YiddishDate.DayByName), splitFrom[0]), splitFrom[1], "תש" + splitFrom[2]).GetDate();
                var toDate = new YiddishDate((YiddishDate.DayByName)Enum.Parse(typeof(YiddishDate.DayByName), splitTo[0]), splitTo[1], "תש" + splitTo[2]).GetDate();

                clientDays = clientDays.AsEnumerable()
                    .Where(d => d.StartTime >= fromDate && d.EndTime < toDate.AddDays(1));

                if (clientDays == null)
                    return Json("No Reports", JsonRequestBehavior.AllowGet);

            }
            else
                clientDays = clientDays.Skip(clientDays.Count() - 7);
            var reports = new List<DailyReport>();
             foreach (var day in clientDays.OrderByDescending(d => d.StartTime))
                {
                    var report = new DailyReport(new YiddishDate(day.StartTime), day.BreakDown);
                    report.Date.Day = report.Date.Day;
                    reports.Add(report);
                }

            return Json(reports, JsonRequestBehavior.AllowGet);
        }
    }
}