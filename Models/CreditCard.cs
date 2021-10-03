using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lhuvin.Billing.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(20)]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?(([0-9]{4}|[0-9]{2})$)", ErrorMessage ="exp must mach exp date")]
        
        public string Exp { get; set; }

        [Required]
        public short SecurityCode { get; set; }

        [DataType(DataType.PostalCode)]
        [MaxLength(10)]
        public string Zip { get; set; }

        [StringLength(50)]
        public string Name { get; set; }


        public Client Client  { get; set; }

        [Required]
        public int ClientId { get; set; }
        public ICollection<CreditCardCharge> Charges { get; set; }

        public CreditCard() { }

        public CreditCard(int id)
        {
            ClientId = id;
        }
    }
}