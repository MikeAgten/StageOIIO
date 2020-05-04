using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Commands.CalculateRoute
{
    public class CalculateRouteCommand : IRequest<Unit>
    {
        public DateTime Date { get; set; }
        public int TenantId { get; set; }
    }
}
