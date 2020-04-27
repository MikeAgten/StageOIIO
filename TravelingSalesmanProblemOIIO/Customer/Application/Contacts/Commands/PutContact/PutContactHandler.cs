using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Commands.PutCustomer
{
    public class PutContactHandler : IRequestHandler<PutContactCommand, Unit>
    {
        private readonly ContactRepository contactRepository;

        public PutContactHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<Unit> Handle(PutContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await contactRepository.GetByIdAsync(request.Id, cancellationToken);
            contact.Type = (Contact.ContactType)request.ContactType;
            contact.FirstName = request.FirstName;
            contact.Surname = request.Surname;
            contact.EmailAddress = request.EmailAddress;
            contact.CreatedDateUtc = request.CreatedDateUtc;
            await contactRepository.PutAsync(contact, cancellationToken);
            return Unit.Value;
        }
    }
}
