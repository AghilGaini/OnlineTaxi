using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.AppSetting
{
    public class TotalInformationViewModel
    {
        [Required]
        public string KeyString { get; set; }
        [Display(Name = "نام برنامه")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "تلفن ثابت")]
        public string Tel { get; set; }
        [Display(Name = "فاکس")]
        public string Fax { get; set; }
    }
}
