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
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices

        [HttpGet]
        public ActionResult Index(int? id)
        {
            var invoices = db.Invoices.Include(i => i.Client).AsEnumerable();

            if(id != null)
                invoices = invoices.Where(i => i.ClientId == id);
            ViewBag.Error = TempData["Error"];
            ViewBag.homePhone = TempData["homePhone"];
            ViewBag.ClickButton = TempData["ClickButton"];
            return View(invoices.ToList());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var invoice = db.Invoices
                .Include(i => i.Client).Include(c => c.Client.Balance)
                .SingleOrDefault(i => i.Id == id);
            return View(invoice);
        }

        [HttpGet]
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

            var unbilledWeeks = db.ClientWeeks.Include(w => w.Parsha).Include(w => w.Days)
                .Where(w => w.ClientId == id && w.Billed == false)
                .ToList();
           
            return Json(unbilledWeeks.Select(w => new { Parsha = w.Parsha.Name, Sum = w.Sum, Id = w.Id }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(CreateInvioceViewModel viewModel)
        {
            var dbWeeks = new List<ClientWeek>();
            if(viewModel.Weeks != null)
            {
                foreach (var week in viewModel.Weeks.Where(w => w.Billed == true))
                {
                    var dbWeek = db.ClientWeeks.Include(w => w.Parsha).Include(w => w.Days).SingleOrDefault(w => w.Id == week.Id);
                    dbWeeks.Add(dbWeek);
                }

                var invoice = new Invoice(dbWeeks, viewModel.ClientId);

                invoice.Report = viewModel.Report;
                invoice.Detaild = viewModel.Detaild;

                db.Invoices.Add(invoice);
                db.SaveChanges();
                return Json(invoice);
            }
        
            return Json(null);
                
        }
    }
}