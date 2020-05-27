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
        private readonly AppointmentRepository appointmentRepository;
        private readonly AppointmentRequestRepository appointmentRequestRepository;
        private readonly TenantAddressBook tenantAddressBook;
        private readonly IGeneticAlgorithmService geneticAlgorithmService;

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
            var tenantAppointmentRequest = new AppointmentRequest { Title = "TenantAddress", Latitude = tenantAddress.Latitude, Longitude = tenantAddress.Longitude };
            appointmentRequests.Insert(0, tenantAppointmentRequest);
            var sortedAppointmentRequests = geneticAlgorithmService.Calculate(appointmentRequests, 100, GetAmountGenerations(appointmentRequests.Count-1));
            var costArray = geneticAlgorithmService.CalculateCostArray();
            var scheduledAppointments = appointmentScheduler.ScheduleAppointments(sortedAppointmentRequests, costArray);
            int appointmentId;
            foreach (Appointment appointment in scheduledAppointments)
            {
                appointmentId = await appointmentRepository.SaveAsync(new Appointment
                {
                    Title = appointment.Title,
                    Description = appointment.Description,
                    Longitude = appointment.Longitude,
                    Latitude = appointment.Latitude,
                    Duration = appointment.Duration,
                    Date = appointment.Date,
                    Start = appointment.Start,
                    End = appointment.End,
                    ClientId = appointment.ClientId,
                    TenantId = appointment.TenantId,
                    CreatedDateUtc = DateTime.Now
                }, cancellationToken);
                var appointmentRequestToChange = await appointmentRequestRepository.GetByIdAsync(appointment.Id, cancellationToken);
                appointmentRequestToChange.AppointmentId = appointmentId;
                await appointmentRequestRepository.PutAsync(appointmentRequestToChange, cancellationToken);
            }
            return Unit.Value;
        }

        public int GetAmountGenerations(int amountAddresses)
        {
            double fact = 0.00025; //used for scaling down the factorial graph
            for (int i = 1; i <= amountAddresses; i++)
            {
                fact = (fact * i);
            }
            if(fact < 10)
            {
                fact = 10;
            }
            return Convert.ToInt32(Math.Ceiling(fact));
        }
    }
}
