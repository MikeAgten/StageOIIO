using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.GetAppointments
{
    public class GetAppointmentsCommand : IRequest<List<Appointment>>
    {
    }
}
