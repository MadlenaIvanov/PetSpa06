using Microsoft.AspNetCore.Mvc;

namespace PetSpa04.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
