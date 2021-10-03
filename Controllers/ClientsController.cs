using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lhuvin.Controllers;
using Lhuvin.Models;
using Lhuvin.ViewModels;
using Lhuvin.Billing.Models;
using Lhuvin.Reports.Modals;
using System.Globalization;
using System.Data.Entity.Infrastructure;

namespace Lhuvin.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Clients
        [HttpGet]
        public ActionResult Index(string query)
        {
            var clients = _context.Clients.Include(c => c.Goal).Include(c => c.Balance).AsEnumerable();
           
            if (query != null)
            {
                
                var splitQuery = query.TrimStart(' ').TrimEnd(' ').ToLower().Split(' ');

                foreach (var item in splitQuery)
                {
                    clients = clients.Where(c => c.FirstName.ToLower().Contains(item) || c.LastName.ToLower().Contains(item));
                }
                ViewBag.query = query;
            }
            return View(clients.OrderBy(c => c.FatherName).OrderBy(c => c.LastName).ToList());
        }
        [HttpGet]
        public ActionResult Details(int id, string redirect)
        {
            var client = _context.Clients
                .Include(c => c.Balance)
                .Include(c => c.Days)
                .Include(c => c.Weeks.Select(w => w.Parsha)).Include(c => c.Weeks.Select(w => w.Days))
                .Include(c => c.Invoices)
                .Include(c => c.Payments)
                .Include(c => c.CreditCards.Select(ch => ch.Charges.Select(cha => cha.Card)))
                .SingleOrDefault(c => c.Id == id);
            foreach (var payment in client.Payments)
            {
                _context.Entry(payment).Reference(p => p.Charge).Load();
                if(payment.Charge != null)
                _context.Entry(payment.Charge).Reference(p => p.Card).Load();

                _context.Entry(payment).Reference(p => p.Check).Load();
            }
            return View(client);
        }


        public ActionResult NewClient()
        {

            ViewBag.Title = "נייע תלמיד";
            ViewBag.Message = "נייע תלמיד";
            var client = new ClientInfoViewModel {
                Client = new Client(),
                Price = new ClientPrice()
            };
            ViewData.Add("Price.PerHourId",
         new SelectList(_context.PricePerHours.Where(p => p.Public == true).Select(
         p => new {
             Id = p.Id,
             Description = p.Description + "\t" + p.Price
         }), "Id", "Description"));
            return View(client);
        } 

        [HttpPost]
        public  ActionResult NewClient(ClientInfoViewModel clientInfo, string NewCard)
        {
            clientInfo.Price.ConfirmationDate = DateTime.Now;
            try
            {
                _context.Clients.Add(clientInfo.Client);
                _context.SaveChanges();

                var price = _context.PricePerHours.Find(clientInfo.Price.PerHourId);
                if(!price.Public)
                    price.ClientId = clientInfo.Client.Id;

                clientInfo.Price.ClientId = clientInfo.Client.Id;
                _context.ClientPrices.Add(clientInfo.Price);
                _context.SaveChanges();

            
                ClientBalance.Create(clientInfo.Client);
                _context.clientGoals.Add(new ClientGoal { ClientId = clientInfo.Client.Id, Goal = "" });
                _context.SaveChanges();
            }
            catch(Exception exc)
            {
                if (exc is DbUpdateException dbUpdate)
                    ViewBag.Error = "Cannot insert duplicate values fo Home Phone.";
                else
                    ViewBag.Error = exc.Message;

                ViewData.Add("Price.PerHourId",
          new SelectList(_context.PricePerHours.Where(p => p.Public == true).Select(
          p => new {
              Id = p.Id,
              Description = p.Description + " " + p.Price
          }), "Id", "Description", clientInfo.Price.PerHourId));
                ViewBag.Title = "New Client";
                ViewBag.Message = "New Client";
                return View("NewClient", clientInfo);
                
            }
          
            return RedirectToAction("Index", "Clients");
        }

       
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var client = _context.Clients.Find(id);
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return  RedirectToAction("Index");
        }

        public ActionResult EditClient(int? id)
        {        
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var client = new ClientInfoViewModel
            { 
                Client = _context.Clients.Find(id),
                Price = _context.ClientPrices.AsEnumerable().LastOrDefault(p => p.ClientId == id)
            };
            if (client == null)
                return HttpNotFound();

      
             ViewBag.Title = "Edit Client";
             ViewBag.Message = "Edit Client";

            if (client.Price == null)
                ViewData.Add("Price.PerHourId",
         new SelectList(_context.PricePerHours.Where(p => p.Public == true).Select(
         p => new {
             Id = p.Id,
             Description = p.Description + " " + p.Price
         }), "Id", "Description"));
            else
                ViewData.Add("Price.PerHourId",
              new SelectList(_context.PricePerHours.Where(p => p.Public == true || p.ClientId == id).Select(
              p => new {
                  Id = p.Id,
                  Description = p.Description + " " + p.Price
              }), "Id", "Description", client.Price.PerHourId ));
            return View("NewClient", client);
        }

        [HttpPost]
        public ActionResult EditClient(ClientInfoViewModel clientInfo)
        {
            clientInfo.Price.ConfirmationDate = DateTime.Now;        
            if (clientInfo.Price.ClientId == 0)
            {
                 clientInfo.Price.ClientId = clientInfo.Client.Id;
                _context.ClientPrices.Add(clientInfo.Price);
                _context.SaveChanges(); 
                ModelState.SetModelValue("Price.ClientId", new ValueProviderResult(clientInfo.Client.Id, null, CultureInfo.InvariantCulture));

            }
            _context.Entry(clientInfo.Client).State = EntityState.Modified;
            var clientPrice = _context.ClientPrices.AsEnumerable().LastOrDefault(c => c.ClientId == clientInfo.Client.Id);
            if (clientPrice.PerHourId != clientInfo.Price.PerHourId)
                _context.ClientPrices.Add(clientInfo.Price);
            _context.SaveChanges();
                return RedirectToAction("Index", "Clients");
        }
    }
}
