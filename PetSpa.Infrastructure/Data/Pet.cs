using PetSpa.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class Pet
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Breed { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; init; }

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
