using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models;
using PetSpa04.Models.API.Reviews;

namespace PetSpa04.Controllers.API
{

    [ApiController]
    [Route("api/review")]
    public class ReviewApiController : ControllerBase
    {
        private readonly ApplicationDbContext data;

        public ReviewApiController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public ActionResult<AllReviewsApiResponseModel> All([FromQuery] AllReviewsApiRequestModel query)
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

            //var reviewServices = this.data
            //    .Reviews
            //    .Select(r => r.Service.Name)
            //    .Distinct()
            //    .OrderBy(r => r)
            //    .ToList();

            reviewQuery = query.Sorting switch
            {
                ReviewSorting.DateCreatedAscending => reviewQuery.OrderBy(r => r.Id),
                ReviewSorting.DateCreatedDescending or _ => reviewQuery.OrderByDescending(r => r.Id)
            };

            var totalReviews = reviewQuery.Count();

            var reviews = reviewQuery
                .Skip((query.CurrentPage - 1) * query.ReviewsPerPage)
                .Take(query.ReviewsPerPage)
                .Select(r => new ReviewResponseModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    Service = r.Service.Name
                }).ToList();

            return new AllReviewsApiResponseModel
            {
                TotalReviews = totalReviews,
                CurrentPage = query.CurrentPage,
                Reviews = reviews
            };

        }
    }
}
