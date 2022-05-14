using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Role
{
    public class NewRoleViewModel
    {
        [Required]
        [Display(Name = "نقش سیستمی")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "عنوان نقش")]
        public string Title { get; set; }
    }
}
