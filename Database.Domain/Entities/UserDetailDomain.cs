using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class UserDetailDomain
    {
        [Key]
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserId { get; set; }
        [Display(Name = "نام کاربری")]
        public string FullName { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        public string Date { get; set; }
        [Display(Name = "زمان ثبت نام")]
        public string Time { get; set; }
        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }
        public virtual UserDomain User { get; set; }

    }
}
