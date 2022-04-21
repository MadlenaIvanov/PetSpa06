using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class Service
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
    }
}
