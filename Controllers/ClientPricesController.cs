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
    public class ClientPricesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientPrice

         [HttpGet]
        public ActionResult Index()
        {
            var ClientPrices = db.ClientPrices.Include(p => p.Client).Include(p => p.PerHour).ToList();

            return View(ClientPrices);
        }
        public ActionResult Create(int id)
        {

            var model = new NewClientPriceViewModel()
            {
                Client = db.Clients.Find(id),
                ClientPrice = new ClientPrice(id),
                PricePerHours = db.PricePerHours.Where(p => p.Public == true).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCreate(NewClientPriceViewModel model)
        {
            db.ClientPrices.Add(model.ClientPrice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var clientPrice = db.ClientPrices.Include(p => p.Client).Include(p => p.PerHour)
                .SingleOrDefault(p => p.ClientId == id);
            return View(clientPrice);
        }
    }
}