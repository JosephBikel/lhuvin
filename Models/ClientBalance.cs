using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lhuvin.Billing.Models
{
    public class ClientBalance
    {
        [ForeignKey("Client")]
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public virtual  Client Client { get; set; }

        public static void Create(Client client)
        {
            var context = new ApplicationDbContext();
            var clientBalance = new ClientBalance()
            {
                Id = client.Id
            };
            context.ClientBalances.Add(clientBalance);
            context.SaveChanges();
        }

        public void Add(decimal sum) => Balance += sum;
        
        public void Subtract(decimal sum) => Balance -= sum;
    }
}