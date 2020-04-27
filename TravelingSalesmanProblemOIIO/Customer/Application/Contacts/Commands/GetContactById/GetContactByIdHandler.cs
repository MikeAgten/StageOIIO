using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContactProj.Domain;
using ContactProj.Persistance;

namespace ContactProj.Application.Commands.GetCustomerById
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdCommand, Contact>
    {
        private readonly ContactRepository contactRepository;

        public GetContactByIdHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<Contact> Handle(GetContactByIdCommand request, CancellationToken cancellationToken)
        {

            var contact = await contactRepository.GetByIdAsync(request.Id, cancellationToken);
            return contact;
        }
    }
}

