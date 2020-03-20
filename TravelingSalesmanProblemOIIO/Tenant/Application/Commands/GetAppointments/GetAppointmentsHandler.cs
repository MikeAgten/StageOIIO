using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.GetAppointments
{
    public class GetAppointmentsHandler : IRequestHandler<GetAppointmentsCommand, List<Appointment>>
    {
        private readonly AppointmentRepository appointmentRepository;

        public GetAppointmentsHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<List<Appointment>> Handle(GetAppointmentsCommand request, CancellationToken cancellationToken)
        {

            var appointment = await appointmentRepository.GetAsync();
            return appointment;
        }
    }
}
