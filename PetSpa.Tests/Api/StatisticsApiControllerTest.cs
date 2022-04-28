using PetSpa.Infrastructure.Data;
using PetSpa.Tests.Mocks;
using PetSpa04.Controllers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetSpa.Tests.Api
{
    public class StatisticsApiControllerTest
    {
        [Fact]
        public void GetStatisticsShouldReturnStats()
        {
            //Arrange
            var data = DatabaseMock.Instance;

            data.Reviews.Add(new Review { Id = 1, ImageUrl = "test1", Description = "test1", UserId = "1", Title = "test1" });
            data.Reviews.Add(new Review { Id = 2, ImageUrl = "test2", Description = "test2", UserId = "1", Title = "test2" });
            data.SaveChanges();

            var statisticsController = new StatisticsApiController(data);

            //Act
            var result = statisticsController.GetStatistics();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.TotalReviews);
            Assert.Equal(0, result.TotalUsers);
            Assert.Equal(0, result.TotalAppointments);
        }

    }

}
