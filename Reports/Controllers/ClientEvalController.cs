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
using Lhuvin.Reports.ViewModals;
using System.Data.Entity;

namespace Lhuvin.Reports.Controllers
{
    public class ClientEvalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClientEval
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Evaluate(int id)
        {
            var viewModal = new EvaluateViewModal
            {
                Categories = db.EvalCategories.Include(c => c.SubCatogories),
                EvalHeaders = db.EvalHeaders.Include(h=> h.Details).Include(h => h.ChildHeaders),
                Client = db.Clients.Find(id)
            };
            return View(viewModal);
        }

        [HttpPost]
        public void Evaluate(int id, IEnumerable<PClientEvalDetail> evalDetails)
        {
            ClientEvalHeader header;

            var lastEval = db.ClientEvalHeaders.Include(e => e.Details).AsEnumerable().Where(e => e.ClientId == id).LastOrDefault();

            if (lastEval == null)
            {
                var newHeader = new ClientEvalHeader(id);
                header = newHeader;
                db.ClientEvalHeaders.Add(header);
                db.SaveChanges();
                db.Entry(header).Collection(h => h.Details).Load();
            }
            else
                header = lastEval;

            foreach (var detail in evalDetails.Where(d => d.Status != null))
            {

                ClientEvalDetail evalDetail;
                if (header.Details.Select(d => d.EvalId).Contains(detail.EvalId))
                {
                    evalDetail = header.Details.SingleOrDefault(e => e.EvalId == detail.EvalId);
                    evalDetail.Status = (ClientEvalStatus)detail.Status;

                }
                else
                {
                    evalDetail = new ClientEvalDetail
                    {
                        HeaderId = header.Id,
                        EvalId = detail.EvalId,
                        Status = (ClientEvalStatus)detail.Status
                    };

                    db.ClientEvalDetails.Add(evalDetail);
                }

                db.SaveChanges();
            }
        }

        [HttpGet]
        public JsonResult GetDetails(int id, string category)
        {
            var lastEval = db.ClientEvalHeaders.Include(e => e.Details.Select(d => d.Eval).Select(e => e.Header).Select(h => h.SubCatogory)).AsEnumerable().Where(e => e.ClientId == id).LastOrDefault();

            if (lastEval == null || lastEval.Date < DateTime.Now.AddDays(-30))
                return Json(null, JsonRequestBehavior.AllowGet);

            else
            {
                var details = lastEval.Details.Where(d => d.Eval.Header.SubCatogory.Name == category).Select(d =>  new { EvalId = d.EvalId, Status = d.Status});
                return Json(details.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetNegativeHeaders(int id)
        {
            var clientEvalHeader = db.ClientEvalHeaders.Include(c => c.Details).AsEnumerable().Where(c => c.ClientId == id).LastOrDefault();

            foreach (var detail in clientEvalHeader.Details)
            {
                db.Entry(detail).Reference(d => d.Eval).Load();
            }


            var evaldetails = clientEvalHeader.Details.Where(d => d.Status == ClientEvalStatus.NI || d.Status == ClientEvalStatus.Poor)
            .Select(d => d.Eval);
            
            foreach(var detail in evaldetails)
            {
                db.Entry(detail).Reference(d => d.Header).Load();
            }

            var evalHeaders = evaldetails.Select(d => d.Header).ToList();
            

            var tampEvalHeaders = new List<EvalHeader>(evalHeaders);

            

            foreach (var tampEval in tampEvalHeaders.ToList())
            {
                if(tampEval.HeaderId != null)
                {
                   var header = db.EvalHeaders.Find(tampEval.HeaderId);

                    tampEvalHeaders.Add(header);
                    evalHeaders.Add(header);
                   

                }
            }

            var headerCat = evalHeaders.Select(e => e.SubCatogoryId);

            var categorys = db.EvalSubCatogories.Where(e => headerCat.Any(i => i == e.Id));

            
            var headerIds = evalHeaders.Select(e => e.Id);
            return Json(categorys.Select(c => new { category = c.Name, headers = c.ChildHeaders.Where(c => headerIds.Any(i => i==c.Id)).Select(c => new { id = c.Id, headerId = c.HeaderId, name = c.Name})}), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNegativeDetails(int id, string header)
        {
            var lastClientEval = db.ClientEvalHeaders.Include(e => e.Details.Select(d => d.Eval)).AsEnumerable().LastOrDefault(e => e.ClientId == id);
            var evalDetails = lastClientEval.Details.Where(d => d.Status == ClientEvalStatus.NI || d.Status == ClientEvalStatus.Poor).Select(d => d.Eval);

            foreach (var detail in evalDetails)
            {
                db.Entry(detail).Reference("Header").Load();
            }            
            var headers = header.Split('-');

            return Json(evalDetails.Where(e => e.Header.Name == headers[headers.Length - 1])
                .Select(e => new { name = e.Name, status = lastClientEval.Details.Single(d => d.EvalId == e.Id).Status.ToString() }), JsonRequestBehavior.AllowGet);

        }


       [HttpGet]
       public ActionResult Report(int id, DateTime? date)
        {
            var clientEvalHeader = date == null ? db.ClientEvalHeaders.AsEnumerable().LastOrDefault(e => e.ClientId == id) :
              db.ClientEvalHeaders.SingleOrDefault(e => e.ClientId == id && e.Date == (DateTime)date);

            db.Entry(clientEvalHeader).Collection(e => e.Details).Load();

            foreach (var detail in clientEvalHeader.Details)
            {
                db.Entry(detail).Reference(d => d.Eval).Load();
            }

            var report = new EvalReportViewModel()
            {
                Client = db.Clients.Find(id),
                ClientEval = clientEvalHeader,
                EvalCategories = db.EvalCategories.Include(c => c.SubCatogories.Select(s => s.ChildHeaders.Select(h => h.Details)))
            };
            return View(report);
        }
    }
}