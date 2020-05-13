using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;
using static AppointmentProj.Application.Handlers.GetAppointments.GetAppointmentsQueryHandler;

namespace AppointmentProj.Application.Commands.GetAppointments
{
    public class GetAppointmentsQuery : IRequest<List<GetAppointmentsDto>>
    {
    }
}
