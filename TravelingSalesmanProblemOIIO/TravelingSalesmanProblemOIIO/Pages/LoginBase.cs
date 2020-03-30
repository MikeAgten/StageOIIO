using ContactProj.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelingSalesmanProblemOIIO.Pages
{
    public class LoginBase : ComponentBase
    {
        
        public IEnumerable<Contact> Contacts { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeContacts();
            return base.OnInitializedAsync();
        }

        private void InitializeContacts()
        {
            Contacts = new List<Contact>
            {
                new Contact{Type = Contact.ContactType.Tenant, FirstName = "Brent", Surname = "Gielen", EmailAddress = "BG@gmail.com"  },
                new Contact{Type = Contact.ContactType.Tenant, FirstName = "Brent", Surname = "Gielen", EmailAddress = "BG@gmail.com"  },
                new Contact{Type = Contact.ContactType.Tenant, FirstName = "Brent", Surname = "Gielen", EmailAddress = "BG@gmail.com"  },
                new Contact{Type = Contact.ContactType.Tenant, FirstName = "Brent", Surname = "Gielen", EmailAddress = "BG@gmail.com"  },
            };
        }
    }
}
