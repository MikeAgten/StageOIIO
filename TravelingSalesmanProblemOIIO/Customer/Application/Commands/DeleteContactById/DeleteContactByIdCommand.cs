using System;
using System.Collections.Generic;
using System.Text;
using ContactProj.Domain;
using MediatR;

namespace ContactProj.Application.Commands.DeleteCustomerById
{
    public class DeleteContactByIdCommand : IRequest<Contact>
    {
        public DeleteContactByIdCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
