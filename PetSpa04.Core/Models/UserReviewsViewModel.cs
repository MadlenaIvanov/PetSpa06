using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models
{
    public class UserReviewsViewModel
    {
        public int Id { get; init; }

        //[Required]
        //[StringLength(50, MinimumLength = 2)]
        public string Title { get; init; }

        //[Required]
        //[StringLength(500, MinimumLength = 10)]
        public string Description { get; init; }

        //[Display(Name = "Image")]
        //[Url]
        public string ImageUrl { get; init; }
        public string Service { get; init; }
        public string UserId { get; init; }
        public IEnumerable<ReviewListingViewModel> Reviews { get; set; }

    }
}
