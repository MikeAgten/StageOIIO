using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AppointmentProj.Domain;

namespace AppointmentProj.Application.Commands.DeleteAppointmentById
{
    public class DeleteAppointmentByIdCommand : IRequest<Unit>
    {
        public DeleteAppointmentByIdCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
