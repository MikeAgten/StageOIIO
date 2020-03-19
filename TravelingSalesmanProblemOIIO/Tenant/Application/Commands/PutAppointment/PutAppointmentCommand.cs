using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.PutCustomer
{
    public class PutAppointmentCommand : IRequest<Appointment>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ClientId { get; set; }
        public int TenantId { get; set; }
    }
}
