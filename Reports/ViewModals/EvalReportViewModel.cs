using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Reports.Modals;

namespace Lhuvin.Reports.ViewModals
{
    public class EvalReportViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<EvalCategory> EvalCategories { get; set; }
        public ClientEvalHeader ClientEval { get; set; }
    }
}