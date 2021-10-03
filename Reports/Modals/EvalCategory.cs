using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lhuvin.Reports.Modals
{
    
    public class EvalCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public ICollection<EvalSubCatogory> SubCatogories { get; set; }

        public EvalCategory() { }

        public EvalCategory(string name)
        {
            Name = name;
        }
    }
}