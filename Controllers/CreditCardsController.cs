using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lhuvin.Billing.Models;
using Lhuvin.Billing.ViewModels;
using Lhuvin.Models;

namespace Lhuvin.Billing.Controllers
{
    public class CreditCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreditCards
        public ActionResult Index()
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.homePhone = TempData["homePhone"];
            ViewBag.ClickButton = TempData["ClickButton"];
            var creditCards = db.CreditCards.Include(c => c.Client);
            return View(creditCards.ToList());
        }

        [HttpGet]
        public  JsonResult GetCards(int id)
        {
            var cards = db.CreditCards.Where(c => c.ClientId == id).ToList();
            return Json(cards, JsonRequestBehavior.AllowGet);
        }

        // GET: CreditCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            return View(creditCard);
        }

        // GET: CreditCards/Create
        [HttpGet]
        public ActionResult Create(int? id, string homePhone, string returnUrl)
        {
            Client client; 

            if (id != null)
                client = db.Clients.Find((int)id);
            else  if (homePhone != null)
            {
                client = db.Clients.SingleOrDefault(c => c.HomePhone == homePhone);
                if (client == null)
                {
                    TempData["Error"] = "Invalid entry please try egan";
                    TempData["homePhone"] = homePhone;
                    TempData["ClickButton"] = "document.getElementById('open').click();";
                    return Redirect(returnUrl);
                }
            }
            else
               client = null;
            

            var newCard = new CreateCCViewModel
            {
                Client = client,
                Card = new CreditCard() { ClientId = client.Id}
            };
            return PartialView(newCard);
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreditCard newCard)
        {

            if (ModelState.IsValid)
            {
                

                db.CreditCards.Add(newCard);
                db.SaveChanges();
                return Json(newCard);
            }

            return View(newCard);
        }
        // GET: CreditCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FirstName", creditCard.ClientId);
            return PartialView(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCard).State = EntityState.Modified;
                db.SaveChanges();
                return Json(creditCard);
            }
            throw new Exception();
        }

        // GET: CreditCards/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            return PartialView(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost]
        public void Delete(int id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditCard);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
