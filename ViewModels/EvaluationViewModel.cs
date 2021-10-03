using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.ViewModels;

namespace Lhuvin.ViewModels
{
    public class EvaluationViewModel
    {
        public Client Client { get; set; }     
        public IEnumerable<Evaluation> Evaluations { get; set; }
        public IEnumerable<EvaluationDetail> EvaluationDetails { get; set; }
       
    }
}