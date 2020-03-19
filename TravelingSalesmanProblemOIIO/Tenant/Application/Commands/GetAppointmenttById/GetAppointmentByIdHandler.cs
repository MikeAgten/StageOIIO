using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.GetCustomerById
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdCommand, Appointment>
    {
        private readonly AppointmentRepository appointmentRepository;

        public GetAppointmentByIdHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<Appointment> Handle(GetAppointmentByIdCommand request, CancellationToken cancellationToken)
        {

            var appointment = await appointmentRepository.GetByIdAsync(request.Id);
            return appointment;
        }
    }
}

