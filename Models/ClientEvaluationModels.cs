using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using System.ComponentModel.DataAnnotations;

namespace Lhuvin.Models
{
    public class ClientEvaluationHeader
    {
        public int Id { get; set; }
        public Client Client { get; set; }

        [Required]
        public int ClientId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Evaluation Date")]
        public DateTime EvaluationDate { get; set; }
    }


    public class ClientEvaluationDetail
    {
        public int Id { get; set; }
        public ClientEvaluationHeader ClientEvaluationHeader { get; set; }

        [Required]
        public int ClientEvaluationHeaderId { get; set; }
        public EvaluationDetail Evaluation { get; set; }

        [Required]
        public int EvaluationId { get; set; }
        public bool NeedHelp { get; set; }
    }
}