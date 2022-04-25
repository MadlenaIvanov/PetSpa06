using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class Location
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(100)]
        public string LocationTown { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public IEnumerable<Salon> Salons { get; set; } = new List<Salon>();

    }
}
