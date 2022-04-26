using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetSpa04.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
