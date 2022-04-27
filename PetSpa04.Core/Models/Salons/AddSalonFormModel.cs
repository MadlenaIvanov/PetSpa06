using PetSpa04.Core.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Salons
{
    public class AddSalonFormModel
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string NameOfSalon { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [Display(Name = "Pick a location")]
        public int LocationId { get; init; }

        public IEnumerable<ServiceTypesViewModel>? Locations { get; set; }

    }
}
