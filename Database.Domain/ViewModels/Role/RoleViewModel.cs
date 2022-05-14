using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Role
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Actions = new List<ActionItem>();
            RolesInfo = new List<RoleInfoViewModel>();
        }

        public List<ActionItem> Actions { get; set; }
        public List<RoleInfoViewModel> RolesInfo { get; set; }
    }
    public class RoleInfoViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نقش سیستمی")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "عنوان نقش")]
        public string Title { get; set; }
    }
}
