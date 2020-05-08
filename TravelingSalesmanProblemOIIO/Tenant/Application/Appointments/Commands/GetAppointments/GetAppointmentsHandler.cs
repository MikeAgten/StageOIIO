using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using static AppointmentProj.Application.Commands.GetAppointments.GetAppointmentsHandler;

namespace AppointmentProj.Application.Commands.GetAppointments
{
    public class GetAppointmentsHandler : IRequestHandler<GetAppointmentsCommand, List<GetAppointmentsDto>>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AddressBook addressBook;

        public GetAppointmentsHandler(AppointmentRepository appointmentRepository, AddressBook addressBook)
        {
            this.appointmentRepository = appointmentRepository;
            this.addressBook = addressBook;
        }
        public async Task<List<GetAppointmentsDto>> Handle(GetAppointmentsCommand request, CancellationToken cancellationToken)
        {
            List<GetAppointmentsDto> appointmentDtos = new List<GetAppointmentsDto>();
            var appointments = await appointmentRepository.GetAsync(cancellationToken);
            foreach(Appointment appointment in appointments)
            {
                appointmentDtos.Add(new GetAppointmentsDto {
                    appointment = appointment, 
                    address = addressBook.GetAddress(appointment.Latitude, appointment.Longitude) });
            }
            return appointmentDtos;
        }

        public class GetAppointmentsDto
        {
            public Appointment appointment { get; set; }
            public Address address { get; set; }
        }
    }
}
