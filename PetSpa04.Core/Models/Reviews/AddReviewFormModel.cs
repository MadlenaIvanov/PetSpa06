using PetSpa04.Core.Models.Services;
using System.ComponentModel.DataAnnotations;

namespace PetSpa04.Core.Models.Reviews
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

        [Display(Name = "Pick the type of pet")]
        public int PetTypeId { get; init; }

        public IEnumerable<ServiceTypesViewModel>? Services { get; set; }
        public IEnumerable<ServiceTypesViewModel>? TypeOfPet { get; set; }
    }
}
