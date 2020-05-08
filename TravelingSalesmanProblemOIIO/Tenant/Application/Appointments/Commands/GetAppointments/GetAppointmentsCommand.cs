using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;
using static AppointmentProj.Application.Commands.GetAppointments.GetAppointmentsHandler;

namespace AppointmentProj.Application.Commands.GetAppointments
{
    public class GetAppointmentsCommand : IRequest<List<GetAppointmentsDto>>
    {
    }
}
