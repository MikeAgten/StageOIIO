using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentProj.Persistance;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.PutCustomer
{
    public class PutAppointmentHandler : IRequestHandler<PutAppointmentCommand, Appointment>
    {
        private readonly AppointmentRepository appointmentRepository;

        public PutAppointmentHandler(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task<Appointment> Handle(PutAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await appointmentRepository.GetByIdAsync(request.Id);
            appointment.Id = request.Id;
            appointment.Title = request.Title;
            appointment.Description = request.Description;
            appointment.Longitude = request.Longitude;
            appointment.Latitude = request.Latitude;
            appointment.Start = request.Start;
            appointment.End = request.End;
            appointment.ClientId = request.ClientId;
            appointment.TenantId = request.TenantId;
            appointment.CreatedDateUtc = DateTime.Now;
            await appointmentRepository.PutAsync(appointment);
            return appointment;
        }
    }
}
