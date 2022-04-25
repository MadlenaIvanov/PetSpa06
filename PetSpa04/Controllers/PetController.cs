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

        //[Authorize]
        //public IActionResult Edit(int id)
        //{
            
        //    //var petUserId = this.data.Pets.FirstOrDefault(x => x.UserId == userId);


        //    if (!this.data.Pets.Any(p => p.UserId == userId))
        //    {
        //        return Unauthorized();
        //    }

        //    var edit = this.data.Pets
        //        .Where(p => p.Id == id)
        //        .Select(e => new AddPetFormModel
        //        {
        //            Name = e.Name,
        //            Age = e.Age,
        //            Breed = e.Breed,
        //            Weight = e.Weight
        //        }).ToList();

        //    return View(edit);

        //}

        //[HttpPost]
        //[Authorize]

        //public IActionResult Edit(int id, AddPetFormModel pet)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

           
        //}
    }
}
