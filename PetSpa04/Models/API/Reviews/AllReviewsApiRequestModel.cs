using PetSpa04.Core.Models.Reviews;

namespace PetSpa04.Models.API.Reviews
{
    public class AllReviewsApiRequestModel
    {
        public int CurrentPage { get; init; } = 1;

        public int TotalReviews { get; init; }
        public string? OneService { get; set; }

        public string? SearchTerm { get; init; }

        public int ReviewsPerPage { get; init; } = 10;
        public ReviewSorting Sorting { get; init; }
    }
}
