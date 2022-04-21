using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models;

namespace PetSpa04.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext data;

        public ReviewController(ApplicationDbContext _data)
        {
            data = _data;
        }
        public IActionResult Add() => View(new AddReviewFormModel
        {
            Services = this.GetServiceTypes()
        });


        [HttpPost]
        public IActionResult Add(AddReviewFormModel review)
        {
            if (!this.data.Services.Any(r => r.Id == review.ServiceId))
            {
                this.ModelState.AddModelError(nameof(review.ServiceId), "Service does not exist!");
            }


            if (!ModelState.IsValid)
            {
                review.Services = this.GetServiceTypes();

                return View(review);
            }

            var reviewEntry = new Review
            {
                Title = review.Title,
                Description = review.Description,
                ImageUrl = review.ImageUrl,
                ServiceId = review.ServiceId
            };

            this.data.Reviews.Add(reviewEntry);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ServiceTypesViewModel> GetServiceTypes()
            => this.data
            .Services
            .Select(s => new ServiceTypesViewModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();

    }
}
