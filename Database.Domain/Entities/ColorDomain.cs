using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class ColorDomain
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نام رنگ")]
        public string Name { get; set; }
        [Display(Name = "کد رنگ")]
        public string Code { get; set; }
        public virtual ICollection<DriverDomain> Drivers { get; set; }
    }
}
