using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels
{
    public class RegisterAccountViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
    }
}
