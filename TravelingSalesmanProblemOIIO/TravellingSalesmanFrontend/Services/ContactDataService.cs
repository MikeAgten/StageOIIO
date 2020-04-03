using ContactProj.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TravellingSalesmanFrontend.Services
{
    public class ContactDataService : IContactDataService
    {
        private readonly HttpClient _httpClient;

        public ContactDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Contact> AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Contact>>
                (await _httpClient.GetStreamAsync($"api/contacts"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            return await JsonSerializer.DeserializeAsync<Contact>
               (await _httpClient.GetStreamAsync($"api/contacts/{contactId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public Task UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
