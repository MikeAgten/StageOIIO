using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using AppointmentProj.Persistence;
using System;

namespace AppointmentProj.Application.Queries.GetAppointments
{
    public partial class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, List<GetAppointmentsDto>>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AppointmentRequestRepository appointmentRequestRepository;
        private readonly AddressBook addressBook;

        public GetAppointmentsQueryHandler(AppointmentRepository appointmentRepository, AppointmentRequestRepository appointmentRequestRepository, AddressBook addressBook)
        {
            this.appointmentRepository = appointmentRepository;
            this.appointmentRequestRepository = appointmentRequestRepository;
            this.addressBook = addressBook;
        }
        public async Task<List<GetAppointmentsDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            List<GetAppointmentsDto> appointmentDtos = new List<GetAppointmentsDto>();
            var appointmentRequests = await appointmentRequestRepository.GetAsync(cancellationToken);
            foreach (AppointmentRequest appointmentRequest in appointmentRequests)
            {
                if (appointmentRequest.AppointmentId != null)
                {
                    var appointment = await appointmentRepository.GetByIdAsync(appointmentRequest.AppointmentId.Value ,cancellationToken);
                    appointmentDtos.Add(new GetAppointmentsDto
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
                        Address = addressBook.GetAddress(appointmentRequest.Latitude, appointmentRequest.Longitude)
                    });
                } else
                {
                    appointmentDtos.Add(new GetAppointmentsDto
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
                    });
                }
            }
            return appointmentDtos;
        }
    }
}
