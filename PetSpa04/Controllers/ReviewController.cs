using Microsoft.AspNetCore.Mvc;
using PetSpa04.Core.Models;

namespace PetSpa04.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddReviewFormModel review)
        {
            return View();
        }
    }
}
