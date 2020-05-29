using ContactProj.Domain;
using ContactProj.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProj.Application.Contacts.Queries.GetContacts
{
    public class GetContactsQueryDto
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public static Func<Contact, GetContactsQueryDto> MapToDto = contact => new GetContactsQueryDto
        {
            Id = contact.Id,
            Type = contact.Type,
            FirstName = contact.FirstName,
            Surname = contact.Surname
        };
    }
}
