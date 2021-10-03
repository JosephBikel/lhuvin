using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lhuvin.Reports.Modals
{
    public class EvalSubCatogory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public EvalCategory Category { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public ICollection<EvalHeader> ChildHeaders { get; set; }

        public ICollection<EvalDetail> Details { get; set; }
    }
}