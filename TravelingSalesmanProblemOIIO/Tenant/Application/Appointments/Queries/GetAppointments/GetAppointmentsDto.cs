using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using System;

namespace AppointmentProj.Application.Queries.GetAppointments
{
        public class GetAppointmentsDto
        {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int ClientId { get; set; }
        public int TenantId { get; set; }
        public Address Address { get; set; }


        public static Func<Appointment, Address, GetAppointmentsDto> MapToDto = (appointment, address) => new GetAppointmentsDto
        {
            Id = appointment.Id,
            Title = appointment.Title,
            Description = appointment.Description,
            Latitude = appointment.Latitude,
            Longitude = appointment.Longitude,
            Duration = appointment.Duration,
            Date = appointment.Date,
            Start = appointment.Start,
            End = appointment.End,
            ClientId = appointment.ClientId,
            TenantId = appointment.TenantId,
            Address = address
        };
    }
}
