using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain.Models;
using AppointmentProj.Application.Handlers.GetAppointmentById;
using AppointmentProj.Persistence;

namespace AppointmentProj.Application.Queries.GetAppointmentById
{
    public partial class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, GetAppointmentByIdDto>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AppointmentRequestRepository appointmentRequestRepository;
        private readonly AddressBook addressBook;

        public GetAppointmentByIdQueryHandler(AppointmentRepository appointmentRepository, AppointmentRequestRepository appointmentRequestRepository, AddressBook addressBook)
        {
            this.appointmentRepository = appointmentRepository;
            this.appointmentRequestRepository = appointmentRequestRepository;
            this.addressBook = addressBook;
        }
        public async Task<GetAppointmentByIdDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointmentRequest = await appointmentRequestRepository.GetByIdAsync(request.Id, cancellationToken);
            DateTime? start = null;
            DateTime? end = null;
            if (appointmentRequest.AppointmentId != null)
            {
                var appointment = await appointmentRepository.GetByIdAsync(appointmentRequest.AppointmentId.Value, cancellationToken);
                start = appointment.Start;
                end = appointment.End;
            }
            var appointmentDto = new GetAppointmentByIdDto
            {
                Id = appointmentRequest.Id,
                Title = appointmentRequest.Title,
                Description = appointmentRequest.Description,
                Latitude = appointmentRequest.Latitude,
                Longitude = appointmentRequest.Longitude,
                Duration = appointmentRequest.Duration,
                Date = appointmentRequest.Date,
                Start = start,
                End = end,
                ClientId = appointmentRequest.ClientId,
                TenantId = appointmentRequest.TenantId,
                Address = addressBook.GetAddress(appointmentRequest.Latitude, appointmentRequest.Longitude)
            };
            return appointmentDto;
        }
    }
}
