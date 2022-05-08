using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class SettingDomain
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "کلید")]
        public string KeyString { get; set; }
        [Display(Name = "نام برنامه")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "درباره ما")]
        public string About { get; set; }
        [Display(Name = "قوانین")]
        public string Terms { get; set; }
        [Display(Name = "تلفن ثابت")]
        public string Tel { get; set; }
        [Display(Name = "فاکس")]
        public string Fax { get; set; }
        [Display(Name = "تاثیر آب و هوا")]
        public bool? IsWeatherEffect { get; set; }
        [Display(Name = "تاثیر مسافت")]
        public bool? IsDitanceEffect { get; set; }
    }
}
