using ContactProj.Application.Commands.CreateContact;
using ContactProj.Application.Contacts.Queries.GetContacts;
using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Queries.CreateContact
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<GetContactsQueryDto>>
    {
        private readonly ContactRepository contactRepository;

        public GetContactsQueryHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<List<GetContactsQueryDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await contactRepository.GetAsync(cancellationToken);
            return contacts.Select(GetContactsQueryDto.MapToDto).ToList();
        }
    }
}
