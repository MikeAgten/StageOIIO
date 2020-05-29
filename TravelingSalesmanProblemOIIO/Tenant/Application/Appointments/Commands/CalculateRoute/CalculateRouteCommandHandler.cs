using AppointmentProj.Application.Services.AddressBookServices;
using AppointmentProj.Application.Services.AlgorithmServices;
using AppointmentProj.Application.Services.SchedulerServices;
using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using AppointmentProj.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentProj.Application.Appointments.Commands.CalculateRoute
{
    public class CalculateRouteCommandHandler : IRequestHandler<CalculateRouteCommand, Unit>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AppointmentRequestRepository appointmentRequestRepository;
        private readonly AppointmentScheduler appointmentScheduler;
        private readonly TenantAddressBook tenantAddressBook;
        private readonly IGeneticAlgorithmService geneticAlgorithmService;

        public CalculateRouteCommandHandler(AppointmentRepository appointmentRepository, AppointmentRequestRepository appointmentRequestRepository, AppointmentScheduler appointmentScheduler, TenantAddressBook tenantAddressBook, IGeneticAlgorithmService geneticAlgorithmService)
        {
            this.appointmentRepository = appointmentRepository;
            this.appointmentRequestRepository = appointmentRequestRepository;
            this.appointmentScheduler = appointmentScheduler;
            this.tenantAddressBook = tenantAddressBook;
            this.geneticAlgorithmService = geneticAlgorithmService;
        }

        public async Task<Unit> Handle(CalculateRouteCommand request, CancellationToken cancellationToken)
        {
            var appointmentRequests = await appointmentRequestRepository.GetByTenantIdAndDateAsync(request.TenantId, request.Date, cancellationToken);
            var tenantAddress = tenantAddressBook.GetAddress(request.TenantId);
            var tenantAppointmentRequest = new AppointmentRequest { Title = "TenantAddress", Latitude = tenantAddress.Latitude, Longitude = tenantAddress.Longitude };
            appointmentRequests.Insert(0, tenantAppointmentRequest);
            var sortedAppointmentRequests = geneticAlgorithmService.Calculate(appointmentRequests, 100, GetAmountGenerations(appointmentRequests.Count-1));
            var costArray = geneticAlgorithmService.CalculateCostArray();
            var scheduledAppointments = appointmentScheduler.ScheduleAppointments(sortedAppointmentRequests, costArray);
            foreach (KeyValuePair<int, Appointment> appointment in scheduledAppointments)
            {
                var appointmentId = await appointmentRepository.SaveAsync(appointment.Value, cancellationToken);
                var appointmentRequest = appointmentRequests.FirstOrDefault(x => x.Id == appointment.Key);
                appointmentRequest.AppointmentId = appointmentId;
                await appointmentRequestRepository.PutAsync(appointmentRequest, cancellationToken);
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
