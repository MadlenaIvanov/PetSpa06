namespace PetSpa04.Core.Models.Reviews
{
    public class ReviewSearchViewModel
    {
        public const int ReviewsPerPage = 3;

        public int CurrentPage { get; init; } = 1;

        public int TotalReviews { get; set; }

        public string OneService { get; set; }

        public IEnumerable<string> PickAService { get; set; }

        public string SearchTerm { get; init; }

        public ReviewSorting Sorting { get; init; }

        public IEnumerable<ReviewListingViewModel> Reviews { get; set; }
    }
}
