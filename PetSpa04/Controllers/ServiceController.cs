using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models;
using PetSpa04.Core.Models.Services;

namespace PetSpa04.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext data;

        public ServiceController(ApplicationDbContext _data)
        {
            data = _data;
        }

        public IActionResult AllService()
        {
            var services = this.data.Services
                .OrderBy(s => s.Id)
                .Select(s => new ServiceListingViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                }).ToList();

            return View(services);
        }

        public IActionResult Details(int id)
        {
            var detailsForService = this.data.Services
                .Where(s => s.Id == id)
                .Select(s => new ServiceListingViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl
                })
                .FirstOrDefault();

            return View(detailsForService);
        }
    }
}
