using ContactProj.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Commands.GetCustomerById
{
    public class GetContactByIdCommand : IRequest<Contact>
    {
        public GetContactByIdCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
