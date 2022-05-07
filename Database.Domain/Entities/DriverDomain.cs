using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Entities
{
    public class DriverDomain
    {
        [Required]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Car")]
        public Guid? CarId { get; set; }
        [ForeignKey("Car")]
        public Guid? ColorId { get; set; }
        public string CardCode { get; set; }
        public string Img { get; set; }
        public string Avatar { get; set; }
        public bool IsConfirm { get; set; }
        public virtual ColorDomain Color { get; set; }
        public virtual CarDomain Car { get; set; }
        public virtual UserDomain User { get; set; }
    }
}
