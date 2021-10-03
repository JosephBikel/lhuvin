using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Models;

namespace Lhuvin.ViewModels
{
    public class ClientEvaluationsViewModel
    {
        public ClientEvaluationHeader Header { get; set; }
        public List<ClientEvaluationDetail> Details { get; set; }
        public List<ClientEvaluationHeader> Headers { get; set; }
    }
}