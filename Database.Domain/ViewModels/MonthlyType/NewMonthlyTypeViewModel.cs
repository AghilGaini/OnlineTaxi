using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.MonthlyType
{
    public class NewMonthlyTypeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Start { get; set; }
        [Required]
        public int End { get; set; }
        [Required]
        public long Price { get; set; }
    }
}
