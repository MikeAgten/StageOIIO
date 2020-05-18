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
            var address = addressBook.GetAddress(appointmentRequest.Latitude, appointmentRequest.Longitude);
            if (appointmentRequest.AppointmentId != null)
            {
                var appointment = await appointmentRepository.GetByIdAsync(appointmentRequest.AppointmentId.Value, cancellationToken);
                var appointmentDto = new GetAppointmentByIdDto
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
                    Address = addressBook.GetAddress(appointment.Latitude, appointment.Longitude)
                };
                return appointmentDto;
            }
            else
            {
                var appointmentDto = new GetAppointmentByIdDto
                {
                    Id = appointmentRequest.Id,
                    Title = appointmentRequest.Title,
                    Description = appointmentRequest.Description,
                    Latitude = appointmentRequest.Latitude,
                    Longitude = appointmentRequest.Longitude,
                    Duration = appointmentRequest.Duration,
                    Date = appointmentRequest.Date,
                    Start = DateTime.MinValue,
                    End = DateTime.MinValue,
                    ClientId = appointmentRequest.ClientId,
                    TenantId = appointmentRequest.TenantId,
                    Address = addressBook.GetAddress(appointmentRequest.Latitude, appointmentRequest.Longitude)
                };
                return appointmentDto;
            }
        }
    }
}
