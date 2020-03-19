using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Commands.CreateCommand
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, Contact>
    {
        private readonly ContactRepository contactRepository;

        public CreateContactHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact() {Type = (Contact.ContactType)request.ContactType, FirstName = request.FirstName, Surname = request.Surname, EmailAddress = request.EmailAddress, CreatedDateUtc = DateTime.Now};

            await contactRepository.SaveAsync(contact);
            return contact;
        }
    }
}
