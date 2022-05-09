using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.RateType
{
    public class NewRateTypeViewModel
    {

        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "رای مثبت")]
        public bool Ok { get; set; }
        [Required]
        [Display(Name = "ترتیب")]
        public int ViewOrder { get; set; }
    }
}
