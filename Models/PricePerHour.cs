using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lhuvin.Billing.Models
{
    public class PricePerHour
    {
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

       [Index(IsUnique = true)]
        [StringLength(50)]
        public string Description { get; set; }

        public int? ClientId { get; set; }

        public Client Client { get; set; }

        public bool Public { get; set; }
        public DateTime ConfirmationDate { get; set; }

        public PricePerHour()
        {
            ConfirmationDate = DateTime.Now;
        }
        public PricePerHour(decimal price, string description, bool? isPublic, int? clientId)
        {
            ConfirmationDate = DateTime.Now;
            Price = price;
            Description = description;
            Public = isPublic == null ? true : (bool)isPublic;
            ClientId = clientId == 0? null : clientId;

        }
    
        public decimal Devide(TimeSpan time)
        {
            
            var price = Price / 60;
            var minutes = Convert.ToInt32(time.TotalMinutes) ;
            return decimal.Round(minutes * price, 2, MidpointRounding.AwayFromZero);
        }
    }
}