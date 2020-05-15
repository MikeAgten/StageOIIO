using ContactProj.Application.Contacts.Queries.GetContactById;
using ContactProj.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Queries.GetContactById
{
    public class GetContactByIdQuery : IRequest<GetContactByIdQueryDto>
    {
        public GetContactByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
