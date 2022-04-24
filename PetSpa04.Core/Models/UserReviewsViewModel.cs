using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models
{
    public class UserReviewsViewModel
    {
        public string UserId { get; init; }
        public IEnumerable<ReviewListingViewModel>? Reviews { get; set; }

    }
}
