using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.Reports.Modals
{
    public class ClientEvalHeader
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<ClientEvalDetail> Details { get; set; }

        public ClientEvalHeader() { }

        public ClientEvalHeader(int clientId)
        {
            (ClientId, Date) = (clientId, DateTime.Now);
        }
    }
}