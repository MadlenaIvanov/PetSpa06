using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models.Appointments;
using PetSpa04.Core.Models.Services;
using System.Globalization;
using System.Security.Claims;

namespace PetSpa04.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext data;

        public AppointmentController(ApplicationDbContext data)
        {
            this.data = data;

        }

        [Authorize]
        public IActionResult SuccessfulAppointment()
        {
            return View();
        }



        [Authorize]
        public IActionResult AddAppointment() => View(new AddAppointmentFormModel
        {
            Salons = this.GetSalonTypes(),
            Pets = this.GetPetList()
        });


        [HttpPost]
        [Authorize]
        public IActionResult AddAppointment(AddAppointmentFormModel appointment)
        {
            if (!this.data.Salons.Any(s => s.Id == appointment.SalonId))
            {
                this.ModelState.AddModelError(nameof(appointment.SalonId), "Salon does not exist!");
            }

            if (!this.data.Pets.Any(p => p.Id == appointment.PetId))
            {
                this.ModelState.AddModelError(nameof(appointment.PetId), "Pet does not exist!");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var countOfPetsForUser = this.data.Pets.Where(p => p.UserId == userId).Count();

            if (countOfPetsForUser < 1)
            {
                return RedirectToAction("AddPet", "Pet");

            }

            DateTime dateTime;
            try
            {
                DateTime.TryParseExact(appointment.Date, "MM-dd-yyyy hh:mm:tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction(nameof(AddAppointment));
            }

            if (!ModelState.IsValid)
            {
                appointment.Salons = this.GetSalonTypes();
                appointment.Pets = this.GetPetList();

                return View(appointment);
            }

            var appointmentEntry = new Appointment
            {
                Date = dateTime,
                PetId = appointment.PetId,
                SalonId = appointment.SalonId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            this.data.Appointments.Add(appointmentEntry);
            this.data.SaveChanges();

            return RedirectToAction(nameof(SuccessfulAppointment));
        }

        private IEnumerable<ServiceTypesViewModel> GetSalonTypes()
            => this.data
            .Salons
            .Select(s => new ServiceTypesViewModel
            {
                Id = s.Id,
                Name = s.NameOfSalon
            })
            .ToList();

        private IEnumerable<ServiceTypesViewModel> GetPetList()
            => this.data
            .Pets
            .Where(p => p.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            .Select(p => new ServiceTypesViewModel
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToList();
    }
}
