using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Lhuvin.Billing.Models;
using Lhuvin.Reports.Modals;
using System.Web.Configuration;

namespace Lhuvin.Models 
{ 

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPrice> ClientPrices { get; set; }
        public DbSet<ClientBalance> ClientBalances { get; set; }
        public DbSet<ClientGoal> clientGoals { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<EvalCategory> EvalCategories { get; set; }
        public DbSet<EvalSubCatogory> EvalSubCatogories { get; set; }
        public DbSet<EvalHeader> EvalHeaders { get; set; }
        public DbSet<EvalDetail> EvalDetails { get; set; }
        public DbSet<ClientEvalHeader> ClientEvalHeaders { get; set; }
        public DbSet<ClientEvalDetail> ClientEvalDetails { get; set; }

        public DbSet<ClientWeek> ClientWeeks { get; set; }
        public DbSet<CreditCardCharge> CreditCardCharges { get; set; }
        public DbSet<TPCheck> TPChecks { get; set; }

        public DbSet<PricePerHour> PricePerHours { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ClientDay> ClientDays { get; set; }
       
        
        public DbSet<ParshaWeek> ParshaWeeks { get; set; }
        
        public ApplicationDbContext()
            : base("Lhuvin")
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}