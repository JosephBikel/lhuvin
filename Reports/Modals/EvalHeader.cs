using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lhuvin.Reports.Modals
{
    public class EvalHeader
    {
        public int Id { get; set; }

        [ForeignKey("SubCatogory")]
        public int SubCatogoryId { get; set; }

        [Required]
        public EvalSubCatogory SubCatogory { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public EvalHeader ParentHeader { get; set; }

        [ForeignKey("ParentHeader")]
        public int? HeaderId { get; set; }

        public ICollection<EvalHeader> ChildHeaders { get; set; }

        public ICollection<EvalDetail> Details { get; set; }
    }
}