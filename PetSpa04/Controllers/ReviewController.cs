using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models;
using PetSpa04.Core.Models.Reviews;
using PetSpa04.Core.Models.Services;
using System.Security.Claims;

namespace PetSpa04.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext data;

        public ReviewController(ApplicationDbContext _data)
        {
            data = _data;
        }

        public IActionResult SuccessfulAdd()
        {
            return View(); 
        }

        public IActionResult All([FromQuery] ReviewSearchViewModel query)
        {
            var reviewQuery = this.data.Reviews.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.OneService))
            {
                reviewQuery = reviewQuery.Where(r => r.Service.Name == query.OneService);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                reviewQuery = reviewQuery.Where(s => s.PetType.Name == query.SearchTerm || 
                s.Service.Name == query.SearchTerm ||
                s.Description.ToLower().Contains(query.SearchTerm.ToLower()) ||
                s.Title.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var reviewServices = this.data
                .Reviews
                .Select(r => r.Service.Name)
                .Distinct()
                .OrderBy(r => r)
                .ToList();

            reviewQuery = query.Sorting switch
            {
                ReviewSorting.DateCreatedAscending => reviewQuery.OrderBy(r => r.Id),
                ReviewSorting.DateCreatedDescending or _ => reviewQuery.OrderByDescending(r => r.Id)
            };

            var totalReviews = reviewQuery.Count();

            var reviews = reviewQuery
                .Skip((query.CurrentPage - 1) * ReviewSearchViewModel.ReviewsPerPage)
                .Take(ReviewSearchViewModel.ReviewsPerPage)
                .Select(r => new ReviewListingViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    Service = r.Service.Name
                }).ToList();

            query.PickAService = reviewServices;
            query.Reviews = reviews;
            query.TotalReviews = totalReviews;

            return View(query);
        }

        [Authorize]
        public IActionResult MyReviews()
        {
            var reviewQuery = this.data.Reviews.AsQueryable();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reviews = reviewQuery
                .Where(r => r.UserId == userId)
                .Select(r => new ReviewListingViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    Service = r.Service.Name,
                    
                }).ToList();

            var returnModel = new UserReviewsViewModel
            {
                UserId = userId,
                Reviews = reviews

            };

            return View(returnModel);
        }



        [Authorize]
        public IActionResult Add() => View(new AddReviewFormModel
        {
            Services = this.GetServiceTypes(),
            TypeOfPet = this.GetPetTypes()
        });

        [HttpPost]
        [Authorize]
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
                PetTypeId = review.PetTypeId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            this.data.Reviews.Add(reviewEntry);
            this.data.SaveChanges();

            //return RedirectToAction(nameof(All));
            return RedirectToAction(nameof(SuccessfulAdd));
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
