using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;

namespace AppointmentProj.Application.Queries.GetAppointments
{
    public partial class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, List<GetAppointmentsDto>>
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly AddressBook addressBook;

        public GetAppointmentsQueryHandler(AppointmentRepository appointmentRepository, AddressBook addressBook)
        {
            this.appointmentRepository = appointmentRepository;
            this.addressBook = addressBook;
        }
        public async Task<List<GetAppointmentsDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            List<GetAppointmentsDto> appointmentDtos = new List<GetAppointmentsDto>();
            var appointments = await appointmentRepository.GetAsync(cancellationToken);
            foreach(Appointment appointment in appointments)
            {
                appointmentDtos.Add(new GetAppointmentsDto {
                    Appointment = appointment, 
                    Address = addressBook.GetAddress(appointment.Latitude, appointment.Longitude) });
            }
            return appointmentDtos;
        }
    }
}
