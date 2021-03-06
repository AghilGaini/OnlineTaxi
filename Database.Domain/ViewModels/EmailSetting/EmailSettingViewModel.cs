using Database.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels.EmailSetting
{
    public class EmailSettingViewModel
    {
        public EmailSettingViewModel()
        {
            EmailsInfo = new List<EmailSettingInfoViewModel>();
            Actions = new List<ActionItem>();
        }

        public List<EmailSettingInfoViewModel> EmailsInfo { get; set; }
        public List<ActionItem> Actions { get; set; }
    }

    public class EmailSettingInfoViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string SmtpServer { get; set; }
        [Required]
        public int SmtpPort { get; set; }
        public bool? UseSSL { get; set; }
    }
}
