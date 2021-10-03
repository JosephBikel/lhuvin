using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
    public class CreditCardChargesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreditCardCharges
        public ActionResult Index(int? id)
        {
            var charges = db.CreditCardCharges.Include( c=> c.Card).AsEnumerable();

            if (id != null)
                charges = charges.Where(c => c.CardId == id);
            ViewBag.Error = TempData["Error"];
            ViewBag.homePhone = TempData["homePhone"];
            ViewBag.ClickButton = TempData["ClickButton"];
            return View(charges.ToList());
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
            var newCharge = new CreateCCChargeViewModel
            { 
                Client = client,
                Cards = db.CreditCards.Where(c => c.ClientId == client.Id).ToList(),
                Charge = new CreditCardCharge()
            };
            ViewData.Add("Charge.CardId", new SelectList(newCharge.Cards.Select(
        n => new
        {
            Id = n.Id,
            Number = n.CardNumber.Substring(n.CardNumber.Length - 4)
        }),
    "Id", "Number")); ;
            return View(newCharge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCCChargeViewModel viewModel, CreditCard card, string newCard)
        {
            if (newCard != null)
            {
                db.CreditCards.Add(card);
                db.SaveChanges();
                viewModel.Cards = db.CreditCards.Where(c => c.ClientId == card.ClientId).ToList();
                viewModel.Charge = new CreditCardCharge();
                viewModel.Client = db.Clients.Find(card.ClientId);
                ViewData.Add("Charge.CardId", new SelectList(viewModel.Cards.Select(
                    n => new
                    {
                        Id = n.Id,
                        Number = n.CardNumber.Substring(n.CardNumber.Length - 4)
                    }),
                "Id", "Number", card.Id)) ;
                return View(viewModel);
            }
            else
            {
               /* var payment = new Payment(viewModel.Client.Id, PaymentType.CreditCard, viewModel.Charge.Amount);


                db.CreditCardCharges.Add(viewModel.Charge);
                db.Payments.Add(payment);
                db.SaveChanges();*/

                return RedirectToAction("Index");


            }
              
            
           

        }
    }
}