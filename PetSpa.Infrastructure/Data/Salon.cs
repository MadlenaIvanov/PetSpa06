using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class Salon
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NameOfSalon { get; set; }

        [Required]
        [StringLength(500)]
        public string Image { get; set; }

        [Required]
        [StringLength(500)]
        public string City { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; init; }
    }
}
