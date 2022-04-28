using Microsoft.AspNetCore.Mvc;
using PetSpa.Infrastructure.Data;
using PetSpa04.Core.Models.Appointments;

namespace PetSpa04.Areas.Admin.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly ApplicationDbContext data;

        public AppointmentController(ApplicationDbContext data)
        {
            this.data = data;
        }
        public IActionResult AllAppointments()
        {
            var appointments = this.data.Appointments
                .OrderBy(a => a.Id)
                .Where(a => a.IsPublic == true)
                .Select(a => new AppointmentListingViewModel
                {
                    Id = a.Id,
                    Pet = a.Pet.Name,
                    Salon = a.Salon.NameOfSalon,
                    User = a.User.Email
                }).ToList();

            return View(appointments);
        }

        public IActionResult ChangeVisibility(int id)
        {
            var appointment = this.data.Appointments.Find(id);

            appointment.IsPublic = !appointment.IsPublic;

            this.data.SaveChanges();

            return RedirectToAction(nameof(AllAppointments));
        }

    }
}
