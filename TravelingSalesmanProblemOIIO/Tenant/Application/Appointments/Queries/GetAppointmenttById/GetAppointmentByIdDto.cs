using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;

namespace AppointmentProj.Application.Handlers.GetAppointmentById
{
    public partial class GetAppointmentByIdQueryHandler
    {
        public class GetAppointmentByIdDto
        {
            public Appointment appointment { get; set; }
            public Address address { get; set; }
        }

    }
}

