using ContactProj.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Commands.CreateCustomer
{
    public class GetContactCommand : IRequest<List<Contact>>
    {
    }
}
