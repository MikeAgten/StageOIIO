using ContactProj.Domain;
using ContactProj.Domain.Enums;
using ContactProj.Persistance;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Commands.CreateCommand
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly ContactRepository contactRepository;

        public CreateContactHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact() {Type = (ContactType)request.ContactType, FirstName = request.FirstName, Surname = request.Surname, EmailAddress = request.EmailAddress, CreatedDateUtc = DateTime.Now};

            await contactRepository.SaveAsync(contact, cancellationToken);
            return contact.Id;
        }
    }
}
