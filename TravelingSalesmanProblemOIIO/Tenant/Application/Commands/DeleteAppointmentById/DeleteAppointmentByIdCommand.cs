using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.DeleteCustomerById
{
    public class DeleteAppointmentByIdCommand : IRequest<Appointment>
    {
        public DeleteAppointmentByIdCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
