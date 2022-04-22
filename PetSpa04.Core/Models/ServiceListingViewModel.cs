using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models
{
    public class ServiceListingViewModel
    {
        public int Id { get; init; }

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(500)]
        public string Description { get; set; }

        //[Required]
        //[StringLength(500)]
        public string ImageUrl { get; set; }

        //need to salons maybe
    }
}
