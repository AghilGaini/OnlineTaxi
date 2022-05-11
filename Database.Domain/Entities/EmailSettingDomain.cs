using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class EmailSettingDomain
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string SmtpServer { get; set; }
        [Required]
        public int SmtpPort { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
