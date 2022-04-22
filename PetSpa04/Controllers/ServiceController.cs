using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models;

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
                .OrderByDescending(s => s.Id)
                .Select(s => new ServiceListingViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                }).ToList();

            return View(services);
        }
    }
}
