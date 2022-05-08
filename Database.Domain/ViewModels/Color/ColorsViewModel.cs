using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Color
{
    public class ColorsViewModel
    {
        public ColorsViewModel()
        {
            Actions = new List<ActionItem>();
            ColorsInfo = new List<ColorInfoViewModel>();
        }

        public List<ActionItem> Actions { get; set; }
        public List<ColorInfoViewModel> ColorsInfo { get; set; }
    }

    public class ColorInfoViewModel
    {
        [Required]
        [Display(Name = "شناسه")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نام رنگ")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "کد رنگ")]
        public string Code { get; set; }
    }

}
