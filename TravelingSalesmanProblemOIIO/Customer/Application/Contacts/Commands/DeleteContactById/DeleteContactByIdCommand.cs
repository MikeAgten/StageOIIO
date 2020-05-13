using System;
using System.Collections.Generic;
using System.Text;
using ContactProj.Domain;
using MediatR;

namespace ContactProj.Application.Queries.DeleteContactById
{
    public class DeleteContactByIdCommand : IRequest<Unit>
    {
        public DeleteContactByIdCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
