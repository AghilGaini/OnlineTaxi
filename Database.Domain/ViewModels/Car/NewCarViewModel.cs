using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Car
{
    public class NewCarViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
