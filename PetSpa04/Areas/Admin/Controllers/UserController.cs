using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Identity;
using PetSpa04.Core.Constants;
using PetSpa04.Core.Contracts;

namespace PetSpa04.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService service;

        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;
        }

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await service.GetUsers();

            //return Ok(users);
            return View(users);
        }

        //public async Task<IActionResult> CreateRole()
        //{
        //    // --> UnComment only when need to create new role <--
        //    //await roleManager.CreateAsync(new IdentityRole()
        //    //{
        //    //    Name = "Administrator"
        //    //});

        //    //return Ok();
        //}

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var model = await service.GetUserForEdit(Id);

            return View(model);
        }

    }
}
