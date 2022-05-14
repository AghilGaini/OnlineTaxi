using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.Termperature
{
    public class TemperatureViewModel
    {
        public TemperatureViewModel()
        {
            TemperaturesInfo = new List<TemperatureInfoViewModel>();
            Actions = new List<ActionItem>();
        }
        public List<TemperatureInfoViewModel> TemperaturesInfo { get; set; }
        public List<ActionItem> Actions { get; set; }
    }
    public class TemperatureInfoViewModel
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
