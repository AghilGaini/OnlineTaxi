using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.AppSetting
{
    public class TermsViewModel
    {
        [Required]
        public string KeyString { get; set; }
        public string Terms { get; set; }
    }
}
