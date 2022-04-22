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
            Services = this.GetServiceTypes(),
            TypeOfPet = this.GetPetTypes()


        });


        public IActionResult All()
        {
            var reviews = this.data.Reviews
                .OrderByDescending(r => r.Id)
                .Select(r => new ReviewListingViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    Service = r.Service.Name
                }).ToList();

            return View(reviews);
        }

        [HttpPost]
        public IActionResult Add(AddReviewFormModel review)
        {
            if (!this.data.Services.Any(r => r.Id == review.ServiceId))
            {
                this.ModelState.AddModelError(nameof(review.ServiceId), "Service does not exist!");
            }

            if (!this.data.PetTypes.Any(r => r.Id == review.PetTypeId))
            {
                this.ModelState.AddModelError(nameof(review.PetTypeId), "Pet type does not exist!");
            }


            if (!ModelState.IsValid)
            {
                review.Services = this.GetServiceTypes();
                review.TypeOfPet = this.GetPetTypes();

                return View(review);
            }

            var reviewEntry = new Review
            {
                Title = review.Title,
                Description = review.Description,
                ImageUrl = review.ImageUrl,
                ServiceId = review.ServiceId,
                PetTypeId = review.PetTypeId
            };

            this.data.Reviews.Add(reviewEntry);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
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

        private IEnumerable<ServiceTypesViewModel> GetPetTypes()
            => this.data
            .PetTypes
            .Select(s => new ServiceTypesViewModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();

    }
}
