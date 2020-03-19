using ContactProj.Domain;
using ContactProj.Persistance;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactProj.Application.Commands.CreateCustomer
{
    public class GetContactHandler : IRequestHandler<GetContactCommand, List<Contact>>
    {
        private readonly ContactRepository contactRepository;

        public GetContactHandler(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<List<Contact>> Handle(GetContactCommand request, CancellationToken cancellationToken)
        {

            var contact = await contactRepository.GetAsync();
            return contact;
        }
    }
}
