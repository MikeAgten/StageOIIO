using ContactProj.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Queries.CreateContact
{
    public class GetContactsQuery : IRequest<List<Contact>>
    {
    }
}
