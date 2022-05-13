using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.MonthlyType
{
    public class MonthlyTypeViewModel
    {

        public MonthlyTypeViewModel()
        {
            MonthlyTypesInfo = new List<MonthlyTypeInfoViewModel>();
            Actions = new List<ActionItem>();
        }

        public List<MonthlyTypeInfoViewModel> MonthlyTypesInfo { get; set; }
        public List<ActionItem> Actions { get; set; }
    }

    public class MonthlyTypeInfoViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Start { get; set; }
        [Required]
        public int End { get; set; }
        [Required]
        public long Price { get; set; }
    }
}
