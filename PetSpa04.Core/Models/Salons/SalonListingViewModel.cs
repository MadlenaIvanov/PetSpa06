using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Salons
{
    public class SalonListingViewModel
    {
        public int Id { get; init; }

        public string NameOfSalon { get; init; }

        public string Image { get; init; }

        public string City { get; init; }

        public string Description { get; init; }

        public int LocationId { get; init; }

    }
}
