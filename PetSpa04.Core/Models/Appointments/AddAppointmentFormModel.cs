using PetSpa04.Core.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Appointments
{
    public class AddAppointmentFormModel
    {
        public string Date { get; set; }


        [Display(Name = "Pick a Salon")]
        public int SalonId { get; init; }


        [Display(Name = "Pick which pet to sign in")]
        public int PetId { get; init; }

        public IEnumerable<ServiceTypesViewModel>? Salons { get; set; }

        public IEnumerable<ServiceTypesViewModel>? Pets { get; set; }

    }
}
