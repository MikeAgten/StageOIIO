using ContactProj.Application.Commands.CreateContact;
using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Queries.CreateContact
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<Contact>>
    {
        private readonly ContactRepository contactRepository;

        public GetContactsQueryHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<List<Contact>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {

            var contact = await contactRepository.GetAsync(cancellationToken);
            return contact;
        }
    }
}
