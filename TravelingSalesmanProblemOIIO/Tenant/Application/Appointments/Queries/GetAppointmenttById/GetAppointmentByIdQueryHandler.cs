﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain.Models;
using AppointmentProj.Application.Commands.GetAppointmentById;
using static AppointmentProj.Application.Handlers.GetAppointmentById.GetAppointmentByIdQueryHandler;

namespace AppointmentProj.Application.Handlers.GetAppointmentById
{
    public partial class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, GetAppointmentByIdDto>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AddressBook addressBook;

        public GetAppointmentByIdQueryHandler(AppointmentRepository appointmentRepository, AddressBook addressBook)
        {
            this.appointmentRepository = appointmentRepository;
            this.addressBook = addressBook;
        }
        public async Task<GetAppointmentByIdDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await appointmentRepository.GetByIdAsync(request.Id, cancellationToken);
            var address = addressBook.GetAddress(appointment.Latitude, appointment.Longitude);
            var appointmentDto = new GetAppointmentByIdDto { appointment = appointment, address = address };
            return appointmentDto;
        }
    }
}
