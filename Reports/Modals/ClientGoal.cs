using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lhuvin.Reports.Modals
{
    public class ClientGoal
    {
        [Key]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        
        [StringLength(50)]
        public string Goal { get; set; }

        public Client Client { get; set; }
    }
}