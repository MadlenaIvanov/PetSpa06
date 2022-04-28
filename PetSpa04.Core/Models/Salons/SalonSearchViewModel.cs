using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Salons
{
    public class SalonSearchViewModel
    {

        public string ByLocation { get; set; }
        public IEnumerable<SalonListingViewModel> Salons { get; set; }
    }
}
