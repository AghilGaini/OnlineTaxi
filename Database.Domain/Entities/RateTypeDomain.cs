using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class RateTypeDomain
    {
        [Required]
        [Display(Name = "شناسه")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "رای مثبت")]
        public bool? Ok { get; set; }
        [Required]
        [Display(Name = "ترتیب")]
        public int ViewOrder { get; set; }
    }
}
