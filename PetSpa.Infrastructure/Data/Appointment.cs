using PetSpa.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; init; }

        public int SalonId { get; set; }
        public Salon Salon { get; init; }

        public int PetId { get; set; }
        public Pet Pet { get; init; }

    }
}
