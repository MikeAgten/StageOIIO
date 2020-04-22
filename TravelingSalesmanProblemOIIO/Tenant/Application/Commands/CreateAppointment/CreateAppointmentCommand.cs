using MediatR;
using System.Collections.Generic;
using System.Text;
using System;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.CreateCommand
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ClientId { get; set; }
        public int TenantId { get; set; }
        public int PartDay { get; set; }
    }
}
