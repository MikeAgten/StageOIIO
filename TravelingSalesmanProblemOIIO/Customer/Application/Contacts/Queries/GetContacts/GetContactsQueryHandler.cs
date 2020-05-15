using ContactProj.Application.Commands.CreateContact;
using ContactProj.Application.Contacts.Queries.GetContacts;
using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System.Collections.Generic;
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
            List<GetContactsQueryDto> ContactsDto = new List<GetContactsQueryDto>();
            var contacts = await contactRepository.GetAsync(cancellationToken);
            foreach(Contact contact in contacts)
            {
                ContactsDto.Add(new GetContactsQueryDto { Id = contact.Id, Type = contact.Type, FirstName = contact.FirstName, Surname = contact.Surname });
            }
            return ContactsDto;
        }
    }
}
