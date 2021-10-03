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
    public class PriceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Price
        public ActionResult Index()
        {
            var prices = db.PricePerHours.ToList();
            return View(prices);
        }

        // GET: Price/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Price/Create
        public ActionResult Create()
        {
            var newPrice = new PricePerHour()
            { Public = true};
                return View(newPrice);
        }

        // POST: Price/Create
        [HttpPost]
        public JsonResult Create(decimal price, string description, bool? isPublic, int? clientId)
        {
            var newPrice = new PricePerHour(price, description, isPublic, clientId);
                db.PricePerHours.Add(newPrice);
                db.SaveChanges();

            return Json(newPrice);
        }

        // GET: Price/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetClientPrice(int id)
        {
            var price = db.ClientPrices.Include(p => p.PerHour).AsEnumerable().LastOrDefault(p => p.ClientId == id);
            return Json(price.PerHour, JsonRequestBehavior.AllowGet);
        }

        // POST: Price/Edit/5
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

        // GET: Price/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Price/Delete/5
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
