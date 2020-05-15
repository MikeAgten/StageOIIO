using AppointmentProj.Application.Appointments.Commands.CalculateRoute;
using AppointmentProj.Application.Appointments.Interfaces;
using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using BenchmarkDotNet.Running;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentProj.Application.Appointments.Handlers.CalculateRoute
{
    public class CalculateRouteCommandHandler : IRequestHandler<CalculateRouteCommand, Unit>
    {
        AppointmentRepository appointmentRepository;
        IGeneticAlgorithmService geneticAlgorithmService;

        public CalculateRouteCommandHandler(AppointmentRepository appointmentRepository, IGeneticAlgorithmService geneticAlgorithmService)
        {
            this.appointmentRepository = appointmentRepository;
            this.geneticAlgorithmService = geneticAlgorithmService;
        }

        public async Task<Unit> Handle(CalculateRouteCommand request, CancellationToken cancellationToken)
        {
            AppointmentScheduler appointmentScheduler = new AppointmentScheduler();
            var appointments = await appointmentRepository.GetByTenantIdAndDateAsync(request.TenantId, request.Date, cancellationToken);
            var sortedAppointments =  geneticAlgorithmService.Calculate(appointments, 100, 100000);
            var costArray = geneticAlgorithmService.calculateCostArray();
            var scheduledAppointments = appointmentScheduler.scheduleAppointments(sortedAppointments, costArray);
            foreach(Appointment appointment in scheduledAppointments)
            {
                await appointmentRepository.PutAsync(appointment, cancellationToken);
            }
            return Unit.Value;
        }
    }
}
