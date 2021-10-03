using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lhuvin.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }


    public class EvaluationDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string DetailName { get; set; }
        public Evaluation Evaluation { get; set; }
        public int EvaluationId { get; set; }
    }
}