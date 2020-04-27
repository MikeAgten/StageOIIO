using ContactProj.Domain;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Commands.CreateCommand
{
    public class CreateContactCommand : IRequest<int>
    {
        public int ContactType { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}
