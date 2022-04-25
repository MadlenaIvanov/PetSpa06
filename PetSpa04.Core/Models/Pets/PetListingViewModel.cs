using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Pets
{
    public class PetListingViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int Age { get; init; }

        public string Breed { get; init; }

        public decimal Weight { get; init; }
    }
}
