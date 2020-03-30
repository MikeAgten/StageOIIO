using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using System.Collections.Generic;

namespace AppointmentProj.Application.Commands.CreateCommand
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly AppointmentRepository appointmentRepository;

        public CreateAppointmentHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment() { Title = request.Title,
                Description = request.Description,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                Start = request.Start,
                End = request.End,
                ClientId = request.ClientId,
                TenantId = request.TenantId,
                //CreatedDateUtc = DateTime.Now
            };
            return await appointmentRepository.SaveAsync(appointment, cancellationToken);
        }
    }
}
