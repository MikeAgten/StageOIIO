using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Application.Commands.DeleteAppointmentById;
using AppointmentProj.Application.Commands.GetAppointmentById;
using AppointmentProj.Application.Commands.GetAppointments;
using AppointmentProj.Application.Commands.PutAppointment;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelingSalesmanProblemOIIO.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [EnableCors]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand command)
        {
            var createdAppointmentId = await mediator.Send(command);
            return Created(new Uri("https://localhost:5001/api/Appointments/" + createdAppointmentId), createdAppointmentId);
        }

        [HttpPut]
        public async Task<IActionResult> PutAppointmentById(PutAppointmentCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{appointmentid:int}")]
        public async Task<IActionResult> GetAppointmentById(int appointmentid)
        {
            var appointment = await mediator.Send(new GetAppointmentByIdCommand(appointmentid));
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await mediator.Send(new GetAppointmentsCommand());
            return Ok(appointments);
        }

        [HttpDelete("{appointmentid:int}")]
        public async Task<IActionResult> DeleteAppointmentById(int appointmentid)
        {
            var appointment = await mediator.Send(new DeleteAppointmentByIdCommand(appointmentid));
            return Ok();
        }
    }
}