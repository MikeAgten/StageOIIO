using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.DeleteAppointmentById
{
    public class DeleteAppointmentByIdHandler : IRequestHandler<DeleteAppointmentByIdCommand, Unit>
    {
        private readonly AppointmentRepository appointmentRepository;

        public DeleteAppointmentByIdHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            appointmentRepository.DeleteByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
