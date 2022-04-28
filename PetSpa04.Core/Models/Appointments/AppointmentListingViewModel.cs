using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Appointments
{
    public class AppointmentListingViewModel
    {
        public int Id { get; init; }

        public string Salon { get; init; }

        public string Pet { get; init; }

        public string User { get; init; }
    }
}
