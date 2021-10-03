using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lhuvin.Models;
using Lhuvin.Reports.Modals;
namespace Lhuvin.Reports.Controllers
{
    public class GoalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Goels
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetGoal(int id)
        {
            var goal = db.clientGoals.Find(id);
            return Json(goal, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeGoal(int ClientId, string Goal)
        {
            db.clientGoals.Find(ClientId).Goal = Goal;
            db.SaveChanges();
            return Json(Goal, JsonRequestBehavior.AllowGet);
        }
    }
}