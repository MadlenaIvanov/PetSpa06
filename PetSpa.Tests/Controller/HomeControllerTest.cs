using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa.Tests.Mocks;
using PetSpa04.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetSpa.Tests.Controller
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectDate()
        {
            //Arrange

            var data = DatabaseMock.Instance;

            data.Reviews.Add(new Review { Id = 1, ImageUrl = "test1", Description = "test1", UserId = "1", Title = "test1" });
            data.Reviews.Add(new Review { Id = 2, ImageUrl = "test2", Description = "test2", UserId = "1", Title = "test2" });
            data.SaveChanges();

            var homeController = new HomeController(data);

            //Act
            var result = homeController.Privacy();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void PrivacyShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController(null);

            //Act
            var result = homeController.Privacy();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
