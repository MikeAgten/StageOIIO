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
    public class DeleteContactByIdHandler : IRequestHandler<DeleteContactByIdCommand, Unit>
    {
        private readonly ContactRepository contactRepository;

        public DeleteContactByIdHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<Unit> Handle(DeleteContactByIdCommand request, CancellationToken cancellationToken)
        {
            await contactRepository.DeleteByIdAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
