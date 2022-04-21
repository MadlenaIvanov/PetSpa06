using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models
{
    public class AddReviewFormModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; init; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; init; }

        [Display(Name = "Image")]
        [Url]
        public string ImageUrl { get; init; }

        [Display(Name = "Pick a service")]
        public int ServiceId { get; init; }

        public IEnumerable<ServiceTypesViewModel>? Services { get; set; }
    }
}
