using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.DeleteCustomerById
{
    public class DeleteAppointmentByIdHandler : IRequestHandler<DeleteAppointmentByIdCommand, Appointment>
    {
        private readonly AppointmentRepository appointmentRepository;

        public DeleteAppointmentByIdHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<Appointment> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var appointment = await appointmentRepository.DeleteByIdAsync(request.Id);
            return appointment;
        }
    }
}
