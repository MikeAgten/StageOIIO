using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using static AppointmentProj.Application.Commands.GetAppointmentById.GetAppointmentByIdHandler;

namespace AppointmentProj.Application.Commands.GetAppointmentById
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdCommand, GetAppointmentByIdDto>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AddressBook addressBook;

        public GetAppointmentByIdHandler(AppointmentRepository appointmentRepository, AddressBook addressBook)
        {
            this.appointmentRepository = appointmentRepository;
            this.addressBook = addressBook;
        }
        public async Task<GetAppointmentByIdDto> Handle(GetAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var appointment = await appointmentRepository.GetByIdAsync(request.Id, cancellationToken);
            var address = addressBook.GetAddress(appointment.Latitude, appointment.Longitude);
            var appointmentDto = new GetAppointmentByIdDto { appointment = appointment, address = address };
            return appointmentDto;
        }
        public class GetAppointmentByIdDto
        {
            public Appointment appointment { get; set; }
            public Address address { get; set; }
        }

    }
}

