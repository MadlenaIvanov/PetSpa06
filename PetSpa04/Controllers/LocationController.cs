using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models.Locations;

namespace PetSpa04.Controllers
{
    public class LocationController : Controller
    {

        private readonly ApplicationDbContext data;

        public LocationController(ApplicationDbContext _data)
        {
            data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllLocation()
        {
            var locations = this.data.Locations
                .OrderBy(l => l.Id)
                .Select(l => new LocationListingViewModel
                {
                    Id = l.Id,
                    LocationTown = l.LocationTown,
                    Address = l.Address,
                }).ToList();

            return View(locations);
        }
    }
}
