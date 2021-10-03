using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.ViewModels
{
    public class EvaluationDetailsViewModels
    {
        public Evaluation Evaluation { get; set; }
        public IEnumerable<EvaluationDetail> Details { get; set; }
    }
}