using ContactProj.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingSalesmanFrontend.Services;

namespace TravellingSalesmanFrontend.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public IContactDataService ContactDataService { get; set; }
        public IEnumerable<Contact> Contacts;
        public int CurrentContactId;

        protected override async Task OnInitializedAsync()
        {
            Contacts = (await ContactDataService.GetAllContacts()).ToList();
            CurrentContactId = Contacts.First().Id;
        }
    }
}
