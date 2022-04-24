namespace PetSpa04.Models.API.Reviews
{
    public class AllReviewsApiResponseModel
    {
        public int CurrentPage { get; init; }

        public int TotalReviews { get; set; }
         
        public IEnumerable<ReviewResponseModel> Reviews { get; init; }
    }
}
