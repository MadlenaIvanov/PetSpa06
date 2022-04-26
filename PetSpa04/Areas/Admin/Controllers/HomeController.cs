using Microsoft.AspNetCore.Mvc;

namespace PetSpa04.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
