using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lhuvin.Reports.Modals
{
    public class ClientEvalDetail
    {
        public int Id { get; set; }
        public EvalDetail Eval { get; set; }
        public int EvalId { get; set; }
        public ClientEvalHeader Header { get; set; }
        public int HeaderId { get; set; }
        [Required]
        public ClientEvalStatus Status { get; set; }
    }
}