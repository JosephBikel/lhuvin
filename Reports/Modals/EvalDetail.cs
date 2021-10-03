using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lhuvin.Reports.Modals
{
    public class EvalDetail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public EvalHeader Header { get; set; }

        [ForeignKey("Header")]
        public int HeaderId { get; set; }

        public ICollection<ClientEvalDetail> ClientEvals { get; set; }
    }
}