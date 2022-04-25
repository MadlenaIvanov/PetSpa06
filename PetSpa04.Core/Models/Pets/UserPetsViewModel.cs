using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Pets
{
    public class UserPetsViewModel
    {
        public string UserId { get; init; }
        public IEnumerable<PetListingViewModel>? Pets { get; set; }
    }
}
