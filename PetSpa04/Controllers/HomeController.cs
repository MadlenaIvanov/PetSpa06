using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Models;
using System.Diagnostics;
using PetSpa04.Core.Models;

namespace PetSpa04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;


        public HomeController(ApplicationDbContext _data)
        {
            data = _data;
        }

        public IActionResult Index()
        {
            var totalReviews = this.data.Reviews.Count();
            var totalUsers = this.data.Users.Count();
            var totalAppointments = this.data.Appointments.Count();

            return View(new IndexViewModel
            {
                TotalReviews = totalReviews,
                TotalUsers = totalUsers,
                TotalAppointments = totalAppointments
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}