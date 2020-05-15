using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;

namespace AppointmentProj.Application.Handlers.GetAppointmentById
{
    public class GetAppointmentByIdDto
    {
        public Appointment Appointment { get; set; }
        public Address Address { get; set; }
    }
}

