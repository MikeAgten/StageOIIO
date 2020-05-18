using AppointmentProj.Application.Appointments.Commands.CalculateRoute;
using AppointmentProj.Application.Appointments.Interfaces;
using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using AppointmentProj.Persistence;
using BenchmarkDotNet.Running;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentProj.Application.Appointments.Commands.CalculateRoute
{
    public class CalculateRouteCommandHandler : IRequestHandler<CalculateRouteCommand, Unit>
    {
        AppointmentRepository appointmentRepository;
        AppointmentRequestRepository appointmentRequestRepository;
        TenantAddressBook tenantAddressBook;
        IGeneticAlgorithmService geneticAlgorithmService;

        public CalculateRouteCommandHandler(AppointmentRepository appointmentRepository, AppointmentRequestRepository appointmentRequestRepository, TenantAddressBook tenantAddressBook, IGeneticAlgorithmService geneticAlgorithmService)
        {
            this.appointmentRepository = appointmentRepository;
            this.appointmentRequestRepository = appointmentRequestRepository;
            this.tenantAddressBook = tenantAddressBook;
            this.geneticAlgorithmService = geneticAlgorithmService;
        }

        public async Task<Unit> Handle(CalculateRouteCommand request, CancellationToken cancellationToken)
        {
            AppointmentScheduler appointmentScheduler = new AppointmentScheduler();
            var appointmentRequests = await appointmentRequestRepository.GetByTenantIdAndDateAsync(request.TenantId, request.Date, cancellationToken);
            var tenantAddress = tenantAddressBook.GetAddress(request.TenantId);
            var tenantAppointmentRequest = new AppointmentRequest {Title = "TenantAddress", Latitude = tenantAddress.Latitude, Longitude = tenantAddress.Longitude };
            appointmentRequests.Insert(0, tenantAppointmentRequest);
            var sortedAppointmentRequests =  geneticAlgorithmService.Calculate(appointmentRequests, 100, 100000);
            var costArray = geneticAlgorithmService.calculateCostArray();
            var scheduledAppointments = appointmentScheduler.scheduleAppointments(sortedAppointmentRequests, costArray);
            foreach(Appointment appointment in scheduledAppointments)
            {
                await appointmentRepository.SaveAsync(appointment, cancellationToken);
                var appointmentRequestToChange = await appointmentRequestRepository.GetByIdAsync(appointment.Id, cancellationToken);
                appointmentRequestToChange.AppointmentId = appointment.Id;
                await appointmentRequestRepository.PutAsync(appointmentRequestToChange, cancellationToken);
            }
            return Unit.Value;
        }
    }
}
