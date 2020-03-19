using ContactProj.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Commands.PutCustomer
{
    public class PutContactCommand : IRequest<Contact>
    {
        public int Id { get; set; }
        public int ContactType { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
