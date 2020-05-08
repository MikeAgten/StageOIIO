using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using static AppointmentProj.Application.Commands.GetAppointmentById.GetAppointmentByIdHandler;

namespace AppointmentProj.Application.Commands.GetAppointmentById
{
    public class GetAppointmentByIdCommand : IRequest<GetAppointmentByIdDto>
    {
        public GetAppointmentByIdCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
