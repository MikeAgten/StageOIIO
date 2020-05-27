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
        }
}
