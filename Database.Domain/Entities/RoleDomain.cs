using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class RoleDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "نقش سیستمی")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "عنوان نقش")]
        public string Title { get; set; }
        public virtual ICollection<UserDomain> Users { get; set; }
    }
}
