using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.GetCustomerById
{
    public class GetAppointmentByIdCommand : IRequest<Appointment>
    {
        public GetAppointmentByIdCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
