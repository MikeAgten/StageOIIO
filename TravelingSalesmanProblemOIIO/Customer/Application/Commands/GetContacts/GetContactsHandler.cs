using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Commands.CreateCustomer
{
    public class GetContactsHandler : IRequestHandler<GetContactsCommand, List<Contact>>
    {
        private readonly ContactRepository contactRepository;

        public GetContactsHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<List<Contact>> Handle(GetContactsCommand request, CancellationToken cancellationToken)
        {

            var contact = await contactRepository.GetAsync(cancellationToken);
            return contact;
        }
    }
}
