using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class UserDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        public string Token { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }
        [ForeignKey("RoleId")]
        public virtual RoleDomain Role { get; set; }
    }
}
