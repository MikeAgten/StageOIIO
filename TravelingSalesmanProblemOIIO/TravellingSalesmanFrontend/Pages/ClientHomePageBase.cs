using ContactProj.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingSalesmanFrontend.Pages
{
    public class ClientHomePageBase : ComponentBase
    {

        public IEnumerable<Contact> Contacts;
        public Contact Contact;
        [Parameter]
        public string ContactId { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeContacts();
            Contact = Contacts.FirstOrDefault(e => e.Id == int.Parse(ContactId));
            return base.OnInitializedAsync();
        }
        private void InitializeContacts()
        {
            Contacts = new List<Contact>()
            {
                new Contact{ Id = 1, FirstName = "Mike", Surname = "Agten", Type = Contact.ContactType.Tenant },
                new Contact{ Id = 2, FirstName = "Eline", Surname = "Bleyen", Type = Contact.ContactType.Tenant },
                new Contact{ Id = 3, FirstName = "Brent", Surname = "Gielen", Type = Contact.ContactType.Customer },
                new Contact{ Id = 4, FirstName = "Daan", Surname = "Pinxten", Type = Contact.ContactType.Customer },
                new Contact{ Id = 5, FirstName = "Ronny", Surname = "Gielen", Type = Contact.ContactType.Customer },
            };
        }
    }
}
