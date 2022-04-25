using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models.Pets;
using System.Security.Claims;

namespace PetSpa04.Controllers
{
    public class PetController : Controller
    {
        private readonly ApplicationDbContext data;

        public PetController(ApplicationDbContext _data)
        {
            data = _data;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            var petQuery = this.data.Pets.AsQueryable();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var pets = petQuery
                .Where(p => p.UserId == userId)
                .Select(p => new PetListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                    Breed = p.Breed,
                    Weight = p.Weight

                }).ToList();

            var returnModel = new UserPetsViewModel
            {
                UserId = userId,
                Pets = pets

            };

            return View(returnModel);
        }


        [Authorize]
        public IActionResult AddPet()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPet(AddPetFormModel pet)
        {

            if (!ModelState.IsValid)
            {
                return View(pet);
            }

            var petEntry = new Pet
            {
                Name = pet.Name,
                Age = pet.Age,
                Breed = pet.Breed,
                Weight = pet.Weight,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            this.data.Pets.Add(petEntry);
            this.data.SaveChanges();

            //return RedirectToAction(nameof(All));
            return RedirectToAction(nameof(MyPets));
        }
    }
}
