using Microsoft.AspNetCore.Identity;
using PetSpa.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;


namespace PetSpa.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public IEnumerable<Pet> Pets { get; init; } = new List<Pet>();
        public IEnumerable<Review> Reviews { get; init; } = new List<Review>();
        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
