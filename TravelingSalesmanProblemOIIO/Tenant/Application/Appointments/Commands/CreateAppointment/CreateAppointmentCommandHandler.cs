using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using System.Collections.Generic;
using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Persistence;

namespace AppointmentProj.Application.Commands.CreateHandler
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly AppointmentRequestRepository appointmentRequestRepository;

        public CreateAppointmentCommandHandler(AppointmentRequestRepository appointmentRequestRepository)
        {
            this.appointmentRequestRepository = appointmentRequestRepository;
        }
        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentRequest = new AppointmentRequest() { Title = request.Title,
                Description = request.Description,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                Duration = request.Duration,
                Date = request.Date,
                ClientId = request.ClientId,
                TenantId = request.TenantId,
                CreatedDateUtc = DateTime.Now
            };
            return await appointmentRequestRepository.SaveAsync(appointmentRequest, cancellationToken);
        }
    }
}
