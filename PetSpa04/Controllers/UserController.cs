using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Identity;
using PetSpa04.Core.Constants;
using PetSpa04.Core.Contracts;

namespace PetSpa04.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService service;

        public UserController(
            RoleManager<IdentityRole> roleManager,
            IUserService service)
        {
            this.roleManager = roleManager;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
