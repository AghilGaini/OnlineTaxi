using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.PriceType
{
    public class PriceTypeViewModel
    {
        public PriceTypeViewModel()
        {
            Actions = new List<ActionItem>();
            PriceTypesInfo = new List<PriceTypeInfoViewModel>();
        }

        public List<ActionItem> Actions { get; set; }
        public List<PriceTypeInfoViewModel> PriceTypesInfo { get; set; }

    }
    public class PriceTypeInfoViewModel
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
