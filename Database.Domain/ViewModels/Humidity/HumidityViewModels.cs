using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Humidity
{
    public class HumidityViewModels
    {
        public HumidityViewModels()
        {
            Actions = new List<ActionItem>();
            HumiditiesInfo = new List<HumidityInfoViewModel>();
        }
        public List<ActionItem> Actions { get; set; }
        public List<HumidityInfoViewModel> HumiditiesInfo { get; set; }
    }
    public class HumidityInfoViewModel
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
        public double Percent { get; set; }
    }
}
