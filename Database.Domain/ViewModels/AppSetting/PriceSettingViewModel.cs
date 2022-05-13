using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.AppSetting
{
    public class PriceSettingViewModel
    {
        [Required]
        public string KeyString { get; set; }
        [Display(Name = "تاثیر آب و هوا")]
        public bool IsWeatherEffect { get; set; }
        [Display(Name = "تاثیر مسافت")]
        public bool IsDitanceEffect { get; set; }
    }
}
