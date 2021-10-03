using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Reports.Modals;

namespace Lhuvin.Reports.ViewModals
{
    public class EvaluateViewModal
    {
        public Client Client { get; set; }
        public IEnumerable<EvalCategory> Categories { get; set; }
        public IEnumerable<EvalHeader> EvalHeaders { get; set; }
    }
}