using Lhuvin.Reports.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lhuvin.Reports.ViewModals
{
    public class PClientEvalDetail
    {
        [Required]
        public int EvalId { get; set; }
        public  ClientEvalStatus? Status { get; set; }
    }
}