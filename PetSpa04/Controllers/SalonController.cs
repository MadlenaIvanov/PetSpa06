using Microsoft.AspNetCore.Mvc;

namespace PetSpa04.Controllers
{
    public class SalonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
