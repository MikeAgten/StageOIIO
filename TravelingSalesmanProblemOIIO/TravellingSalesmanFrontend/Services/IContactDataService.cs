using ContactProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingSalesmanFrontend.Services
{
    public interface IContactDataService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int contactId);
        Task<Contact> AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContactById(int employeeId);

    }
}
