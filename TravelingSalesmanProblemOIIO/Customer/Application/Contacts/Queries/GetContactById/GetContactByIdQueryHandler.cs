using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContactProj.Domain;
using ContactProj.Persistance;

namespace ContactProj.Application.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Contact>
    {
        private readonly ContactRepository contactRepository;

        public GetContactByIdQueryHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {

            var contact = await contactRepository.GetByIdAsync(request.Id, cancellationToken);
            return contact;
        }
    }
}

