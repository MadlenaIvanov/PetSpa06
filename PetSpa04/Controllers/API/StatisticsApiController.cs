using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Models.API;

namespace PetSpa04.Controllers.API
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        //private readonly IStatisticsService statistics;
        private readonly ApplicationDbContext data;

        public StatisticsApiController(ApplicationDbContext data)
        {
            this.data = data;

        }


        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var totalReviews = this.data.Reviews.Count();
            var totalUsers = this.data.Users.Count();

            var statistics = new StatisticsResponseModel
            {
                TotalReviews = totalReviews,
                TotalAppointments = 0,
                TotalUsers = totalUsers
            };

            return statistics;
        }

    }
}
