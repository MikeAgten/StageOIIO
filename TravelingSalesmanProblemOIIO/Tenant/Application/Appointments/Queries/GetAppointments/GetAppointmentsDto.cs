using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;

namespace AppointmentProj.Application.Handlers.GetAppointments
{
    public partial class GetAppointmentsQueryHandler
    {
        public class GetAppointmentsDto
        {
            public Appointment Appointment { get; set; }
            public Address Address { get; set; }
        }
    }
}
