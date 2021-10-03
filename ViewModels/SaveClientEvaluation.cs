using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.ViewModels
{
    public class SaveClientEvaluation
    {
        public int ClientId { get; set; }
        public IEnumerable<EvalDetail> EvalDetails { get; set; }
        
    }
}