using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.RateType
{
    public class RateTypeViewModel
    {
        public RateTypeViewModel()
        {
            RateTypesInfo = new List<RateTypeInfoViewModle>();
            Actions = new List<ActionItem>();
        }

        public List<RateTypeInfoViewModle> RateTypesInfo { get; set; }
        public List<ActionItem> Actions { get; set; }
    }

    public class RateTypeInfoViewModle
    {
        [Required]
        [Display(Name = "شناسه")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "رای مثبت")]
        public bool? Ok { get; set; }
        [Required]
        [Display(Name = "ترتیب")]
        public int ViewOrder { get; set; }
    }


}
