using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Constants;
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
                .Where(p => p.UserId == userId && p.IsPublic == true)
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
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsPublic = true
            };

            this.data.Pets.Add(petEntry);
            this.data.SaveChanges();

            //return RedirectToAction(nameof(All));
            return RedirectToAction(nameof(MyPets));
        }

        public IActionResult Edit(int id)
        {
            var model = this.GetPetForEdit(id);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AddPetFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (UpdatePet(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Успешен запис!";
            }
            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Грешка!";
            }

            return RedirectToAction(nameof(MyPets));
        }

        public bool UpdatePet(AddPetFormModel model)
        {
            bool result = false;
            var pet = this.data.Pets.Find(model.Id);

            if (pet != null)
            {
                pet.Name = model.Name;
                pet.Breed = model.Breed;
                pet.Age = model.Age;
                pet.Weight = model.Weight;

                this.data.SaveChanges();
                result = true;
            }

            return result;
        }

        public AddPetFormModel GetPetForEdit(int id)
        {
            var pet = this.data.Pets.Find(id);

            return new AddPetFormModel()
            {
                Name = pet.Name,
                Breed = pet.Breed,
                Age = pet.Age,
                Weight = pet.Weight
            };
        }

        public IActionResult ChangeVisibility(int id)
        {
            var pet = this.data.Pets.Find(id);

            pet.IsPublic = !pet.IsPublic;

            this.data.SaveChanges();

            return RedirectToAction(nameof(MyPets));
        }
    }
}
