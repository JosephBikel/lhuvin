using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lhuvin.Billing.Models
{
    public class ClientPrice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public PricePerHour PerHour { get; set; }

        [ForeignKey("PerHour")]
        [Required(ErrorMessage = "The Price field is requird")]
        public int PerHourId { get; set; }
        public DateTime ConfirmationDate { get; set; }

        public ClientPrice() { }

        public ClientPrice(int clientId)
        {

            (ClientId) = (clientId);
        }

        public ClientPrice(int clientId, int priceId)
        {
            (ClientId, PerHourId) = (clientId, priceId);
        }
    }
}