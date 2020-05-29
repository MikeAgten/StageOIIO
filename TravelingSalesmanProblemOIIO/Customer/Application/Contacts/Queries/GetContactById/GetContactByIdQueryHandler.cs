using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContactProj.Domain;
using ContactProj.Persistance;
using ContactProj.Application.Contacts.Queries.GetContactById;
using System.Linq;

namespace ContactProj.Application.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryDto>
    {
        private readonly ContactRepository contactRepository;

        public GetContactByIdQueryHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<GetContactByIdQueryDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await contactRepository.GetByIdAsync( request.Id ,cancellationToken);
            return GetContactByIdQueryDto.MapToDto(contact);
        }
    }
}

