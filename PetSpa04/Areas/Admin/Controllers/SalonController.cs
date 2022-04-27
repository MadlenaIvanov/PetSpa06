using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models.Salons;
using PetSpa04.Core.Models.Services;

namespace PetSpa04.Areas.Admin.Controllers
{
    public class SalonController : BaseController
    {
        private readonly ApplicationDbContext data;

        public SalonController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSalon() => View(new AddSalonFormModel
        {
            Locations = this.GetLocationsTypes()
        });

        [HttpPost]
        public IActionResult AddSalon(AddSalonFormModel salon)
        {
            if (!this.data.Locations.Any(l => l.Id == salon.LocationId))
            {
                this.ModelState.AddModelError(nameof(salon.LocationId), "Location does not exist!");
            }

            if (!ModelState.IsValid)
            {
                salon.Locations = this.GetLocationsTypes();

                return View(salon);
            }

            var salonEntry = new Salon
            {
                City = salon.City,
                Image = salon.Image,
                NameOfSalon = salon.NameOfSalon,
                LocationId = salon.LocationId,
                Description = salon.Description

            };

            this.data.Salons.Add(salonEntry);
            this.data.SaveChanges();

            return RedirectToAction(nameof(AddSalon));
        }



        private IEnumerable<ServiceTypesViewModel> GetLocationsTypes()
            => this.data
            .Locations
            .Select(s => new ServiceTypesViewModel
            {
                Id = s.Id,
                Name = s.LocationTown
            })
            .ToList();

    }
}
