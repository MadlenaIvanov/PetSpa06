using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models.Salons;

namespace PetSpa04.Controllers
{
    public class SalonController : Controller
    {
        private readonly ApplicationDbContext data;
        public SalonController(ApplicationDbContext data)
        {
            this.data = data;

        }

        public IActionResult AllSalons([FromQuery] SalonSearchViewModel query)
        {
            var salonQuery = this.data.Salons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.ByLocation))
            {
                salonQuery = salonQuery.Where(r => r.City == query.ByLocation);
            }

            var salons = salonQuery
                .OrderBy(s => s.Id)
                .Select(s => new SalonListingViewModel
                {
                    Id = s.Id,
                    City = s.City,
                    Description = s.Description,
                    Image = s.Image,
                    NameOfSalon = s.NameOfSalon

                }).ToList();

            query.Salons = salons;

            return View(query);
        }
    }
}
