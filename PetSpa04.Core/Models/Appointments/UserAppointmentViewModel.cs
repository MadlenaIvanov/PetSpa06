using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models.Appointments
{
    public class UserAppointmentViewModel
    {
        public string UserId { get; init; }

        public IEnumerable<AppointmentListingViewModel>? Appointments { get; set; }
    }
}
