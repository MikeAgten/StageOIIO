using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;

namespace AppointmentProj.Application.Queries.GetAppointments
{
        public class GetAppointmentsDto
        {
            public Appointment Appointment { get; set; }
            public Address Address { get; set; }
        }
}
