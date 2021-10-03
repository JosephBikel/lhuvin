using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lhuvin.Billing;
using Lhuvin.Models;

namespace Lhuvin.Reports.Modals
{
    public class DailyReport
    {
        public YiddishDate Date { get; set; }
        public string Report { get; set; }

        public DailyReport() { }

        public DailyReport(YiddishDate date, string report)
        {
            (Date, Report) = (date, report);
        }
    }
}