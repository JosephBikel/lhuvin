using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public ActionResult Index(int? id)
        {
            var payments = db.Payments.Include(p => p.Client).AsEnumerable();

            if(id != null)
            {
                payments = payments.Where(p => p.ClientId == id);
            }
            ViewBag.Error = TempData["Error"];
            ViewBag.homePhone = TempData["homePhone"];
            ViewBag.ClickButton = TempData["ClickButton"];
            return View(payments.ToList());
        }

        public ActionResult Create(int? id, string homePhone, string returnUrl)
        {
            Client client;

            if (id != null)
                client = db.Clients.Find((int)id);
            else if (homePhone != null)
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

            var newPayment = new CreatePaymentViewModel
            {
                Payment = new Payment(client.Id) { 
                Client = db.Clients.Find(client.Id)
                },
                PaymentTypes = Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>()
            };
            return View(newPayment);
        }

        [HttpPost]
        public JsonResult Create(Payment payment, string type, CreditCardCharge cardCharge, TPCheck tPCheck)
        {
             payment.PaymentDate = DateTime.Now;
            payment.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType),type);
            db.Payments.Add(payment);
            db.SaveChanges();

            if(payment.PaymentType == PaymentType.CreditCard)
            {
                cardCharge.PaymentId = payment.Id;
                db.CreditCardCharges.Add(cardCharge);
                db.SaveChanges();
            }
            else if(payment.PaymentType == PaymentType.Check)
            {
                tPCheck.PaymentId = payment.Id;
                db.TPChecks.Add(tPCheck);
                db.SaveChanges();
            }
            var clientId = payment.ClientId;
            var amount = payment.Amount;

            var clientBalance = db.ClientBalances.Find(clientId);
            clientBalance.Subtract(amount);

            Invoice.SubtractIB(amount, clientId);

            ClientWeek.SubtractBD(amount, clientId);

            db.SaveChanges();
            return Json(new { Amount = payment.Amount});
        }

        [HttpGet]
        public ActionResult EditPartial(int id)
        {
            var payment = db.Payments.Include(p => p.Charge).Include(p => p.Check).SingleOrDefault(p => p.Id == id);

            if(payment.PaymentType == PaymentType.CreditCard && payment.Charge != null)
            {
                    ViewBag.Location = payment.Charge.Location;
                    ViewBag.CardId = payment.Charge.CardId;
                
            }
            else if(payment.PaymentType == PaymentType.Check && payment.Check != null)
            {
                ViewBag.Memo = payment.Check.Memo;
            }
            ViewBag.type = payment.PaymentType.ToString();
            return PartialView(payment);
        }

        [HttpPost]
        public JsonResult Edit(Payment payment, string type, CreditCardCharge cardCharge, TPCheck tPCheck)
        {
            var clientId = payment.ClientId;
            var oldPayment = db.Payments.Find(payment.Id);
            if(payment.Amount > oldPayment.Amount)
            {
                db.ClientBalances.Find(clientId).Subtract(payment.Amount - oldPayment.Amount);
                ClientWeek.SubtractBD(payment.Amount - oldPayment.Amount, clientId);
            }
            else if(payment.Amount < oldPayment.Amount)
            {
                db.ClientBalances.Find(clientId).Add(oldPayment.Amount - payment.Amount);
                ClientWeek.AddBD(oldPayment.Amount - payment.Amount, clientId);
            }
            payment.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), type);
            db.Set<Payment>().AddOrUpdate(payment);
            db.SaveChanges();

            if(payment.PaymentType == PaymentType.CreditCard)
            {
                cardCharge.PaymentId = payment.Id;
                db.Set<CreditCardCharge>().AddOrUpdate(cardCharge);
                db.SaveChanges();
                var charge = db.CreditCardCharges.Include(c => c.Card).SingleOrDefault(c => c.PaymentId == payment.Id);
                var card = db.CreditCards.Find(charge.CardId);
                return Json(new {Id = payment.Id, PaymentDate = payment.PaymentDate, Amount = payment.Amount, PaymentType = payment.PaymentType,Name = card.Name,CardEnding = card.CardNumber.Substring(card.CardNumber.Length - 4), Location = charge.Location });
            }
            else if(payment.PaymentType == PaymentType.Check)
            {
                tPCheck.PaymentId = payment.Id;
                db.Set<TPCheck>().AddOrUpdate(tPCheck);
                db.SaveChanges();
                var check = db.TPChecks.Find(payment.Id);
                return Json(new { Id = payment.Id, PaymentDate = payment.PaymentDate, Amount = payment.Amount, PaymentType = payment.PaymentType, Memo = check.Memo});
            }
            return Json(payment);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return PartialView(payment);
        }

        // POST: CreditCards/Delete/5
        [HttpPost]
        public void Delete(int id)
        {
            Payment payment = db.Payments.Find(id);

            db.Payments.Remove(payment);
            db.ClientBalances.Find(payment.ClientId).Add(payment.Amount);
            db.SaveChanges();
            ClientWeek.AddBD(payment.Amount, payment.ClientId);
            
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