using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContactProj.Domain;
using ContactProj.Persistance;

namespace ContactProj.Application.Commands.DeleteCustomerById
{
    public class DeleteContactByIdHandler : IRequestHandler<DeleteContactByIdCommand, Contact>
    {
        private readonly ContactRepository contactRepository;

        public DeleteContactByIdHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<Contact> Handle(DeleteContactByIdCommand request, CancellationToken cancellationToken)
        {
            var contact = await contactRepository.DeleteByIdAsync(request.Id);
            return contact;
        }
    }
}
