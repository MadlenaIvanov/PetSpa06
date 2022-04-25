namespace PetSpa04.Core.Models.Reviews
{
    public class UserReviewsViewModel
    {
        public string UserId { get; init; }
        public IEnumerable<ReviewListingViewModel>? Reviews { get; set; }

    }
}
