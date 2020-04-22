using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactProj.Application.Commands.CreateCommand;
using ContactProj.Application.Commands.CreateCustomer;
using ContactProj.Application.Commands.DeleteCustomerById;
using ContactProj.Application.Commands.GetCustomerById;
using ContactProj.Application.Commands.PutCustomer;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelingSalesmanProblemOIIO.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            var createdContactId = await mediator.Send(command);
            return Created(new Uri("https://localhost:5001/api/Customers/" + createdContactId), createdContactId);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteContactById(PutContactCommand command)
        {
            var contact = await mediator.Send(command);
            return Ok(contact);
        }

        [HttpGet("{contactid:int}")]
        public async Task<IActionResult> GetContactById(int contactid)
        {
            var contact = await mediator.Send(new GetContactByIdCommand(contactid));
            return Ok(contact);
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await mediator.Send(new GetContactCommand());
            return Ok(contacts);
        }

        [HttpDelete("{contactid:int}")]
        public async Task<IActionResult> DeleteContactById(int contactId)
        {
            var contact = await mediator.Send(new DeleteContactByIdCommand(contactId));
            return Ok(contact);
        }
    }
}