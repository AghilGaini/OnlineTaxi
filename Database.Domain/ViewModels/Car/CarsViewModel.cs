using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Car
{
    public class CarsViewModel
    {
        [Required]
        [Display(Name = "شناسه")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نام ماشین")]
        public string Name { get; set; }
    }
}
