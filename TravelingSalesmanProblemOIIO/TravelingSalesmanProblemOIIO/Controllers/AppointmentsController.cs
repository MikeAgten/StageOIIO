using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Application.Commands.CreateCustomer;
using AppointmentProj.Application.Commands.DeleteCustomerById;
using AppointmentProj.Application.Commands.GetCustomerById;
using AppointmentProj.Application.Commands.PutCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelingSalesmanProblemOIIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand command)
        {
            var createdAppointment = await mediator.Send(command);
            return Created(new Uri("https://localhost:5001/api/Appointments/" + createdAppointment.Id), createdAppointment);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteAppointmentById(PutAppointmentCommand command)
        {
            var appointment = await mediator.Send(command);
            return Ok(appointment);
        }

        [HttpGet("{appointmentid:int}")]
        public async Task<IActionResult> GetAppointmentById(int appointmentid)
        {
            var appointment = await mediator.Send(new GetAppointmentByIdCommand(appointmentid));
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointment()
        {
            var appointment = await mediator.Send(new GetAppointmentsCommand());
            return Ok(appointment);
        }

        [HttpDelete("{appointmentid:int}")]
        public async Task<IActionResult> DeleteAppointmentById(int appointmentid)
        {
            var appointment = await mediator.Send(new DeleteAppointmentByIdCommand(appointmentid));
            return Ok(appointment);
        }
    }
}