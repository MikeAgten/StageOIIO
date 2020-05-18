using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Application.Commands.DeleteAppointmentById;

namespace AppointmentProj.Application.Commands.DeleteAppointmentById
{
    public class DeleteAppointmentByIdCommandHandler : IRequestHandler<DeleteAppointmentByIdCommand, Unit>
    {
        private readonly AppointmentRepository appointmentRepository;

        public DeleteAppointmentByIdCommandHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            await appointmentRepository.DeleteByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
