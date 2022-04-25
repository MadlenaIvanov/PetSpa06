using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Pets
{
    public class AddPetFormModel
    {

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; init; }

        [Range(0, 30)]
        public int Age { get; init; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Breed { get; init; }

        public decimal Weight { get; init; }

    }
}
