using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using AppointmentProj.Persistence;
using System;
using AppointmentProj.Application.Services.AddressBookServices;

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
                DateTime? start = null;
                DateTime? end = null;
                if (appointmentRequest.AppointmentId != null)
                {
                    var appointment = await appointmentRepository.GetByIdAsync(appointmentRequest.AppointmentId.Value, cancellationToken);
                    start = appointment.Start;
                    end = appointment.End;
                }
                appointmentDtos.Add(new GetAppointmentsDto
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
                });
            }
            return appointmentDtos;
        }
    }
}

