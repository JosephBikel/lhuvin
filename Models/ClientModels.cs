using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lhuvin.Billing.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lhuvin.Billing;
using Lhuvin.Reports.Modals;

namespace Lhuvin.Models
{
    public class Client
    {
        public int Id { get; set; }


        [StringLength(50)]
        [Required]
        [Display(Name = "ערשטע נאמען")]
        public string FirstName { get; set; }


        [StringLength(50)]
        [Required]
        [Display(Name = "לעצטע נאמען")]
        public string LastName { get; set; }


        [StringLength(50)]
        [Display(Name = "טאטע׳ס נאמען")]
        public string FatherName { get; set; }

        [Display(Name = "יארגאנג")]
        public int? Age { get {
                if (DOB != null)
                {
                    var dob = DateTime.Parse(DOB.ToString());
                    var age = DateTime.Now.Year - dob.Year;
                    if (DateTime.Now.DayOfYear < dob.DayOfYear)
                        age--;
                    return age;
                }
                else
                    return null;
            } 
        }


        [StringLength(10)]
        [Display(Name = "כיתה")]
        public string Grade { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(15)]
        [Phone]
        [Display(Name = "היים נאמבער")]
        public string HomePhone { get; set; }


        [StringLength(15)]
        [Phone]
        [Display(Name = "טאטע׳ס סעל")]
        public string FathersCellNumber { get; set; }


        [StringLength(15)]
        [Phone]
        [Display(Name = "מאמע׳ס סעל")]
        public string MothersCellNumber { get; set; }


        [StringLength(100)]
        [Display(Name = "אדרעסס")]
        public string Address { get; set; }


        [StringLength(5)]
        [Display(Name = "יאנוט")]
        public string Unit { get; set; }


        [StringLength(25)]
        [Display(Name = "סיטי")]
        public string City { get; set; }


        [StringLength(25)]
        [Display(Name = "סטעיט")]

        public string State { get; set; }


        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        [Display(Name = "זיפ קאד")]
        public string Zip { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name ="אימעיל")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirmation Date")]
        public DateTime ConfirmationDate { get; set; }

        [Display(Name ="באלאנס")]
         public  ClientBalance Balance { get; set; }
        //public ClientPrice Price { get; set; }
        public ClientGoal Goal { get; set; }
       public ICollection<ClientDay> Days { get; set; }
        public ICollection<ClientWeek> Weeks { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }
        public Client()
        {
            ConfirmationDate = DateTime.Now;
        }
    }

}