using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class PetType
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();

    }
}
