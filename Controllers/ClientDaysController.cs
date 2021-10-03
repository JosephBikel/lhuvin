using System;
using System.Data.Entity;
using System.Globalization;
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
    public class ClientDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientDays
        public ActionResult Index( DateTime? date)
        {
            var clientDays = db.ClientDays.AsQueryable().Include(c => c.Client).AsEnumerable();

            if (date != null)
                clientDays = clientDays.AsEnumerable().Where(c => c.StartTime.AddDays(-(int)c.StartTime.DayOfWeek)
                    == date.Value.AddDays(-(int)date.Value.DayOfWeek));

            return View(clientDays.ToList());
        }

        // GET: ClientDays/Details/5
        public ActionResult Details(int id)
        {
            var day = db.ClientDays.Include(d => d.Client).SingleOrDefault(d => d.Id == id);
                return View(day);
        }

        // GET: ClientDays/Create
        [HttpGet]
        public ActionResult Create(int? id, string homePhone, DateTime date)
        {
            Client client;

            if (id != null)
                client = db.Clients.Find((int)id);
            else if (homePhone != null)
                client = db.Clients.SingleOrDefault(c => c.HomePhone == homePhone);
            else
                client = null;

            var newDay = new CreateClientDayViewModel(date)
            {

                ClientId = client.Id,
                PriceId = db.ClientPrices.AsEnumerable().LastOrDefault(p => p.ClientId == id ).PerHourId
            };
            ViewBag.k = newDay.PriceId;
            return View(newDay);
        }

        // POST: ClientDays/Create
        [HttpPost]
        public ActionResult Create(CreateClientDayViewModel model)
        {
            try
            {
                var date = ParshaWeek.GetDateFromPharsha(model.Day, model.Parsha, model.Year);
                var dateTime = new DateTime(date.Year, date.Month, date.Day,
               model.StartTime.Hours, model.StartTime.Minutes, 00);
                var clientDay = new ClientDay(dateTime, model.EndTime, model.ClientId, model.BreakDown, model.PriceId);
                db.ClientBalances.Find(clientDay.ClientId).Add(clientDay.Price);
                db.SaveChanges();
                return RedirectToAction("Create", "ClientWeeks", clientDay);
            }
            catch(Exception e)
            {
               return Json(e.Message);
            }
          
          
        }

        // GET: ClientDays/Edit/5
        public ActionResult Edit(int id)
        {
            var clientDay = db.ClientDays.Include(d => d.Client).SingleOrDefault(d => d.Id == id);
            var createDay = new CreateClientDayViewModel()
            {
                ClientId = clientDay.Client.Id,
                Date = clientDay.StartTime.Date,
                StartTime = clientDay.StartTime.TimeOfDay,
                EndTime = clientDay.EndTime.TimeOfDay,
                BreakDown = clientDay.BreakDown,
                DayId = id
            };
            return View(createDay);
        }


        [HttpPost]
        public ActionResult Edit(CreateClientDayViewModel day)
        {
            var date = new DateTime(day.Date.Year, day.Date.Month, day.Date.Day, day.StartTime.Hours, day.StartTime.Minutes, 0);
            var endDate = new DateTime(date.Year, date.Month, date.Day, day.EndTime.Hours, day.EndTime.Minutes, 0);

            var clientDay = db.ClientDays.Include(d => d.Week).SingleOrDefault(d => d.Id == day.DayId);
            var price = db.PricePerHours.Find(day.PriceId);
            if (string.IsNullOrWhiteSpace(day.BreakDown))
                (clientDay.Price, clientDay.Learnd) = (0, false);
            else
                clientDay.Learnd = true;
            var oldPrice = clientDay.Price;
            var newPrice = clientDay.Learnd? price.Devide(endDate - date): 0;

                (clientDay.StartTime, clientDay.EndTime, clientDay.BreakDown, clientDay.Time, clientDay.Price, clientDay.PricePHId ) 
                    = (date, endDate, day.BreakDown, endDate - date, newPrice, day.PriceId);

           
            db.ClientBalances.Find(clientDay.ClientId).Add(newPrice - oldPrice);
                db.SaveChanges();

            return RedirectToAction("Details", "ClientWeeks",
                    new { Id = clientDay.WeekId });
        }

       
        // POST: ClientDays/Delete/5
        public ActionResult Delete(int id)
        {
                var clientDay = db.ClientDays.Include(d => d.Week).SingleOrDefault(d => d.Id == id);
                var price = clientDay.Price;
                var week = clientDay.Week;
                db.ClientDays.Remove(clientDay);
                db.SaveChanges();

               /* if (week.OnBalance == true)
                {
                   return  RedirectToAction("Update", "Balance",
                        new { id = clientDay.ClientId, amount = -price });
                }*/
            return RedirectToAction("Details", "Clients",
                new { Id = clientDay.ClientId, redirect = "days-btn" });
        }
    }
}
