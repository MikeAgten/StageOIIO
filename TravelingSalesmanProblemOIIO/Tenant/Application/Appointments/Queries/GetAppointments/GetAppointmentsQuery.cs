using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;
using static AppointmentProj.Application.Queries.GetAppointments.GetAppointmentsQueryHandler;

namespace AppointmentProj.Application.Queries.GetAppointments
{
    public class GetAppointmentsQuery : IRequest<List<GetAppointmentsDto>>
    {
    }
}
