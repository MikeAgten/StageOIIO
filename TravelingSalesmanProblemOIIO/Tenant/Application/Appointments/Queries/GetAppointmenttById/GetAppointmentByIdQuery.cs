using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentProj.Domain;
using AppointmentProj.Domain.Models;
using AppointmentProj.Application.Handlers.GetAppointmentById;

namespace AppointmentProj.Application.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQuery : IRequest<GetAppointmentByIdDto>
    {
        public GetAppointmentByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
