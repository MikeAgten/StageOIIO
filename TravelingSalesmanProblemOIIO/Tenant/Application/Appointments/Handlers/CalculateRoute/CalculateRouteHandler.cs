using AppointmentProj.Application.Appointments.Commands.CalculateRoute;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentProj.Application.Appointments.Handlers.CalculateRoute
{
    public class CalculateRouteHandler : IRequestHandler<CalculateRouteCommand, int>
    {

        public CalculateRouteHandler()
        {
        }
        public async Task<int> Handle(CalculateRouteCommand request, CancellationToken cancellationToken)
        {
            return 1;
        }
    }
}
