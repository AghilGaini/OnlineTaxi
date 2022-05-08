using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Color
{
    public class NewColorViewModel
    {
        [Required(ErrorMessage = "نام رنگ وارد نشده است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "کد رنگ وارد نشده است")]
        public string Code { get; set; }
    }
}
