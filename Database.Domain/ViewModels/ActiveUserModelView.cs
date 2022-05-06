using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels
{
    public class ActiveUserModelView
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string ActiveCode { get; set; }
    }
}
